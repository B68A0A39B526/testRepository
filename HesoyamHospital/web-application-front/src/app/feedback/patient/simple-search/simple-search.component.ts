import { AfterViewInit, Component, OnInit } from '@angular/core';
import { DocumentDTO } from '../../DTOs/document-dto';
import { TimeInterval } from '../../DTOs/time-interval';
import { DocumentService } from '../../services/document.service';
import { SearchCriteriaDTO } from '../../DTOs/search-criteria-dto';

@Component({
  selector: 'app-simple-search',
  templateUrl: './simple-search.component.html',
  styleUrls: ['./simple-search.component.css']
})
export class SimpleSearchComponent implements AfterViewInit {

  data : DocumentDTO[] = [];
  displayedColumns: string[] = ['Type', 'DateCreated', 'DoctorName', 'DiagnosisName', 'Observe'];
  minDate: Date;
  maxDate: Date;
  searchCriteria = new SearchCriteriaDTO(true, true, new TimeInterval(new Date(), new Date()), "", "", "", "");

  constructor(private _documentService : DocumentService) 
  {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 5, 0, 0);
    this.maxDate = new Date();
    this.searchCriteria.ShouldSearchReports = true;
    this.searchCriteria.ShouldSearchPrescriptions = true;
  }

  ngAfterViewInit(): void {
    this._documentService.getAll().subscribe(
      data => this.data = data
    )
  }

  submit() {
    this._documentService.post(this.searchCriteria).subscribe(
      data => this.data = data
      )
  }
}
