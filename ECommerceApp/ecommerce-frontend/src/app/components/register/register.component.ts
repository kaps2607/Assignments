import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { Register } from '../../models/register';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  newAccount:Register=new Register('','','','','');

  account?:Register[];


  constructor(private authservice:AuthService, private router:Router){}

  ngOnInit(){
    
  }

  registerUser(){
    this.authservice.register(this.newAccount).subscribe(res=>{
      alert("Registered Successfully!");
      if (!this.account) {
        this.account = []; 
      }
      this.account.push(res);
      this.router.navigate(['/']);
    })
  }

}
