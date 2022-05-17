import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlbumService } from '../album.service';
import { IAlbum } from '../model/album';

@Component({
  selector: 'app-add-album',
  templateUrl: './add-album.component.html',
  styleUrls: ['./add-album.component.scss']
})
export class AddAlbumComponent implements OnInit {

  album: IAlbum = {
    UserId: 1,
    AlbumName: '',
    AlbumDescription: ''
  }
  album$: Observable<IAlbum[]> | undefined;

  constructor(private albumService: AlbumService, route: ActivatedRoute, private router: Router) 
  { 
  }

  ngOnInit(): void {
  }

  addAlbum(): void {
    this.albumService.addAlbum(this.album).subscribe(album => this.album == album);
    this.router.navigate(['view-albums']);
  }
}
