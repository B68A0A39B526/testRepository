import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DocumentDTO } from '../DTOs/document-dto';
import { SearchCriteriaDTO } from '../DTOs/search-criteria-dto';
import { AdvancedSearchCriteria } from '../DTOs/advanced-search-criteria';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  private _urlgetall:string = "http://localhost:52166/api/document/500";
  private _urlpost:string = "http://localhost:52166/api/document/simple-search/500";
  private _urlpostadvanced:string = "http://localhost:52166/api/document/advanced-search/500";

  constructor( private _http : HttpClient) { }

  getAll() : Observable<DocumentDTO[]> {
    return this._http.get<DocumentDTO[]>(this._urlgetall);
  }

  post(searchCriteria : SearchCriteriaDTO) : Observable<DocumentDTO[]> {
    return this._http.post<DocumentDTO[]>(this._urlpost, searchCriteria);
}

postAdvanced(searchCriteria : AdvancedSearchCriteria) : Observable<DocumentDTO[]> {
  return this._http.post<DocumentDTO[]>(this._urlpostadvanced, searchCriteria);
}
}
