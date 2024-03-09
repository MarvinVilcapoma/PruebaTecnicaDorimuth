import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ReservationRequestV1 } from '../models/request/reservationRequestV1';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  reservation(reservationRequestV1: ReservationRequestV1){
    return this.http.post<any>(`${environment.url}/Reservation/Reservation`,reservationRequestV1);
  }



}
