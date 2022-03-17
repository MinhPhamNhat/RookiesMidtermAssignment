import { Category, PagingProduct, Product, User } from "./model";

export type storeType = {
	products?: Array<Product>;
	users?: Array<User>;
	categories?: Array<Category>;
	actionType?: string;
	pagingProduct?: PagingProduct;
	statusCode?: number;
}

