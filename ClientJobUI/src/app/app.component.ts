import {Component, OnInit} from '@angular/core';
import {ToolBarService} from './services/toolbar.service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Job App';
  constructor(private toolBarService: ToolBarService) {
  }

  ngOnInit() {
    this.toolBarService.getTitle().subscribe((title: string) => {
      this.title = title;
    });
  }

}
