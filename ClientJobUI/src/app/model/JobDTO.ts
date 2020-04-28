export interface JobDTO {
  id: number;
  title: string;
  contact?: string;
  categoryId: number;
  categoryName: string;
  publishedOn: Date;
  EndDate?: Date;
  description: string;
  profileId: number;
  cityId: number;
  city: string;
  salary: number;
  employer: string;
  base64Photo?: string;
  actions?: boolean;
}

