import { CatalogueItemCategory } from "./catalogue-item-category";

export class CatalogueItem {
    id: number;
    name: string;
    price: number;
    category?: CatalogueItemCategory;
}