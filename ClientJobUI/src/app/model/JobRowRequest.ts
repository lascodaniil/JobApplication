export interface JobRowRequest {
    id: number;
    title: string;
    category: string;
    categoryId:number;
    cityId: number;
    employer:string;
    publishedOn: Date;
    finishedOn: Date;
    base64Photo: string;
    contact: string;
    city: string;
}
