import { getCategoriesActionCreator, getPagingProductsActionCreator } from "../types/actionCreatorTypes";
import {PagingForm} from "../types/form/PagingForm"
export const getPagingProducts: getPagingProductsActionCreator = (query: PagingForm) => {
	return {
		type: "GET_PAGING_PRODUCTS",
		query
	};
};

export const getCategories: getCategoriesActionCreator = () => {
	return {
		type: "GET_CATEGORIES",
	};
};


