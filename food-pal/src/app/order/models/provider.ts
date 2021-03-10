import { ProviderCatalogue } from './provider-catalogue';
import { ProviderCategory } from './provider-category';

export class Provider {
  id: number;
  name: string;
  description: string;
  location: string;
  customerId: number;

  category?: ProviderCategory;
  catalogue?: Array<ProviderCatalogue>;
}