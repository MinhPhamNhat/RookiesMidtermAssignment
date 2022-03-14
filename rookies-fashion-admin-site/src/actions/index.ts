import { getCategoriesActionCreator, getProductsActionCreator } from "../types/actionCreatorTypes";

export const getProducts: getProductsActionCreator = () => {
	console.log(333)
	return {
		type: "GET_PRODUCTS",
	};
};

export const getCategories: getCategoriesActionCreator = () => {
	console.log(222)
	return {
		type: "GET_CATEGORIES",
	};
};

