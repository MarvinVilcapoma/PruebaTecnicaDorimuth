import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalViewSeePurchaseComponent } from './modal-view-see-purchase.component';

describe('ModalViewSeePurchaseComponent', () => {
  let component: ModalViewSeePurchaseComponent;
  let fixture: ComponentFixture<ModalViewSeePurchaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalViewSeePurchaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalViewSeePurchaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
