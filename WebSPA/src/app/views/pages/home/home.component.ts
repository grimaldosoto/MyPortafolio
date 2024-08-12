import { Component } from '@angular/core';
import {Phrase} from "@core/interfaces/phrase.interface";
import {PhraseService} from "@shared/services/phrase.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent {
  phrase!: Phrase;

  constructor(private phraseService:PhraseService) {
    this.getPhrase();
  }

  getPhrase(){
    this.phraseService.getPhrase().subscribe(
      (response: Phrase) =>{
        this.phrase = response
      }
    )
  }
}
