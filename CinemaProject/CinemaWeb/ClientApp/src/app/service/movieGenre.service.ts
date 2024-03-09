import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieGenreService {

  constructor(private http: HttpClient) { }

  getMovieGenres(){
    return this.http.get<any>(`${environment.url}/MovieGenre/GetMovieGenres`);
  }



}
