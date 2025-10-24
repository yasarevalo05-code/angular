import { Component, Input, Output, EventEmitter } from '@angular/core';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-spell-item',
  standalone: true,
  imports: [NgIf],
  templateUrl: './spell-item.html',
  styleUrl: './spell-item.css'
})
export class SpellItem {
  @Input() spell!: { name: string, description: string };
  @Output() spellSelected = new EventEmitter<string>();

  selectSpell() {
    this.spellSelected.emit(this.spell.name);
  }
}
