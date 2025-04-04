import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    console.log("Login function called"); // Debugging log
    this.authService.login(this.email, this.password).subscribe(
      (response: any) => {

        console.log('Login successful:', response);
        localStorage.setItem('token', response.token); 
        localStorage.setItem('email',response.email);
        alert('Login successful');
        this.router.navigate(['/products']); 
      },
      (error: any) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Invalid credentials. Please try again.';
      }
    );
  }
}
