export interface NewJobDTO {

  jobId: number;
  categoryId: number;
  cityId: number;
  title: string;
  category: string;
  typeJobId: number,
  employer: string;
  city: string;
  publishedOn: Date;
  finishedOn: Date;
  image: string;
  contact: string;
  salary: string;
}
