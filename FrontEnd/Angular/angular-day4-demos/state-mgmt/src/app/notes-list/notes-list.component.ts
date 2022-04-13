import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { Note } from '../models/note';
import { StateService } from '../state.service';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.css']
})
export class NotesListComponent {

  state: StateService;
  router: Router;
  notes$: BehaviorSubject<Note[]>;

  constructor(state: StateService, router: Router) {
    this.state = state;
    this.router = router;
    this.notes$ = state.notes$;
  }

  createNote() {
    let newNoteIndex = this.state.addNote();
    this.router.navigate([newNoteIndex]);
  }

}
