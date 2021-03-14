import { Component, OnInit, Input } from '@angular/core';
import { TodoItem } from '../_models/todo-item';
import { TodoItemService } from "../_services/todo-item.service";

@Component({
  selector: 'app-todo-item-details',
  templateUrl: './todo-item-details.component.html',
  styleUrls: ['./todo-item-details.component.scss']
})
export class TodoItemDetailsComponent implements OnInit {

  @Input("todo-item") todoItem?: TodoItem;

  constructor(private todoItemService: TodoItemService) { }

  ngOnInit(): void {
  }

  save(): void {
    this.todoItemService.updateTodoItem(this.todoItem)
      .subscribe(() => console.log('save finished'));
  }

}
