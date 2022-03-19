import {
  getCategoriesActionCreator,
  getPagingProductsActionCreator,
  getProductByIdActionCreator,
  insertProductActionCreator,
  updateProductActionCreator,
  deleteProductActionCreator,
} from "../types/actionCreatorTypes";
import { PagingForm } from "../types/form/PagingForm";
export const getPagingProducts: getPagingProductsActionCreator = (
  query: PagingForm
) => {
  return {
    type: "GET_PAGING_PRODUCTS",
    query,
  };
};

export const getProductById: getProductByIdActionCreator = (id: string) => {
  return {
    type: "GET_PRODUCT_BY_ID",
    id,
  };
};

export const insertProduct: insertProductActionCreator = (form: FormData) => {
  return {
    type: "INSERT_PRODUCT",
    form,
  };
};

export const updateProduct: updateProductActionCreator = (
  id: string,
  form: FormData
) => {
  return {
    type: "UPDATE_PRODUCT",
    id,
    form,
  };
};

export const deleteProduct: deleteProductActionCreator = (id: string) => {
  return {
    type: "DELETE_PRODUCT",
    id,
  };
};

export const getCategories: getCategoriesActionCreator = () => {
  return {
    type: "GET_CATEGORIES",
  };
};
