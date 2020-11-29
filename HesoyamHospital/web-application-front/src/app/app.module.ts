import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FeedbackModule } from './feedback/feedback.module';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { FeedbackService } from './feedback/services/feedback.service';
import { MaterialModule } from './shared/material/material.module';
import { MedicalRecordModule} from './medical-record/medical-record.module';
import { RegistrationModule } from './registration/registration.module';
import { DocumentsModule } from './documents/documents.module';
import { RegistrationService } from './registration/services/registration.service';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FeedbackModule,
    SharedModule,
    HttpClientModule,
    MaterialModule,
    MedicalRecordModule,
    RegistrationModule,
    DocumentsModule
  ],
  providers: [FeedbackService, RegistrationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
