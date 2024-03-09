import { MovieGenreResponseV1 } from "./movieGenreResponseV1";

export class MovieResponseV1 {
    movieID!:number;
    movieName!:string;
    movieGenre!:MovieGenreResponseV1;
    movieGenreID!: number;
    synopsis!: string;
    duration!: number;
    imgURLOrBase64!: string;
    enabled!:boolean;
    createdDate!: Date;
    updateDate!: Date;
  }