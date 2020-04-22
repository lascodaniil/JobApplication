import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryChildComponentComponent } from './category-child-component.component';

describe('CategoryChildComponentComponent', () => {
  let component: CategoryChildComponentComponent;
  let fixture: ComponentFixture<CategoryChildComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoryChildComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryChildComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
