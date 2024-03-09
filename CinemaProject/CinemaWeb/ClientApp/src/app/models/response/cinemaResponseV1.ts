import { CinemaRoomResponseV1 } from "./cinemaRoomResponseV1";
import { DistrictResponseV1 } from "./districtResponseV1";

export class CinemaResponseV1 {
    cinemaID!:number;
    cinemaName!:string;
    districtID!: number;
    district!: DistrictResponseV1;
    cinemaRooms!: CinemaRoomResponseV1[];
    enabled!:boolean;
    createdDate!: Date;
    updateDate!: Date;
  }