import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LokacijePageComponent } from './lokacije-page.component';

describe('LandingPageComponent', () => {
  let component: LokacijePageComponent;
  let fixture: ComponentFixture<LokacijePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LokacijePageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LokacijePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
