import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Person } from '../person.model';
import { PersonService } from '../Services/person.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  myForm: FormGroup | any;
  personsList: Person[] = [];
  newPersonData: Person = new Person();
  constructor(private fb: FormBuilder, private personservice: PersonService) { }

  ngOnInit() {
    this.myForm = this.fb.group({
      firstname: ['', Validators.required],
      lastname: ['', [Validators.required]]
    });

    this.getdata();
  }

  onSubmit(form: FormGroup) {
    if (form.valid) {
      this.newPersonData.firstName = form.value.firstname;
      this.newPersonData.lastName = form.value.lastname;
      this.personservice.create(this.newPersonData).subscribe((res: any) => {
        console.log('Person Details added successfully!');
        this.getdata();
        form.reset();
      });
    }
  }

  getdata(){
    this.personservice.getAll().subscribe((data: Person[]) => {
      this.personsList = data;
      console.log(this.personsList);
    })
  }
}
