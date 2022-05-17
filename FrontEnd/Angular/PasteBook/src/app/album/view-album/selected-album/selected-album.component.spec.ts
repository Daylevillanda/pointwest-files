import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedAlbumComponent } from './selected-album.component';

describe('SelectedAlbumComponent', () => {
  let component: SelectedAlbumComponent;
  let fixture: ComponentFixture<SelectedAlbumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectedAlbumComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedAlbumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
