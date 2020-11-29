import { AfterViewInit, Component, OnInit } from '@angular/core';
import { AdvancedSearchCriteria } from '../../DTOs/advanced-search-criteria';
import { DocumentDTO } from '../../DTOs/document-dto';
import { TextFilter } from '../../DTOs/text-filter';
import { TimeInterval } from '../../DTOs/time-interval';
import { TimeIntervalFilter } from '../../DTOs/time-interval-filter';
import { DocumentService } from '../../services/document.service';
import { FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'app-advanced-search',
  templateUrl: './advanced-search.component.html',
  styleUrls: ['./advanced-search.component.css']
})
export class AdvancedSearchComponent implements AfterViewInit {

  data : DocumentDTO[] = [];
  displayedColumns: string[] = ['Type', 'DateCreated', 'DoctorName', 'DiagnosisName', 'Observe'];
  searchCriteria : AdvancedSearchCriteria = new AdvancedSearchCriteria(true, true, [], [], [], []);
  minDate: Date;
  maxDate: Date;
  additionalCriteriaCount : number = 0;

  textFilters = ['Equals', 'Contains', 'Does not contain'];
  timeIntervalFilters = ['Contains', 'Does not contain'];
  searchForm = this._formBuilder.group({
    shouldSearchReports: [true],
    shouldSearchPrescriptions: [true],
    searchType: [0],
    startDate: [new Date()],
    endDate: [new Date()],
    doctorName: [''],
    diagnosisName: [''],
    medicineName: [''],
    comment: [''],
    intervalMatchFilter: [0],
    textMatchFilter: [0],
    logicalOperator: [0],
    additionalCriteria: this._formBuilder.array([])
  });
  
