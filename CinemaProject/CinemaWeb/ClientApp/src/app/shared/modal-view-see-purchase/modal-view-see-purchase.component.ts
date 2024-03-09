import { Component, OnInit,Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-modal-view-see-purchase',
  templateUrl: './modal-view-see-purchase.component.html',
  styleUrls: ['./modal-view-see-purchase.component.scss']
})
export class ModalViewSeePurchaseComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ModalViewSeePurchaseComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit(): void {
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
