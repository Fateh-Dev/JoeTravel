import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TripItemLoadingComponent } from './trip-item-loading.component';

describe('TripItemLoadingComponent', () => {
  let component: TripItemLoadingComponent;
  let fixture: ComponentFixture<TripItemLoadingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TripItemLoadingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TripItemLoadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
