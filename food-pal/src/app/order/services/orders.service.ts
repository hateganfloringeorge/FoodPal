import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
//import { CatalogueItem } from "../models/catalogue-item";
import { Provider } from "../models/provider";

@Injectable()
export class ProvidersService {
    
    constructor(private http: HttpClient) {}
    
    // getCatalogueItems(id: number): Observable<Array<CatalogueItem>>{
    //   return this.http.get<Array<CatalogueItem>>(
    //       `http://localhost:5000/api/providers/${id}/menu`
    //   );
    // }

    getProviderWithCatalogue(id: number): Observable<Provider>{
        return this.http.get<Provider>(
            `http://localhost:5000/api/providers/${id}?includeCatalogueItems=true`
        );
      }

    getAllProviders(): Observable<Array<Provider>> {
        return this.http.get<Array<Provider>>(
            'http://localhost:5000/api/providers'
        );
    }
}