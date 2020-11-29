import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NewPatientDto } from '../DTOs/new-patient-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  private _urlpost : string = "http://localhost:52166/api/registration";

  constructor(private _http: HttpClient) { }

  post(patient : NewPatientDto) {
    return this._http.post<any>(this._urlpost, patient);
  }
}
