import { Injectable } from '@angular/core';


export interface Casa {
  nombre: string;
  fundador: string;
  cualidades: string[];
  lider: string;   
  lema: string;         
  animal: string;
  logo: string;
  imagenes: string[];
}

@Injectable({
  providedIn: 'root'
})
export class Casas {
  private casas: Casa[] = [
    {
      nombre: 'Gryffindor',
      fundador: 'Godric Gryffindor',
      cualidades: ['Valentía, coraje, determinación, caballerosidad y sentido de la justicia'],
      lider: 'Minerva McGonagall',
      lema:'Valor y honor ante todo',
      animal: '🦁 León',
      logo: 'recursos/casa1.png',
      imagenes: [
        'recursos/casaG1.webp',
        'recursos/casaG2.jpg',
        'recursos/casaG3.jpg',
        'recursos/casaG4.jpg'

      ]
    },
    {
      nombre: 'Slytherin',
      fundador: 'Salazar Slytherin',
      cualidades: ['Ambición, astucia, ingenio, liderazgo y determinación'],
      lider: 'Severus Snape',
      lema:'El fin justifica los medios',
      animal: '🐍 Serpiente',
      logo: 'recursos/casa2.png',
      imagenes: [
        'recursos/casaS1.jpg',
        'recursos/casaS2.jpg',
        'recursos/casaS3.jpg',
        'recursos/casaS4.jpg'

      ]
    },
    {
      nombre: 'Ravenclaw',
      fundador: 'Rowena Ravenclaw',
      cualidades:['Inteligencia, creatividad, sabiduría, ingenio y aprendizaje'],
      lider: 'Filius Flitwick',
      lema:'La inteligencia es nuestra fortaleza',
      animal: '🦅 cuervo',
      logo: 'recursos/casa3.png',
      imagenes: [
        'recursos/casaR1.jpg',
        'recursos/casaR2.jpg',
        'recursos/casaR3.jpg',
        'recursos/casaR4.jpg'
      ]
    },
    {
      nombre: 'Hufflepuff',
      fundador: 'Helga Hufflepuff',
      cualidades:['Lealtad, trabajo duro, paciencia, justicia y honestidad'],
      lider: 'Pomona Sprout',
      lema:'Lealtad y paciencia son recompensadas',
      animal: '🦡 Tejón',
      logo: 'recursos/casa4.png',
      imagenes: [
        'recursos/casaH1.jpg',
        'recursos/casaH2.jpg',
        'recursos/casaH3.jpg',
        'recursos/casaH4.jpg'
      ]
    }
      ];
  constructor() { }

  getCasas(): Casa[] {
    return this.casas;
  }
}
