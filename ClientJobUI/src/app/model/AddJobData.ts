import {Category} from './Category';
import {City} from './City';

export interface AddJobData {
  categories: Category[];
  cities: City[]
  id?: number;
  action: string;
}
