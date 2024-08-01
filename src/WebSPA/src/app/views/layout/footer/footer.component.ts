import {Component, OnInit} from '@angular/core';
import {PhraseService} from "@shared/services/phrase.service";
import {Observable} from "rxjs";
import {Phrase} from "@core/interfaces/phrase.interface";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styles: [
  ]
})
export class FooterComponent{
  /*phrase!:Phrase;
  phrase$:Observable<Phrase> = this.phraseService.getPhrase();
  constructor(private phraseService:PhraseService) {
    this.getPhrase();
  }
  getPhrase(){
    this.phraseService.getPhrase().subscribe(
      (response) => {
        this.phrase = response;
      });
  }*/

}
