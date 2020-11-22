export class NewFeedbackDto {
    constructor(
        public Comment : string,
        public Anonymous : boolean,
        public Public : boolean
    ) {}
}
