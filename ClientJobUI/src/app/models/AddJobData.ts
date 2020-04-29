import {CategoryDTO} from './DTO/CategoryDTO';
import {CityDTO} from './DTO/CityDTO';

export interface AddJobData {
  categories: CategoryDTO[];
  cities: CityDTO[];
  id?: number;
}
