import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {JobComponent} from './job/job.component';
import {RegistrationFormComponent} from './registration-form/registration-form.component';
import {SignInComponent} from './sign-in/sign-in.component';
import {HomeComponent} from './home/home.component';
import {UserProfileComponent} from './user-profile/user-profile.component';


const routes: Routes = [
  {path: '', redirectTo: 'jobs', pathMatch: 'full'},
  {path: 'jobs', component: JobComponent},
  {path: 'register', component: RegistrationFormComponent},
  {path: 'profile', component: UserProfileComponent},
  {path: 'sign-in', component: SignInComponent},
  {path: 'Home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
