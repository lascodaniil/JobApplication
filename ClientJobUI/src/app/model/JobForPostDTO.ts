export interface JobForPostDTO {
  title:	string;
  maxLength?: number;
  minLength?: number;
  categoryId: number;
  cityId: number;
  description?: string;
  startDate: Date;
  stopDate: Date;
  salary: number;
  base64Photo: string;
  contact: string;
}
