import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from "@angular/common/http";
import {ReactiveFormsModule, FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskComponent } from './tasks/tasks.component';
import { HistoriesComponent } from './histories/histories.component';
import { UsersComponent } from './users/users.component';

import { RegisterComponent } from './users/register/register.component';
import { UpdateComponent } from './users/update/update.component';
import { DeleteComponent } from './users/delete/delete.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { CreateHistoryComponent } from './histories/create-history/create-history.component';
import { UpdateHistoryComponent } from './histories/update-history/update-history.component';
import { DeleteHistoryComponent } from './histories/delete-history/delete-history.component';
import { DeleteTaskComponent } from './tasks/delete-task/delete-task.component';
import { UpdateTaskComponent } from './tasks/update-task/update-task.component';
import { CreateTaskComponent } from './tasks/create-task/create-task.component';
import { ByUserIdComponent } from './tasks/by-user-id/by-user-id.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    HistoriesComponent,
    UsersComponent,
    RegisterComponent,
    UpdateComponent,
    DeleteComponent,
    HeaderComponent,
    CreateHistoryComponent,
    UpdateHistoryComponent,
    DeleteHistoryComponent,
    DeleteTaskComponent,
    UpdateTaskComponent,
    CreateTaskComponent,
    ByUserIdComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [DeleteComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
