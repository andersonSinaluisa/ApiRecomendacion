import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.prod';
import { AttrEntity, Entity } from './models/entity';
import { Observable } from 'rxjs';
import { ProfileCreate } from './models/profile';

@Injectable({
  providedIn: 'root'
})
export class RecomendationService {

  url:string = environment.API_RECOMMENDATION;

  constructor(private http: HttpClient) {
    
  }

  syncProducts(data:Entity[]):Observable<Entity[]> {
    return this.http.post<Entity[]>(this.url + '/core/entity/many', data,{
      headers: {
        Authorization: 'Bearer ' + this.getToken()
      }
    });
    
  }

  login(username:string, password:string):Observable<any> {
    return this.http.post<any>(this.url + '/auth/login', {username: username, password: password});
  }

  setToken(token:string) {
    //guardar el token en algun lugar seguro
    sessionStorage.setItem('token', token);
  }

  getToken():string {
    return sessionStorage.getItem('token') ?? '';
  }

  getProducts():Observable<Entity[]> {
    return this.http.get<Entity[]>(this.url + '/core/entity',{
      headers: {
        Authorization: 'Bearer ' + this.getToken()
      }
    });
    
  }

  createProfile(ProfileCreate:ProfileCreate):Observable<any> {
    return this.http.post<any>(this.url + '/profile', ProfileCreate, {
      headers: {
        Authorization: 'Bearer ' + this.getToken()
      }
    });
  }

  setProfileId(profileId:string) {
    sessionStorage.setItem('profileId', profileId);
  }

  getProfileId():string {
    return sessionStorage.getItem('profileId') ?? '';
  }

  train(profileId:string):Observable<AttrEntity[]> {
    return this.http.get<AttrEntity[]>(this.url + '/profile/' + profileId + '/train', {
      headers: {
        Authorization: 'Bearer ' + this.getToken()
      }
    });
  }

  recommender(profileId:string):Observable<AttrEntity[]> {
    return this.http.get<AttrEntity[]>(this.url + '/profile/' + profileId + '/recommender', {
      headers: {
        Authorization: 'Bearer ' + this.getToken()
      }
    });
  }

  
}
