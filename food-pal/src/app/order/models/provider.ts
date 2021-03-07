import { Catalogue } from "./catalogue";
import { ProviderCategory } from "./provider-category";

export class Provider {
    id: number;
    name: string;
    description: string;
    location: string;
    customerId: number;
    
    catalogue: Catalogue;
    category?: ProviderCategory;
}