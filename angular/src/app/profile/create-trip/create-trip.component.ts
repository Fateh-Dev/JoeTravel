import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-trip',
  templateUrl: './create-trip.component.html',
  styleUrls: ['./create-trip.component.scss']
})
export class CreateTripComponent implements OnInit {
  email = new FormControl('', [Validators.required, Validators.email]);
  TripForm: FormGroup;
  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }
  constructor(public fb: FormBuilder) { }

  ngOnInit(): void {
    this.InitTripForm()
  }
  InitTripForm() {
    this.TripForm = this.fb.group(
      {
        title: ['', Validators.required],
        description: ['', Validators.required],
        rating: ['', Validators.required],
        duration: ['', Validators.required],
        glanguages: ['', Validators.required],
        difficulty: ['', Validators.required],
        tripSize: ['', Validators.required],
        thumbnailUrl: ['']
      }
    )
  }

  submit() {
    console.log(this.TripForm.value)
  }

}
