import {Component, Input, OnInit} from '@angular/core';
import {JobService} from "../../_services/job.service";

@Component({
  selector: 'app-profile-image',
  templateUrl: './profile-image.component.html',
  styleUrls: ['./profile-image.component.css']
})
export class ProfileImageComponent implements OnInit {

  @Input() imageId: number;
  public imageUrl: string;

  constructor(private jobService: JobService) {
  }

  ngOnInit(): void {
    if (this.imageId != null) {
      this.jobService.getImage(this.imageId).subscribe(blob => {
        this.imageUrl = URL.createObjectURL(blob);
      });
    }
  }
}
