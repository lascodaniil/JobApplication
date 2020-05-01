export interface JobDTO{
    jobId:number;
    categoryId:number;
    cityId:number;
    title:string;
    category:string;
    employer :string;
    city:string;
    publishedOn : Date;
    finishedOn:Date;
    base64Photo:string;
    contact: string;
    salary:string;
    description:string;
}
