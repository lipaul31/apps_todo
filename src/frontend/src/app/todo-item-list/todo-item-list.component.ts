import { Component, OnInit } from '@angular/core';

import { TodoItemService } from "../_services/todo-item.service";
import { MessageService } from '../_services/message.service';
import { TodoItem, TodoItemAdd } from '../_models/todo-item';

@Component({
  selector: 'app-todo-item-list',
  templateUrl: './todo-item-list.component.html',
  styleUrls: ['./todo-item-list.component.scss']
})
export class TodoItemListComponent implements OnInit {

  selectedTodoItem?: TodoItem;
  todoItemsList: TodoItem[];

  constructor(
    private todoItemService: TodoItemService,
    public messageService: MessageService) { }

  ngOnInit(): void {
    this.getTodoItems();
  }

  onSelect(todoItem: TodoItem): void {
    if (this.selectedTodoItem == todoItem) {
      this.selectedTodoItem = undefined;
      return;
    }
    this.selectedTodoItem = todoItem;
  }
  onCheckItem(todoItem: TodoItem): void {
    let newState = !todoItem.state;
    this.todoItemService.updateTodoItemState(todoItem.id, newState).subscribe();
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
      .subscribe(result => this.todoItemsList = result);
  }
  delete(todoItem: TodoItem): void {
    this.todoItemsList = this.todoItemsList.filter(x => x.id !== todoItem.id);
    this.todoItemService.deleteTodoItemState(todoItem.id).subscribe();
  }

}
