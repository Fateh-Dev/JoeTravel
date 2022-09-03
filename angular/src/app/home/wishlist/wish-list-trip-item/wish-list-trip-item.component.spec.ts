import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WishListTripItemComponent } from './wish-list-trip-item.component';

describe('WishListTripItemComponent', () => {
  let component: WishListTripItemComponent;
  let fixture: ComponentFixture<WishListTripItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WishListTripItemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WishListTripItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
