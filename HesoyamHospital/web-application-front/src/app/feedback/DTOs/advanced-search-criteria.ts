import { TextFilter } from './text-filter';
import { TimeIntervalFilter } from './time-interval-filter';

export class AdvancedSearchCriteria {
    constructor(
        public shouldSearchPrescriptions : boolean,
        public shouldSearchReports : boolean,
        public filterTypes : number[],
        public logicalOperators : number[],
        public textFilters : TextFilter[],
        public timeIntervalFilters : TimeIntervalFilter[]
    ) {}
}
