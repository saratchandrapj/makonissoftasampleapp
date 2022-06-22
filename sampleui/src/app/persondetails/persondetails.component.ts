import { Component, Input, OnInit } from '@angular/core';
import { Person } from '../person.model';

@Component({
  selector: 'app-persondetails',
  templateUrl: './persondetails.component.html',
  styleUrls: ['./persondetails.component.css']
})
export class PersondetailsComponent implements OnInit {
  @Input() data : Person[] = [];
  constructor() {
    console.log(this.data);
   }

  ngOnInit(): void {
  }

}
