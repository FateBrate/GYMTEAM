import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLocationComponent } from './admin-location.component';

describe('AdminLocationComponent', () => {
  let component: AdminLocationComponent;
  let fixture: ComponentFixture<AdminLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminLocationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
