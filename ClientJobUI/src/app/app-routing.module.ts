import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobComponent } from './job/job.component';
import { AppComponent } from './app.component';
import { ProfileComponentComponent } from './profile-component/profile-component.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { SignInComponent } from './sign-in/sign-in.component';


const routes: Routes = [
  { path: '', redirectTo: 'Login', pathMatch: 'full' },
  { path: "Job", component: JobComponent },
  { path: "Register", component: RegistrationFormComponent },
  { path: "Profile", component: ProfileComponentComponent },
  { path: "SignIn", component:SignInComponent  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
 