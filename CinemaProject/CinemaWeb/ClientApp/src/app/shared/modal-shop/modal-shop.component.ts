import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ReservationRequestV1 } from 'src/app/models/request/reservationRequestV1';

@Component({
  selector: 'app-modal-shop',
  templateUrl: './modal-shop.component.html',
  styleUrls: ['./modal-shop.component.scss']
})
export class ModalShopComponent implements OnInit {

  reservation : ReservationRequestV1 = new ReservationRequestV1();

  genders = ['M', 'F'];
  selectedGender: string | undefined;

  constructor(
    public dialogRef: MatDialogRef<ModalShopComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onComprarClick(): void {
    const datosCompra = {
      nombres: this.reservation.names,
      apellidos: this.reservation.lastNames,
      birthday: this.reservation.birthDate,
      gender: this.selectedGender,
      dni: this.reservation.dni,
      email: this.reservation.email
    };
  
    this.dialogRef.close(datosCompra);
  }
}
