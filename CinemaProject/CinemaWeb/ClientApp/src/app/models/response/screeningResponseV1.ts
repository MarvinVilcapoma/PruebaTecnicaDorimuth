import { CinemaResponseV1 } from "./cinemaResponseV1";
import { CinemaRoomResponseV1 } from "./cinemaRoomResponseV1";
import { MovieResponseV1 } from "./movieResponseV1";

export class ScreeningResponseV1 {
    screeningID!:number;
    movieID!:number;
    movie!: MovieResponseV1
    cinemaRoomID!: number;
    cinemaRoom!: CinemaRoomResponseV1;
    startDateScreening!: Date;
    endDateScreening!: Date;
    enabled!:boolean;
    createdDate!: Date;
    updateDate!: Date;
  }