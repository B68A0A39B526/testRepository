import { TimeInterval } from './time-interval';

export class TimeIntervalFilter {
    constructor(
        public timeInterval : TimeInterval,
        public filter : number,
    ) {}
}
