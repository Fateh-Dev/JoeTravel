import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuideItemLoadingComponent } from './guide-item-loading.component';

describe('GuideItemLoadingComponent', () => {
  let component: GuideItemLoadingComponent;
  let fixture: ComponentFixture<GuideItemLoadingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GuideItemLoadingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GuideItemLoadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
