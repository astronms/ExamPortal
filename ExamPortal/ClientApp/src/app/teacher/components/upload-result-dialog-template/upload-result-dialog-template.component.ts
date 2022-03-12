import { Component, Inject } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { ExamSessionModel } from "src/app/models/exam-session.model";
import { ExamSessionService } from "../../services/exam-session.service";

@Component({
    selector: 'app-upload-result-dialog',
    templateUrl: 'upload-result-dialog.component.html',
    styles: ['.file-input { display: none; }']
})

export class UploadResultDialogComponent {

    sessionId: string;
    session: ExamSessionModel;
    file: File = null;
    fileName: string;
    formGroup: FormGroup = this.formBuilder.group({
        file: ['', Validators.required]
    }); 

    constructor(
        private examSessionService: ExamSessionService,
        private formBuilder: FormBuilder,
        private dialogRef: MatDialogRef<UploadResultDialogComponent>,
        @Inject(MAT_DIALOG_DATA) data: {sessionId: string}
    ) {
        this.sessionId = data.sessionId;
        this.examSessionService.getExamSession(this.sessionId).subscribe(result => {
            this.session = result;
        })
    }

    onFileSelected(event)
    {
        if(event.target.files[0])
        {
            this.file = event.target.files[0];
            this.fileName = this.file.name;
        }
    }

    confirm()
    {
        this.examSessionService.saveSessionResult(this.sessionId, this.file).subscribe(() => {
            this.dialogRef.close();
        });
    }

    close()
    {
        this.dialogRef.close();
    }
}