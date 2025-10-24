import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Spells {
  private spells = [
    { name: 'Lumos', description: 'Produce luz en la punta de la varita.'},
    { name: 'Alohomora', description: 'Abre puertas y cerraduras mágicas.'},
    { name: 'Expelliarmus', description: 'Desarma al oponente.'},
    { name: 'Expecto Patronum', description: 'Invoca un Patronus protector.'},
  ];

  constructor() {}

  getSpells() {
    return this.spells;
  }
}
