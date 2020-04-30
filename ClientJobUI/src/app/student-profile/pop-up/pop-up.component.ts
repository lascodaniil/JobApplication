import {Component, EventEmitter, Inject, OnInit, Optional, Output} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AddJobData} from '../../models/AddJobData';
import {PopUpData} from '../../models/PopUpData';
import {PaginatedRequest} from '../../models/PaginatedRequest';

@Component({
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css']
})
export class PopUpComponent implements OnInit {

  constructor( public dialogRef: MatDialogRef<PopUpComponent>, @Inject(MAT_DIALOG_DATA) public popup: PopUpData) { }
  @Output()
  onClick = new EventEmitter<boolean>();

  ngOnInit(): void {

  }

}
