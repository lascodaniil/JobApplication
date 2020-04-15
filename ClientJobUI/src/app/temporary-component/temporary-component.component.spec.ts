import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemporaryComponentComponent } from './temporary-component.component';

describe('TemporaryComponentComponent', () => {
  let component: TemporaryComponentComponent;
  let fixture: ComponentFixture<TemporaryComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemporaryComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemporaryComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
