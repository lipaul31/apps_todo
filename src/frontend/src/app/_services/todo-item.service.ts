import { Injectable } from '@angular/core';
import { Observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { TodoItem, TodoItemAdd } from "../_models/todo-item";
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class TodoItemService {

  private todoApiUrl = 'http://localhost:5000/v1/todo';

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET: get TODO ITEMS from the server */
  getTodoItems(filter?: string): Observable<TodoItem[]> {
    let url = this.todoApiUrl;
    if (filter && filter.trim()) {
      url = `${url}?filter=${filter}`;
    }
    return this.http.get<TodoItem[]>(url)
      .pipe(
        tap(_ => this.pushMessage('items retrieved successfully')),
        catchError(this.handleError<TodoItem[]>('getTodoItems', []))
      );
  }
  /** GET: get a TODO ITEM from the server */
  getTodoItem(id: number): Observable<TodoItem> {
    const url = `${this.todoApiUrl}/${id}`;
    return this.http.get<TodoItem>(url)
      .pipe(
        tap(_ => this.pushMessage('items retrieved successfully')),
        catchError(this.handleError<TodoItem>('getTodoItems', undefined))
      );
  }
  /** POST: create a TODO ITEM on the server */
  createTodoItem(todoItem: TodoItemAdd): Observable<any> {
    return this.http.post(this.todoApiUrl, todoItem, this.httpOptions).pipe(
      tap(_ => this.pushMessage(`todo item created description=${todoItem.description}`)),
      catchError(this.handleError<any>('createTodoItem'))
    );
  }
  /** PUT: update the TODO ITEM on the server */
  updateTodoItem(todoItem: TodoItem): Observable<any> {
    const url = `${this.todoApiUrl}/${todoItem.id}`;
    console.log('updating item...');
    return this.http.put(url, todoItem, this.httpOptions).pipe(
      tap(_ => this.pushMessage(`todo item updated id=${todoItem.id}`)),
      catchError(this.handleError<any>('updateTodoItem'))
    );
  }
  /** PATCH: update the TODO ITEM state on the server */
  updateTodoItemState(id: number, state: boolean): Observable<any> {
    const url = `${this.todoApiUrl}/${id}/state`;
    return this.http.patch(url, state, this.httpOptions).pipe(
      tap(_ => this.pushMessage(`todo item state updated id=${id}`)),
      catchError(this.handleError<any>('updateTodoItemState'))
    );
  }
  /** DELETE: delete the TODO ITEM on the server */
  deleteTodoItemState(id: number): Observable<any> {
    const url = `${this.todoApiUrl}/${id}`;
    return this.http.delete(url, this.httpOptions).pipe(
      tap(_ => this.pushMessage(`todo item was deleted id=${id}`)),
      catchError(this.handleError<any>('deleteTodoItemState'))
    );
  }

  private pushMessage(message: string) {
    this.messageService.add(`TodoItemService: ${message}`);
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(`${operation} failed: ${error.message}`);

      this.pushMessage(`${error.message}`);

      return of(result as T);
    };
  }
}
