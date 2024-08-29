import { Component, OnInit, Pipe } from '@angular/core';
import { Todo } from '../../models/todo';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TableFilterPipe } from "./table-filter.pipe";
import { animate, trigger, state, style, transition } from '@angular/animations';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule, TableFilterPipe, ],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css',
  animations: [
    trigger('todoFade',[
      state('closed',style({transform: 'translateX(120%)'})),
      state('open',style({transform: 'translateX(0)'})),
      transition('closed <=> open', [animate('1s ease-in')])]
    ),
    trigger('fadeIn', [
      transition(':enter', [
        style({opacity: '0' }),
        animate('1s', style({ opacity: '1' })),
      ]),
    ])
  ]
})
export class TodoListComponent {
  task = ""
  completed = false
  duration = 0
  priority = ""

  //property for holding the filter value
  filterInput = ""
  
  groupedTodos = new Array<Todo[]>()

  todoList :Todo[] = [
    {task: "Go Shopping", completed: false, duration: 0.833, priority: "high"},
    {task: "Clean the House", completed: true, duration: 2.0, priority: "normal"},
    {task: "Finish Homework", completed: false, duration: 1.5, priority: "high"},
    {task: "Cook Dinner", completed: true, duration: 0.75, priority: "normal"},
    {task: "Read a Book", completed: false, duration: 1.0, priority: "low"},
    {task: "Exercise", completed: true, duration: 0.5, priority: "normal"},
    {task: "Call Mom", completed: false, duration: 0.25, priority: "low"},
    {task: "Do Laundry", completed: true, duration: 1.25, priority: "normal"},
    {task: "Write Emails", completed: false, duration: 0.67, priority: "high"},
    {task: "Organize Desk", completed: true, duration: 0.33, priority: "low"}
  ]

   //experimenting with animations
   protected todoState: 'open' | 'closed' = 'closed'

  //no longer needed as moved out of foreach card construction
  // constructor(){  
  // }
  //
  // ngOnInit(){
  //   this.divideTasks()
  // }
  //
  removeTask(task: Todo) {
    const index = this.todoList.indexOf(task,0)
    this.todoList.splice(index, 1)
  }

  divideTasks()
  {
    for(let i=0, j =0; i< this.todoList.length; i++)
    {
      if (i >= 3 && i % 3 === 0)
      {
        j++
      }
      this.groupedTodos[j] = this.groupedTodos[j] || []
      this.groupedTodos[j].push(this.todoList[i])
    }
  }

  submitTask() {
    this.todoList.push(
      {
        task: this.task, 
        completed: false, 
        duration: this.duration, 
        priority: this.priority
      }
      
    )
    this.task = ""
    this.completed = false
    this.duration = 0
    this.priority = ""
  }

  checkIfComplete(task : Todo) : boolean {
    return task.completed === true
  }
}
