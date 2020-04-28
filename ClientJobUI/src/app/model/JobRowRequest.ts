export interface JobRowRequest {
    Id: number;
    Title: string;
    Category: string;
    CategoryId:number;
    CityId: number;
    Employer:string;
    PublishedOn: Date;
    FinishedOn: Date;
    Base64Photo: string;
    Contact: string;
    City: string;
}
