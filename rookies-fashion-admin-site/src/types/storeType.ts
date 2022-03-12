import { Category, Product, User } from "./model";

export type storeType = {
	products?: Array<Product>;
	users?: Array<User>;
	categories?: Array<Category>;
	statusCode?: number;
}

