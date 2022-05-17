import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlbumService } from '../album.service';
import { IAlbum } from '../model/album';

@Component({
  selector: 'app-view-album',
  templateUrl: './view-album.component.html',
  styleUrls: ['./view-album.component.scss']
})
export class ViewAlbumComponent implements OnInit {

  albums: IAlbum | any = [];

  album$: Observable<IAlbum[]> | undefined;

  constructor(private albumService: AlbumService, route: ActivatedRoute, private router: Router) 
  { 
  }

  ngOnInit(): void {
    this.albumService.getAllAlbums().subscribe(albums => {
      this.albums = albums;
      });
  }

  deleteAlbum(id: number): void{
    this.albumService.delete(id).subscribe(albums => this.albums == albums);
    this.router.navigate(['view-albums']);
  }
}
