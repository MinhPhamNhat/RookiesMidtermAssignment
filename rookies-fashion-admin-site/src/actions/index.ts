import {
  getCategoriesActionCreator,
  getPagingProductsActionCreator,
  getProductByIdActionCreator,
  insertProductActionCreator,
  updateProductActionCreator,
  deleteProductActionCreator,
  getPagingCategoriesActionCreator,
  getCategoryByIdActionCreator,
  setCategoryPagingQueryCreator,
  setProductPagingQueryCreator,
  insertCategoryCreator,
  updateCategoryCreator,
} from "../types/ActionCreatorTypes";
import { CategoryForm } from "../types/form/CategoryForm";
import CategoryPagingQuery from "../types/form/CategoryPagingQuery";
import ProductPagingQuery from "../types/form/ProductPagingQuery";
export const getPagingProducts: getPagingProductsActionCreator = (
  query: ProductPagingQuery
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

export const getPagingCategories: getPagingCategoriesActionCreator = (
  query: CategoryPagingQuery
) => {
  return {
    type: "GET_PAGING_CATEGORIES",
    query,
  };
};

export const getCategoryById: getCategoryByIdActionCreator = (id: string) => {
  return {
    type: "GET_CATEGORY_BY_ID",
    id,
  };
};

export const setProductPagingQuery: setProductPagingQueryCreator = (
  query: ProductPagingQuery
) => {
  return {
    type: "SET_PRODUCT_PAGING_QUERY",
    query,
  };
};

export const setCategoryPagingQuery: setCategoryPagingQueryCreator = (
  query: CategoryPagingQuery
) => {
  return {
    type: "SET_CATEGORY_PAGING_QUERY",
    query,
  };
};

export const insertCategory: insertCategoryCreator = (form: CategoryForm) => {
  return {
    type: "INSERT_CATEGORY",
    form,
  };
};

export const updateCategory: updateCategoryCreator = (
  id: string,
  form: CategoryForm
) => {
  return {
    type: "UPDATE_CATEGORY",
    id,
    form,
  };
};
