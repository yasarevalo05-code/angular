import { Component } from '@angular/core';


@Component({
  selector: 'app-secretos-castillo',
  standalone: true,
  imports: [],
  templateUrl: './secretos-castillo.html',
  styleUrl: './secretos-castillo.css'
})
export class SecretosCastillo{
  secretos = {
    nombre: {
    valor: 'Las Reliquias de la Muerte',
    descripcion: 'Tres objetos mágicos muy poderosos: Varita de Saúco, Piedra de la Resurrección y Capa de Invisibilidad.'
  },
  creador: {
    valor: 'Antiguos magos legendarios',
    historia: 'Fueron creadas por los hermanos Peverell hace siglos.'
  },
  material: {
    valor: 'Oro, piedra y tela encantada',
    curiosidad: 'Cada material tiene propiedades mágicas únicas.'
  },
  poder: {
    valor: 'Control sobre la vida y la muerte',
    ejemplo: 'La Varita de Saúco aumenta el poder del mago, la Capa de Invisibilidad protege de la muerte, y la Piedra de la Resurrección puede invocar sombras de los fallecidos.'
  },
  video: '/recursos/ReliquiasDeLaMuerte.mp4'
  };
}