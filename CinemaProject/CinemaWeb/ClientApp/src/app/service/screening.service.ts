import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  constructor(private http: HttpClient) { }

  getScreenings(){
    return this.http.get<any>(`${environment.url}/Screening/GetScreenings`);
  }

  getScreeningByMovieAndCinema(cinemaRoomID: number, movieID: number){
    return this.http.get<any>(`${environment.url}/Screening/GetScreeningByMovieAndCinema/${cinemaRoomID}/${movieID}`);
  }


}
