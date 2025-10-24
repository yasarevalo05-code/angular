import { Routes } from '@angular/router';
import { Welcome } from './component/welcome/welcome';
import { CasasHogwarts } from './component/casas-hogwarts/casas-hogwarts';
import { SecretosCastillo } from './component/secretos-castillo/secretos-castillo';
import { SpellList } from './component/spell-list/spell-list';
import { TicketForm } from './component/ticket-form/ticket-form';

export const routes: Routes = [
  { path: '', redirectTo: 'welcome', pathMatch: 'full' },
  { path: 'welcome', component: Welcome },
  { path: 'casas', component: CasasHogwarts },
  { path: 'hechizos', component: SpellList }, 
  { path: 'secretos', component: SecretosCastillo },
  { path: 'expreso', component: TicketForm },

];
