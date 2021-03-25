import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable()
export class UsersService {

  userRootUrl = "https://localhost:44395/api/User";
  
  constructor(private http: HttpClient) {}

  postUser(user: User): Observable<any> {
    console.log(`${this.userRootUrl}`);
    console.log(user);
    return this.http.post<User>(
      `${this.userRootUrl}`, user
    );
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(
      `${this.userRootUrl}`
    ).pipe(
      catchError(this.errorHandler)
  );
  }

  errorHandler(error: HttpErrorResponse) {
    return Observable.throw(error.message || "server error.");
  }
}