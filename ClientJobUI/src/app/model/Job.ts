export interface Job {
  id: number;
  title: string;
  category: string;
  employer: string;
  publishedOn: Date;
  finishedOn: Date;
  base64Photo?: string;
  contact?: string;
  actions?: boolean;
}
