import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Note } from '../models/note';
import { StateService } from '../state.service';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.css']
})
export class NotesListComponent implements OnInit {

  state: StateService;
  router: Router;
  notes!: Note[];

  constructor(state: StateService, router: Router) {
    this.state = state;
    this.router = router;
  }

  ngOnInit(): void {
    this.state.notes$.subscribe(notes => {
      this.notes = notes;
    });
  }

  createNote() {
    let newNoteIndex = this.state.addNote();
    this.router.navigate([newNoteIndex]);
  }

}
