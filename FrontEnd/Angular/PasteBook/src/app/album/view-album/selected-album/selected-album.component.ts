import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumService } from '../../album.service';
import { IAlbum } from '../../model/album';
import { IPhoto } from './photo/model/photo';
import { PhotoService } from './photo/photo.service';

@Component({
  selector: 'app-selected-album',
  templateUrl: './selected-album.component.html',
  styleUrls: ['./selected-album.component.scss']
})
export class SelectedAlbumComponent implements OnInit {

  
  album: IAlbum | any = [];
  photo: IPhoto = {
    AlbumId: 5
  };

  id: number = 0;
  route: ActivatedRoute;
  isEdit: boolean;
  selectedFile: File | any =  null;

  constructor(private albumService: AlbumService, private photoService: PhotoService,
    route: ActivatedRoute, private router: Router, private http: HttpClient) {
    this.route = route;
    this.isEdit = false;
   }

  ngOnInit(): void{
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.albumService.getAlbum(this.id).subscribe(album => {
      this.album = album;
      });
  }

  cancel(){
    this.ngOnInit();
    this.isEdit = false;
    this.router.navigate([`view-albums/${this.id}`]);
  }

  updateAlbum(){
    this.isEdit = true;
    this.ngOnInit();
  }

  saveAlbum(){
    this.albumService.update(this.id, this.album).subscribe(album => this.album == album);
    this.isEdit = false;
    this.router.navigate([`view-albums/${this.id}`]);
  }

  onFileSelected(event: any){
    this.selectedFile = <File>event.target.files[0];
  }

  onUpload(){
    const fileData = new FormData();
    fileData.append('image',this.selectedFile, this.selectedFile.name);
    
    //this.photoService.addPhoto(fileData).subscribe(photo => this.photo == photo);

    // this.http.post('https://localhost:44368/photos', fileData ).subscribe((response) => {
    //             console.log(response);
    //         });
   }

//   onUpload() {
//     console.log(this.selectedFile);
//     this.photoService.addPhoto(this.selectedFile).subscribe(
//         (event: any) => {
//             if (typeof (event) === 'object') {

//                 // Short link via api response
//                 //this.shortLink = event.link;

//                 //this.loading = false; // Flag variable 
//             }
//         }
//     );
// }

}
