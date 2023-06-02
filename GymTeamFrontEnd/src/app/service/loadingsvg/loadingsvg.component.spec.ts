import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadingsvgComponent } from './loadingsvg.component';

describe('LoadingsvgComponent', () => {
  let component: LoadingsvgComponent;
  let fixture: ComponentFixture<LoadingsvgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoadingsvgComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoadingsvgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
