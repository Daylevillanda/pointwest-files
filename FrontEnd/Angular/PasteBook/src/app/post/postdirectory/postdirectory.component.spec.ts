import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostdirectoryComponent } from './postdirectory.component';

describe('PostdirectoryComponent', () => {
  let component: PostdirectoryComponent;
  let fixture: ComponentFixture<PostdirectoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostdirectoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostdirectoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
