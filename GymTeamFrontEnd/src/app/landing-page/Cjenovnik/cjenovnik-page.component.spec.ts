import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CjenovnikPageComponent } from './cjenovnik-page.component';

describe('LandingPageComponent', () => {
  let component: CjenovnikPageComponent;
  let fixture: ComponentFixture<CjenovnikPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CjenovnikPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CjenovnikPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
