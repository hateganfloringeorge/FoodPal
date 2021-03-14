import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthenticatedGuard implements CanActivate {
  constructor(private router:Router) { }

  canActivate(
    route: ActivatedRouteSnapshot
    ): boolean {
    const isLoggedIn = !!localStorage.getItem('isLoggedIn');
    if (!isLoggedIn) {
      this.router.navigate(['/login']);
    }
    return isLoggedIn;
  }
  
}
