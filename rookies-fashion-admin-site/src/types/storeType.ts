import CategoryPagingQuery from "./form/CategoryPagingQuery";
import ProductPagingQuery from "./form/ProductPagingQuery";
import { Category, PagingProduct, Product, User } from "./model";
import { PagingCategory } from "./model/PagingCategory";
import { ValidationError } from "./model/ValidationError";

export type StoreType = {
	products?: Array<Product>;
	product?: Product;
	category?: Category;
	users?: Array<User>;
	categories?: Array<Category>;
	pagingProduct?: PagingProduct;
	pagingCategory?: PagingCategory;
	validationErrors?: Array<ValidationError>;
	productPagingQuery?: ProductPagingQuery;
	categoryPagingQuery?: CategoryPagingQuery;
	message?: string;
	actionType?: string;
	statusCode?: number;
}

