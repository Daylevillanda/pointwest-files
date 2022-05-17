import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  selectedFile!: File;

  constructor(private http: HttpClient) {
  }

  onFileSelected(event: any){
    this.selectedFile = <File>event.target.files[0];
  }
  onUpload(){
    const filedata = new FormData();
    filedata.append('image', this.selectedFile, this.selectedFile.name);
    filedata.append('albumId', '1');
    this.http.post("https://localhost:44368/photos/upload", filedata).subscribe(res =>
    console.log(res));
  }

}
