export class CatalogueItem {
    id: number;
    name: string;
    price: number;
    category?: { id: number; name: string };
  }