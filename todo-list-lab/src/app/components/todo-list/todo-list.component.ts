import { Component } from '@angular/core';
import { Todo } from '../../models/todo';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css',
})
export class TodoListComponent {

  completed = false;

  todoList :Todo[] = [
    {task: "Go Shopping", completed: false, duration: 50},
    {task: "Clean the House", completed: true, duration: 120},
    {task: "Finish Homework", completed: false, duration: 90},
    {task: "Cook Dinner", completed: true, duration: 45},
    {task: "Read a Book", completed: false, duration: 60},
    {task: "Exercise", completed: true, duration: 30},
    {task: "Call Mom", completed: false, duration: 15},
    {task: "Do Laundry", completed: true, duration: 75},
    {task: "Write Emails", completed: false, duration: 40},
    {task: "Organize Desk", completed: true, duration: 20}
  ]

  removeTask(task: Todo) {
    const index = this.todoList.indexOf(task,0)
    this.todoList.splice(index, 1)
  }
}
