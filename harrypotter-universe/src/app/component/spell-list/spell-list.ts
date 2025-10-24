import { Component, OnInit } from '@angular/core';
import { SpellItem } from '../spell-item/spell-item';
import { NgFor, NgIf } from '@angular/common';
import { Spells } from '../../services/spells';
import { SpellsApi } from '../../services/spells-api';
import { Spell } from '../../services/spells-api';

@Component({
  selector: 'app-spell-list',
  standalone: true,
  imports: [NgFor, NgIf, SpellItem],
  templateUrl: './spell-list.html',
  styleUrl: './spell-list.css'
})
export class SpellList implements OnInit {
  //uso del servicio spell (los hechizos)
  spells: Spell[] = [];
  selectedSpell: string = '';
  showMagic = false;

  // Inyectamos el servicio en el constructor
  constructor(private spellsService: Spells,
        private spellsApi: SpellsApi

  ) {}

  ngOnInit(): void {
    // 1 Hechizos locales
    this.spells = this.spellsService.getSpells();
  
    // 2 Hechizos desde la API
    this.spellsApi.getSpells().subscribe((apiSpells: Spell[]) => {
      console.log('Hechizos de la API:', apiSpells);
      this.spells = [...this.spells, ...apiSpells];
    });
  }

  onSpellSelected(spellName: string) {
    this.selectedSpell = spellName;
      this.showMagic = true;

      setTimeout(() => {
    this.showMagic = false;
  }, 1000);
}

closeSpell() {
  this.selectedSpell = '';
}
}

