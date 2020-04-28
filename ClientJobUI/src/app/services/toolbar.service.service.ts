import {Injectable} from '@angular/core';
import {Subject} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ToolBarService {
  title = new Subject();

  setTitle(title: string) {
    this.title.next(title);
  }

  getTitle() {
    return this.title.asObservable();
  }
}
