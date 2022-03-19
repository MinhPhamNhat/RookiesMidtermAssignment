import { Category, PagingProduct, Product, User } from "./model";
import { ValidationError } from "./model/ValidationError";

export type storeType = {
	products?: Array<Product>;
	product?: Product;
	users?: Array<User>;
	categories?: Array<Category>;
	pagingProduct?: PagingProduct;
	validationErrors?: Array<ValidationError>;
	message?: string;
	actionType?: string;
	statusCode?: number;
}

