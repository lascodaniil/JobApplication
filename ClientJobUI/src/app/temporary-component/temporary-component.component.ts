import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from
'@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-temporary-component',
  templateUrl: './temporary-component.component.html',
  styleUrls: ['./temporary-component.component.css']
})
export class TemporaryComponentComponent implements OnInit {


  title:string;
  quiz:Quiz;
  form: FormGroup;
  constructor(private activatedRoute: ActivatedRoute,
    private router:Router,
    private http:HttpClient,
    private fb: FormBuilder) { }

  ngOnInit(): void {

  }

}
