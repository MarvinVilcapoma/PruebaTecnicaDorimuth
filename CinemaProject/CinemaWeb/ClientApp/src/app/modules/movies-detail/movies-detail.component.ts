import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CinemaResponseV1 } from 'src/app/models/response/cinemaResponseV1';
import { MovieResponseV1 } from 'src/app/models/response/movieResponseV1';
import { ScreeningResponseV1 } from 'src/app/models/response/screeningResponseV1';
import { CinemaService } from 'src/app/service/cinema.service';
import { MovieService } from 'src/app/service/movie.service';
import { ScreeningService } from 'src/app/service/screening.service';
import { ModalShopComponent } from 'src/app/shared/modal-shop/modal-shop.component';
import { MatDialog } from '@angular/material/dialog';
import { ReservationRequestV1 } from 'src/app/models/request/reservationRequestV1';
import { ReservationService } from 'src/app/service/reservation.service';
import { ModalViewSeePurchaseComponent } from 'src/app/shared/modal-view-see-purchase/modal-view-see-purchase.component';

@Component({
  selector: 'app-movies-detail',
  templateUrl: './movies-detail.component.html',
  styleUrls: ['./movies-detail.component.scss']
})
export class MoviesDetailComponent implements OnInit {

  movieDetail!: MovieResponseV1;
  cinemas: CinemaResponseV1[] = [];
  screenings: ScreeningResponseV1[] = [];
  movieID!: number;
  selectedCinema: number | null = null;
  selectedCinemaRoom: number | null = null;
  selectedCinemaRooms: { [cinemaID: number]: number | null } = {};

  reservationRequestV1: ReservationRequestV1 = new ReservationRequestV1();

  constructor(public route: ActivatedRoute, public movieService: MovieService, public cinemaService: CinemaService, public screeningService: ScreeningService, public dialog: MatDialog,
    public reservationService: ReservationService) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(parameter => {
      const paramId = parameter['id'];
      this.movieID = paramId;
      this.movieService.getMovieByID(paramId).subscribe((res) => {
        this.movieDetail = res;
        console.log(this.movieDetail);
      });
    });

    this.cinemaService.getCinemas().subscribe((res) => {
      this.cinemas = res;
      console.log(this.cinemas);
    });
  }

  formatMinutesToHoursAndMinutes(minutes: number) {
    if (isNaN(minutes) || minutes < 0) {
      return "Invalid input";
    }

    const hours = Math.floor(minutes / 60);
    const remainingMinutes = minutes % 60;

    const formattedTime = `${hours}h ${remainingMinutes}min`;

    return formattedTime;
  }

getScreetings(cinemaID: number) {
  this.screeningService.getScreeningByMovieAndCinema(cinemaID, this.movieDetail.movieID).subscribe((res) => {
    if (res != null) {
      this.screenings = res;
    } else {
      this.screenings = [];
    }
  });
}

  toggleCinema(cinemaID: number) {
    this.selectedCinema = (this.selectedCinema === cinemaID) ? null : cinemaID;
  }

  isCinemaOpen(cinemaID: number) {
    return this.selectedCinema === cinemaID;
  }

  toggleCinemaRoom(cinemaRoomID: number) {
    const cinemaID = this.selectedCinema;
    this.selectedCinemaRooms[cinemaID!] = (this.selectedCinemaRooms[cinemaID!] === cinemaRoomID) ? null : cinemaRoomID;
    this.getScreetings(cinemaRoomID);
}

  isCinemaRoomOpen(cinemaRoomID: number) {
    const cinemaID = this.selectedCinema; 
    return this.selectedCinemaRooms[cinemaID!] === cinemaRoomID;
}

openPurchaseModal(cinemaRoomID: number): void {
  const dialogRef = this.dialog.open(ModalShopComponent, {
    width: '400px',
    data: { }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.reservationRequestV1.names = result.nombres;
      this.reservationRequestV1.lastNames = result.apellidos;
      this.reservationRequestV1.birthDate = result.birthday;
      this.reservationRequestV1.gender = result.gender;
      this.reservationRequestV1.dni = result.dni;
      this.reservationRequestV1.email = result.email;
      this.reservationRequestV1.movieID = this.movieID;
      this.reservationRequestV1.cinemaRoomID = cinemaRoomID

      this.reservationService.reservation(this.reservationRequestV1).subscribe((res)=>{
        const confirmationDialogRef = this.dialog.open(ModalViewSeePurchaseComponent, {
          width: '400px',
          data: res, 
        });
  
        confirmationDialogRef.afterClosed().subscribe(() => {
          
        });
      })
    }
  });
}
  
}
