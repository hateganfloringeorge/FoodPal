import { CatalogueItem } from './catalogue-item';

export class ProviderCatalogue {
  id: number;
  description: string;
  items: Array<CatalogueItem>;
}