import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


export interface Spell {
  name: string;
  description: string;

}
@Injectable({
  providedIn: 'root'
})
export class SpellsApi {
  private apiUrl = 'https://hp-api.onrender.com/api/spells';

  constructor(private http: HttpClient) {}

  // Método que devuelve los hechizos
  getSpells(): Observable<Spell[]> {
    return this.http.get<Spell[]>(this.apiUrl);
  }
}