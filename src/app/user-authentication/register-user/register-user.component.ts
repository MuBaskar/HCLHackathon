import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import {UserService} from '../services/user.service'
import {UserModel} from '../Models/UserModel'

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css'],
  providers:[UserModel,UserService]
})
export class RegisterUserComponent implements OnInit {
  registerForm: any;
  //userModel:any={}
  showPopup: boolean = false; // To control the popup visibility
  isSuccess: boolean = false;

  constructor(public fb:FormBuilder, public service:UserService,public userModel:UserModel) { }

  ngOnInit(): void {
    // Initialize the form with validation
    this.registerForm = this.fb.group({
      fullName: ['', [Validators.required]],
      email: ['',[Validators.required, Validators.email]],
      password: ['',[Validators.required, Validators.minLength(6)]],
      retypePassword: ['',[Validators.required]],
      mobile: new FormControl('', [
        Validators.required,
        Validators.pattern("^[0-9]{10}$") // Mobile number pattern (10 digits)
      ])
    }, this.passwordMatchValidator); // Custom validator for password match
  }

  // Custom Validator to check if passwords match
  passwordMatchValidator(form: FormGroup): { [key: string]: boolean } | null {
    const password = form.get('password')?.value;
    const retypePassword = form.get('retypePassword')?.value;
    return password && retypePassword && password !== retypePassword ? { passwordMismatch: true } : null;
  }

  // Handle form submission
  onSubmit() {
    if (this.registerForm.valid) {
      debugger
      console.log('Form Submitted:', this.registerForm.value);

      for(let key in this.registerForm.value){ 
        this.userModel[key as keyof UserModel] = this.registerForm.value[key]
      }
      console.log('Check this:', this.userModel);
      this.service.registerUser(this.userModel).subscribe((result:boolean)=>{
        debugger
        if(result){
          this.isSuccess = true; // If successful
          this.showPopup = true;
        }else{
          this.isSuccess = false; // If failed
          this.showPopup = true;
        }
      })


      // Here you would typically call a service to send form data to a backend
    } else {
      console.log('Form is invalid');
    }
  }
  close(){
    this.showPopup = false; 
  }
}