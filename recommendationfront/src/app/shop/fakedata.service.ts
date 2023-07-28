import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product, ResponseProduct } from './models/product';
import { environment } from 'src/environments/environment.prod';
import {Md5} from 'ts-md5';

@Injectable({
  providedIn: 'root'
})
export class FakedataService {

  constructor(private http: HttpClient) {
  
  }

  

  
  getProducts():Observable<ResponseProduct> {

    const url = environment.API + '/products/';

    return this.http.get<ResponseProduct>(url);
  }
}
