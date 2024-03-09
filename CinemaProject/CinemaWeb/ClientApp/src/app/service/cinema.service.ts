import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CinemaService {

  constructor(private http: HttpClient) { }

  getCinemas(){
    return this.http.get<any>(`${environment.url}/Cinema/GetCinemas`);
  }
}
