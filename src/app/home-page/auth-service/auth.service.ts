import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import {jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'authToken'; // LocalStorage key for storing the token

  constructor(private router: Router) {}

  // Get the stored token
  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  // Decode JWT token
  getDecodedToken(): any {
    const token = this.getToken();
    return token ? jwtDecode(token) : null;
  }

  // Get token expiration date
  getTokenExpiration(): Date | null {
    const decodedToken = this.getDecodedToken();
    if (decodedToken && decodedToken.exp) {
      return new Date(decodedToken.exp * 1000); // Convert to milliseconds
    }
    return null;
  }

  // Check if token is expired
  isTokenExpired(): boolean {
    const expiry = this.getTokenExpiration();
    return expiry ? new Date() > expiry : true;
  }

  // Check if user is authenticated
  isAuthenticated(): boolean {
    const token = this.getToken();
    return token !== null && !this.isTokenExpired();
  }

  // Logout user
  logout() {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }
}
