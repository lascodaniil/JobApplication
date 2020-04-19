import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormBuilder,FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { RegisterService } from '../services/register.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  title: string;
  token: string;
  form:FormGroup;
  Username : string;
  Email : string;
  Password :string;
  DisplayName : string;
  SelectedRole: string;
  roles: string[] = ['Employer','Employee'];
  
  constructor(private router: Router,
      private fb: FormBuilder,
      private http: HttpClient, private RegisterService: RegisterService
     ) {

      this.title = "New User Registration";

      // initialize the form
      this.createForm();

  }

  createForm() {
      this.form = this.fb.group({
          Username: ['', Validators.required],
          Email: ['',
              [Validators.required,
              Validators.email]
          ],
          Password: ['', Validators.required],
          PasswordConfirm: ['', Validators.required],
          DisplayName: ['', Validators.required]
      }, {
          validator: this.passwordConfirmValidator
      });
  }

  onSubmit() {
     
      
     this.Username = this.form.value.Username;
     this.Email = this.form.value.Email;
     this.Password = this.form.value.Password;
     this.DisplayName = this.form.value.DisplayName;
     
      
      this.RegisterService.registerUser( this.Username, this.Email,this.Password,this.SelectedRole)
      .subscribe(x=>{this.token=x.accessToken; this.RegisterService.tokenObject = this.token; console.log(this.RegisterService.tokenObject); localStorage.setItem('accessToken', this.RegisterService.tokenObject)})

  }

  onBack() {
      this.router.navigate(["home"]);
  }

  passwordConfirmValidator(control: FormControl):any {

      let p = control.root.get('Password');
      let pc = control.root.get('PasswordConfirm');

      if (p && pc) {
          if (p.value !== pc.value) {
              pc.setErrors(
                  { "PasswordMismatch": true }
              );
          }
          else {
              pc.setErrors(null);
          }
      }
      return null;
  }

  // retrieve a FormControl
  getFormControl(name: string) {
      return this.form.get(name);
  }

  // returns TRUE if the FormControl is valid
  isValid(name: string) {
      var e = this.getFormControl(name);
      return e && e.valid;
  }

  // returns TRUE if the FormControl has been changed
  isChanged(name: string) {
      var e = this.getFormControl(name);
      return e && (e.dirty || e.touched);
  }

  // returns TRUE if the FormControl is invalid after user changes
  hasError(name: string) {
      var e = this.getFormControl(name);
      return e && (e.dirty || e.touched) && !e.valid;
  }
}