  constructor(private _documentService : DocumentService, private _formBuilder : FormBuilder) 
  {
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 5, 0, 0);
    this.maxDate = new Date();
  }

  ngAfterViewInit(): void {
    this._documentService.getAll().subscribe(
      data => this.data = data
    )
  }

  submit() {
    this.searchCriteria.shouldSearchPrescriptions = this.searchForm.get('shouldSearchPrescriptions').value;
    this.searchCriteria.shouldSearchReports = this.searchForm.get('shouldSearchReports').value;
    this.searchCriteria.filterTypes.push(this.searchType);
    if (this.searchType == 0)
      this.searchCriteria.timeIntervalFilters.push(new TimeIntervalFilter(new TimeInterval(this.startDate, this.endDate), this.searchForm.get('intervalMatchFilter').value));
    else if (this.searchType == 1)
      this.searchCriteria.textFilters.push(new TextFilter(this.doctorName, this.searchForm.get('textMatchFilter').value));
    else if (this.searchType == 2)
      this.searchCriteria.textFilters.push(new TextFilter(this.diagnosisName, this.searchForm.get('textMatchFilter').value));
    else if (this.searchType == 3)
      this.searchCriteria.textFilters.push(new TextFilter(this.medicineName, this.searchForm.get('textMatchFilter').value));
    else if (this.searchType == 4)
      this.searchCriteria.textFilters.push(new TextFilter(this.comment, this.searchForm.get('textMatchFilter').value));
    if (this.additionalCriteriaCount > 0) {
      this.searchCriteria.logicalOperators.push(this.searchForm.get('logicalOperator').value);
      this.addRemainingCriteria();
    }
    this._documentService.postAdvanced(this.searchCriteria).subscribe(
      data => { this.data = data; this.searchCriteria = new AdvancedSearchCriteria(true, true, [], [], [], []); this.additionalCriteriaCount = 0;}
      )
  }

  addRemainingCriteria() {
    let count = this.additionalCriteriaCount;
    for (let group of this.additionalCriteria.controls) {
        this.additionalCriteriaCount -= 1;
        console.log(this.additionalCriteriaCount);
        this.searchCriteria.filterTypes.push(group.get('SearchType').value);
        if (group.get('SearchType').value == 0)
          this.searchCriteria.timeIntervalFilters.push(new TimeIntervalFilter(new TimeInterval(group.get('StartDate').value, group.get('EndDate').value), group.get('IntervalMatchFilter').value));
        else if (group.get('SearchType').value == 1)
          this.searchCriteria.textFilters.push(new TextFilter(group.get('DoctorName').value, group.get('TextMatchFilter').value));
        else if (group.get('SearchType').value == 2)
          this.searchCriteria.textFilters.push(new TextFilter(group.get('DiagnosisName').value, group.get('TextMatchFilter').value));
        else if (group.get('SearchType').value == 3)
          this.searchCriteria.textFilters.push(new TextFilter(group.get('MedicineName').value, group.get('TextMatchFilter').value));
        else if (group.get('SearchType').value == 4)
          this.searchCriteria.textFilters.push(new TextFilter(group.get('Comment').value, group.get('TextMatchFilter').value));
        if (this.additionalCriteriaCount > 0) {
          this.searchCriteria.logicalOperators.push(group.get('LogicalOperator').value);
        }
    }
    while (count > 0) {
      this.removeOne(count-1);
      count -= 1;
    }
  }

  get shouldSearchReports() {
    return this.searchForm.get('shouldSearchReports').value;
  }

  set shouldSearchReports (val) {
    this.searchForm.get('shouldSearchReports').setValue(val);
  }

  get shouldSearchPrescriptions() {
    return this.searchForm.get('shouldSearchPrescriptions').value;
  }

  set shouldSearchPrescriptions (val) {
    this.searchForm.get('shouldSearchPrescriptions').setValue(val);
  }

  get searchType() {
    return this.searchForm.get('searchType').value;
  }

  set searchType (val) {
    this.searchForm.get('searchType').setValue(val);
  }

  get doctorName() {
    return this.searchForm.get('doctorName').value;
  }

  set doctorName (val) {
    this.searchForm.get('doctorName').setValue(val);
  }

  get diagnosisName() {
    return this.searchForm.get('diagnosisName').value;
  }

  set diagnosisName (val) {
    this.searchForm.get('diagnosisName').setValue(val);
  }

  get medicineName() {
    return this.searchForm.get('medicineName').value;
  }

  set medicineName (val) {
    this.searchForm.get('medicineName').setValue(val);
  }

  get comment() {
    return this.searchForm.get('comment').value;
  }

  set comment (val) {
    this.searchForm.get('comment').setValue(val);
  }

  get startDate() {
    return this.searchForm.get('startDate').value;
  }

  set startDate (val) {
    this.searchForm.get('startDate').setValue(val);
  }

  get endDate() {
    return this.searchForm.get('endDate').value;
  }

  set endDate (val) {
    this.searchForm.get('endDate').setValue(val);
  }

  get additionalCriteria() {
    return this.searchForm.get('additionalCriteria') as FormArray;
  }

  set additionalCriteria(val) {
    this.searchForm.get('additionalCriteria').setValue(val);
  }

  removeOne(i) {
    this.additionalCriteria.removeAt(i);
    this.additionalCriteriaCount -= 1;
  }

  addOne() {
    this.additionalCriteria.push(this._formBuilder.group({
      SearchType: [0],
      StartDate: [new Date()],
      EndDate: [new Date()],
      DoctorName: [''],
      DiagnosisName: [''],
      MedicineName: [''],
      Comment: [''],
      IntervalMatchFilter: [0],
      TextMatchFilter: [0],
      LogicalOperator: [0]
    }));
    this.additionalCriteriaCount += 1;
  }

  reset() {
    while (this.additionalCriteriaCount > 0) {
      console.log(this.additionalCriteriaCount);
      this.additionalCriteria.removeAt(this.additionalCriteriaCount-1);
      this.additionalCriteriaCount -= 1;
    }
  }
}
