import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeedataComponent } from './employeedata.component';

describe('EmployeedataComponent', () => {
  let component: EmployeedataComponent;
  let fixture: ComponentFixture<EmployeedataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeedataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeedataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
