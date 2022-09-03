import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WishListTripItemLoadingComponent } from './wish-list-trip-item-loading.component';

describe('WishListTripItemLoadingComponent', () => {
  let component: WishListTripItemLoadingComponent;
  let fixture: ComponentFixture<WishListTripItemLoadingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WishListTripItemLoadingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WishListTripItemLoadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
