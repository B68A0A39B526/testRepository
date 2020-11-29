export class NewPatientDto {
    
    public Name : string;
    public Surname : string;
    public MiddleName : string;
    public Gender : string;
    public Email : string;
    public Username : string;
    public Password : string;
    public DateOfBirth : Date;
    public HealthCardNumber : string;
    public Jmbg : string;
    public MobilePhone : string;
    public HomePhone : string;
    public BloodType : string;
    public Allergies : string[];
    public Country : string;
    public City : string;
    public Address : string;

    constructor() {}
}