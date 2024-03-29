import { CinemaRoomResponseV1 } from "../response/cinemaRoomResponseV1";
import { MovieResponseV1 } from "../response/movieResponseV1";

export class ReservationRequestV1 {
    reservationID!: number;
    names!: string;
    lastNames!: string;
    birthDate!: Date;
    gender!: string;
    dni!: string;
    email!: string;
    cinemaRoomID!: number;
    cinemaRoom!: CinemaRoomResponseV1;
    movieID!: number;
    movie!: MovieResponseV1;
    enabled!: boolean;
    createdDate!: Date | null;
    updateDate!: Date | null;
  }