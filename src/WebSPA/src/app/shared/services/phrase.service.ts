import {Injectable} from '@angular/core';
import {Phrase} from "@core/interfaces/phrase.interface";
import { HttpClient } from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class PhraseService {
  private URL = 'https://webapi-phraseoftheday.azurewebsites.net/api';
  // private URL = 'https://localhost:7114/api';

  constructor(private httpClient: HttpClient) {
  }
  getPhrase(): Observable<Phrase> {
    return this.httpClient.get<Phrase>(
      `${this.URL}/phrase`
    )
  }

}
