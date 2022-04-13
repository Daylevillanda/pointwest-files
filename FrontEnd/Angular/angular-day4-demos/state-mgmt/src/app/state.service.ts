import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Note } from './models/note';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  notes$ = new BehaviorSubject<Note[]>([
    {title: 'Hello World', content: 'Hello world lalalala'}
  ]);

  addNote() {
    let notes = this.notes$.value;
    notes.push({title: 'New Note', content: 'Enter text here'});
    this.notes$.next(notes);
    return notes.length - 1;
  }

  updateNote(id: number, note: Note) {
    let notes = this.notes$.value;
    notes[id] = note;
    this.notes$.next(notes);
  }

}
