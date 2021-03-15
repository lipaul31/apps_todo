import { Component, OnInit } from '@angular/core';

import { TodoItemService } from "../_services/todo-item.service";
import { TodoItem, TodoItemAdd } from '../_models/todo-item';

@Component({
  selector: 'app-todo-item-list',
  templateUrl: './todo-item-list.component.html',
  styleUrls: ['./todo-item-list.component.scss']
})
export class TodoItemListComponent implements OnInit {

  todoItemDescription?: string;
  selectedTodoItemId?: number;
  selectedTodoItemUpdate?: TodoItem;
  todoItemsList: TodoItem[];

  constructor(
    private todoItemService: TodoItemService) { }

  ngOnInit(): void {
    this.getTodoItems();
  }

  onSelect(todoItemId: number): void {

    if (this.selectedTodoItemUpdate && this.selectedTodoItemUpdate.id == todoItemId) {
      return;
    }

    if (this.selectedTodoItemId == todoItemId) {
      this.selectedTodoItemId = undefined;
      return;
    }

    this.selectedTodoItemUpdate = undefined;
    this.selectedTodoItemId = todoItemId;
  }
  onCheckItem(todoItem: TodoItem): void {
    let newState = !todoItem.state;
    this.todoItemService.updateTodoItemState(todoItem.id, newState).subscribe();
  }
  onItemUpdate(updated: boolean): void {
    if (updated) {
      this.getTodoItems();
    }
    this.selectedTodoItemUpdate = undefined;
    this.selectedTodoItemId = undefined;
  }

  add(description: string): void {
    let newTodoItem: TodoItemAdd = {
      description: description
    };
    this.todoItemService.createTodoItem(newTodoItem)
      .subscribe(() => this.getTodoItems());
  }
  getTodoItems(): void {
    this.todoItemService.getTodoItems()
      .subscribe(result => {
        this.todoItemsList = result.sort((a, b) => a.id > b.id ? 0 : 1);

        this.selectedTodoItemUpdate = undefined;
        this.selectedTodoItemId = undefined;
      });
  }

  delete(todoItem: TodoItem): void {
    this.todoItemService.deleteTodoItemState(todoItem.id).subscribe(() => this.getTodoItems());
  }
}
