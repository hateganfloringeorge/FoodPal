import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Provider } from '../models/provider';

@Injectable()
export class ProvidersService {
  constructor(private http: HttpClient) {}

  getAllProviders(): Observable<Array<Provider>> {
    return this.http.get<Array<Provider>>(
      'http://localhost:5000/api/providers'
    );
  }
}