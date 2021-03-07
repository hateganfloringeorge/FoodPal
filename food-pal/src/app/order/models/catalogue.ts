import { CatalogueItem } from "./catalogue-item";

export class Catalogue {
    id: number;
    description: string;
    items?: Array<CatalogueItem>;
}