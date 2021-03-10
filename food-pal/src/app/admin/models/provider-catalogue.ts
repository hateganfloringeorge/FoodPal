import { ProviderCategory } from './provider-category';

export class ProviderCatalogue {
  id: number;
  description: string;
  items: Array<CatalogueItem>;
}

export class CatalogueItem {
  id: number;
  name: string;
  price: number;
  //HOMEWORK: make this not hordcoded (use matSelect)
  category: ProviderCategory = { id: 1, name: 'Desserts' };
  status: ItemStatus = ItemStatus.Initial;
}

export enum ItemStatus {
  Initial = 0,
  Added = 1,
  Updated = 2,
  Deleted = 3,
}