import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MedicalRecordDto } from '../DTOs/medical-record-dto';

@Injectable({
  providedIn: 'root'
})
export class MedicalRecordService {

  private _urlshowrecord:string = 'http://localhost:52166/api/medicalrecord/show/505';

  constructor(private _http : HttpClient) {}

  getMedicalRecord(): Observable<MedicalRecordDto>{
      return this._http.get<MedicalRecordDto>(this._urlshowrecord);
  }
  
}
