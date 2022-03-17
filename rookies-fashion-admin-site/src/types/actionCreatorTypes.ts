import { getCategoriesAction, getPagingProductsAction } from "./actionTypes";
import { PagingForm } from "./form/PagingForm";
export type getPagingProductsActionCreator = (query: PagingForm) => getPagingProductsAction;
export type getCategoriesActionCreator = () => getCategoriesAction;
