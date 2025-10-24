import { Component, OnInit} from '@angular/core';
import { NgFor, NgClass } from '@angular/common';
import { Casas, Casa } from '../../services/casas';


@Component({
  selector: 'app-casas-hogwarts',
  standalone: true,
  imports: [NgFor, NgClass],
  templateUrl: './casas-hogwarts.html',
  styleUrls: ['./casas-hogwarts.css']
})
export class CasasHogwarts implements OnInit {
  casas: Casa[] = [];
  imagenActual: number[] = [];
  
  constructor(private casa: Casas) {}

  ngOnInit(): void {
    this.casas = this.casa.getCasas();
    this.imagenActual = new Array(this.casas.length).fill(0);

    // Cambia la imagen de cada casa cada 4 segundos
    setInterval(() => {
      this.casas.forEach((_, i) => {
        this.imagenActual[i] = (this.imagenActual[i] + 1) % 4; // 4 imágenes por casa
      });
    }, 4000);
  }
}