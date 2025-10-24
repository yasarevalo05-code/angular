import { Component } from '@angular/core';
import { NgIf } from '@angular/common';


@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [NgIf],
  templateUrl: './welcome.html',
  styleUrls: ['./welcome.css']
})
export class Welcome {
 // Variables de texto
  message1: string = '✨ Bienvenido al Universo de Harry Potter ✨';
  message2: string = 'Solo los verdaderos magos pueden ver este mensaje secreto 🧙‍♂️';

  // Variable booleana
  showSecret: boolean = false;

}
