import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FbFormComponent } from './fb-form.component';

describe('FbFormComponent', () => {
  let component: FbFormComponent;
  let fixture: ComponentFixture<FbFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FbFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FbFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
