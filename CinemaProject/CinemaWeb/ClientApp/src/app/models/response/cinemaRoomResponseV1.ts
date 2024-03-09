import { CinemaResponseV1 } from "./cinemaResponseV1";
import { DistrictResponseV1 } from "./districtResponseV1";

export class CinemaRoomResponseV1 {
    cinemaRoomID!:number;
    cinemaRoomName!:string;
    capatity!: number;
    cinemaID!:number;
    cinema!:CinemaResponseV1;
    enabled!:boolean;
    createdDate!: Date;
    updateDate!: Date;
  }