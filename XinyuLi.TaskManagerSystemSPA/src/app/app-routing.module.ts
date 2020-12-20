import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TaskComponent } from "./tasks/tasks.component";
import { HistoriesComponent } from "./histories/histories.component";
import { UsersComponent } from "./users/users.component";
import { RegisterComponent } from "./users/register/register.component";
import { UpdateComponent } from "./users/update/update.component";
import { DeleteComponent } from './users/delete/delete.component';
import { CreateTaskComponent } from './tasks/create-task/create-task.component';
import { DeleteTaskComponent } from './tasks/delete-task/delete-task.component';
import { UpdateTaskComponent } from './tasks/update-task/update-task.component';
import { CreateHistoryComponent } from './histories/create-history/create-history.component';
import { DeleteHistoryComponent } from './histories/delete-history/delete-history.component';
import { UpdateHistoryComponent } from './histories/update-history/update-history.component';
import { ByUserIdComponent } from './tasks/by-user-id/by-user-id.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'tasks',
    component: TaskComponent,
  },
  {
    path: 'taskhistories',
    component: HistoriesComponent,
  },
  {
    path: 'users',
    component: UsersComponent,
  },
  {
    path: 'users/register',
    component: RegisterComponent,
  },
  {
    path: 'users/update/:id',
    component: UpdateComponent,
  },
  {
    path: 'users/delete/:id',
    component: DeleteComponent,
  },
  {
    path: 'tasks/create',
    component: CreateTaskComponent,
  },
  {
    path: 'tasks/update/:id',
    component: UpdateTaskComponent,
  },
  {
    path: 'tasks/delete/:id',
    component: DeleteTaskComponent,
  },
  {
    path: 'tasks/update/:id',
    component: UpdateTaskComponent,
  },
  {
    path: 'tasks/user/:id',
    component: ByUserIdComponent,
  },
  {
    path: 'taskhistories/create',
    component: CreateHistoryComponent,
  },
  {
    path: 'taskhistories/update/:id',
    component: UpdateHistoryComponent,
  },
  {
    path: 'taskhistories/delete/:id',
    component: DeleteHistoryComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
