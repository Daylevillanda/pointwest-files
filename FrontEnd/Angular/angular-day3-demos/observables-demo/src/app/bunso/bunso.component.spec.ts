import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BunsoComponent } from './bunso.component';

describe('BunsoComponent', () => {
  let component: BunsoComponent;
  let fixture: ComponentFixture<BunsoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BunsoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BunsoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
