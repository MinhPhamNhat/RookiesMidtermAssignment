import { getProductsActionCreator } from "../types/actionCreatorTypes";

export const getProducts: getProductsActionCreator = () => {
	return {
		type: "GET_PRODUCTS",
	};
};
