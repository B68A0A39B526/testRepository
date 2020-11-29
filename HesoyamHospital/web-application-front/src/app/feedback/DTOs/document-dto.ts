export class DocumentDTO {
    constructor(
        public dateCreated : Date,
        public doctorName : string,
        public diagnosisName : string,
        public type : string
    ) {}
}

