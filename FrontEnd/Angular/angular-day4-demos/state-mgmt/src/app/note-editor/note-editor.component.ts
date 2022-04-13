import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from '../models/note';
import { StateService } from '../state.service';

@Component({
  selector: 'app-note-editor',
  templateUrl: './note-editor.component.html',
  styleUrls: ['./note-editor.component.css']
})
export class NoteEditorComponent implements OnInit {

  state: StateService;
  router: Router;
  route: ActivatedRoute;
  id!: number;
  note: Note = {title: '', content: ''};

  constructor(state: StateService, router: Router, route: ActivatedRoute) {
    this.state = state;
    this.router = router;
    this.route = route;
  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id')!);
    this.note = this.state.notes$.value[this.id];
  }

  save() {
    this.state.updateNote(this.id, this.note);
    this.router.navigate(['/']);
  }

}
