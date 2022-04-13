import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NoteEditorComponent } from './note-editor/note-editor.component';
import { NotesListComponent } from './notes-list/notes-list.component';

const routes: Routes = [
  {path: '', component: NotesListComponent, pathMatch: 'full'},
  {path: ':id', component: NoteEditorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
