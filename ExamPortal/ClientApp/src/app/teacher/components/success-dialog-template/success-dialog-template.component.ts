import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";

@Component({
    selector: 'app-success-dialog',
    templateUrl: 'success-dialog.component.html',
})

export class SuccessDialogComponent {

    componentName: string;

    constructor(
        private dialogRef: MatDialogRef<SuccessDialogComponent>,
        @Inject(MAT_DIALOG_DATA) data: any
    ) {
        this.componentName = data.componentName.toLowerCase();
    }

    confirm()
    {
        this.dialogRef.close(true);
    }

    close()
    {
        this.dialogRef.close();
    }
}