import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {JobService} from "../../_services/job.service";

@Component({
  selector: 'app-job-image',
  templateUrl: './job-image.component.html',
  styleUrls: ['./job-image.component.css']
})
export class JobImageComponent implements OnInit, OnDestroy {

  @Input() imageId: number;
  public imageUrl: string;

  constructor(private jobService: JobService) {
  }

  ngOnInit(): void {
    if (this.imageId != null) {
      this.jobService.getImage(this.imageId).subscribe(blob => {
        this.imageUrl = URL.createObjectURL(blob);
      }, () => {
        this.imageUrl = 'https://user-images.githubusercontent.com/194400/49531010-48dad180-f8b1-11e8-8d89-1e61320e1d82.png';
      });
    } else {
      this.imageUrl = 'https://user-images.githubusercontent.com/194400/49531010-48dad180-f8b1-11e8-8d89-1e61320e1d82.png';
    }
  }

  ngOnDestroy(): void {
    URL.revokeObjectURL(this.imageUrl);
  }
}
