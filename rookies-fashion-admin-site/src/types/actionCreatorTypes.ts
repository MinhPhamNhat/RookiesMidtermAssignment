import {
  deleteProductAction,
  getCategoriesAction,
  getPagingProductsAction,
  getProductByIdAction,
  insertProductAction,
  updateProductAction,
} from "./actionTypes";
import { PagingForm } from "./form/PagingForm";

export type getPagingProductsActionCreator = (query: PagingForm) => getPagingProductsAction;
export type getProductByIdActionCreator = (id: string) => getProductByIdAction; 
export type insertProductActionCreator = (form: FormData) => insertProductAction;
export type updateProductActionCreator = (id: string, form: FormData) => updateProductAction;
export type deleteProductActionCreator = (id: string) => deleteProductAction;
export type getCategoriesActionCreator = () => getCategoriesAction;
