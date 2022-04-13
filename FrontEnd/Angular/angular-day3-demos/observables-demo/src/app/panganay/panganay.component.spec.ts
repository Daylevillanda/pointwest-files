import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PanganayComponent } from './panganay.component';

describe('PanganayComponent', () => {
  let component: PanganayComponent;
  let fixture: ComponentFixture<PanganayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PanganayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PanganayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
