export class MedicalRecordDto {
    constructor(
        public firstName : string,
        public lastName : string,
        public middleName : string,
        public address : string,
        public medicalId : string,
        public personalId : string,
        public mobilePhone : string,
        public homePhone : string,
        public email : string,
        public username : string,
        public password : string,
        public dateOfBirth : string,
        public bloodType : string,
        public alergies : Array<string>
    ) {}
}
