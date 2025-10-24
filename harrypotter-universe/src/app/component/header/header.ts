import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router'

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule,RouterLink, RouterLinkActive],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {
menuItems = [
    { label: 'Inicio', link: '/welcome' },
    { label: 'Casas', link: '/casas' },
    { label: 'Hechizos', link: '/hechizos' },
    { label: 'Secretos', link: '/secretos' },
    { label: 'Expreso', link: '/expreso' }
  ];
}
