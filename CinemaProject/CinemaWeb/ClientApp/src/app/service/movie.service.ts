import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { MovieSearchRequestV1 } from '../models/request/movieSearchRequestV1';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies(){
    return this.http.get<any>(`${environment.url}/Movie/GetMovies`);
  }

  getMovieByID(ID: number){
    return this.http.get<any>(`${environment.url}/Movie/GetMovieById/${ID}`);
  }

  searchMovie(movieSearchRequestV1: MovieSearchRequestV1){
    return this.http.post<any>(`${environment.url}/Movie/SearchMovie`, movieSearchRequestV1);
  }

}
