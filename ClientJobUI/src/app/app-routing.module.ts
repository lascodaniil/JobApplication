import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {JobComponent} from './job/job.component';
import {RegistrationFormComponent} from './registration/registration-form.component';
import {SignInComponent} from './sign-in/sign-in.component';
import {UserProfileComponent} from './user-profile/user-profile.component';
import {HomeComponent} from './home/home.component';
import {EditProfileComponent} from './edit-profile/edit-profile.component';
import {AuthGuardService} from "./_services/auth-guard.service";


const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'jobs', component: JobComponent},
  {path: 'jobs/:id', component: JobComponent},
  {path: 'register', component: RegistrationFormComponent},
  {path: 'profile', component: UserProfileComponent, canActivate: [AuthGuardService]},
  {path: 'sign-in', component: SignInComponent},
  {path: 'edit', component: EditProfileComponent, canActivate: [AuthGuardService]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
