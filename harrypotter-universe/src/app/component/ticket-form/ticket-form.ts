import { Component} from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ticket-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './ticket-form.html',
  styleUrl: './ticket-form.css'
})
export class TicketForm {
  ticketForm = new FormGroup({
    adultTickets: new FormControl(0),
    childTickets: new FormControl(0),
    passengerName: new FormControl('') // nombre del pasajero
  });

  totalTickets = 0;
  showTicket = false;
  travelDate = new Date().toLocaleDateString();

  calculateTotal() {
    const adults = this.ticketForm.get('adultTickets')?.value || 0;
    const children = this.ticketForm.get('childTickets')?.value || 0;
    this.totalTickets = Number(adults) + Number(children);
    this.showTicket = false;
  }

  displayTicket() {
    this.showTicket = true; // mostrar ticket
  }
}