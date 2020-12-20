import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ByUserIdComponent } from './by-user-id.component';

describe('ByUserIdComponent', () => {
  let component: ByUserIdComponent;
  let fixture: ComponentFixture<ByUserIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ByUserIdComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ByUserIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
