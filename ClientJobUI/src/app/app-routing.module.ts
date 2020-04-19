import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobComponent } from './job/job.component';
import {LogInComponent} from './log-in/log-in.component';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { ProfileComponentComponent } from './profile-component/profile-component.component';


const routes: Routes = [
{path:"",component:AppComponent},
{path:"Job",component:JobComponent},
{path:"Login",component:LogInComponent},
{path:"Register", component:RegisterComponent},
{path:"Profile", component:ProfileComponentComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
