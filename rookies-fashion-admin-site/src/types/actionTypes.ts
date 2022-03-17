import { PagingForm } from "./form/PagingForm";
import { Category, PagingProduct, Product } from "./model";

export type getPagingProductsAction = {
  type: "GET_PAGING_PRODUCTS";
  query: PagingForm;
};

export type gotPagingProducts = {
  type: "GOT_PAGING_PRODUCTS";
  paging: PagingProduct;
};

export type getCategoriesAction = {
  type: "GET_CATEGORIES";
};

export type gotCategories = {
  type: "GOT_CATEGORIES";
  categories: Array<Category>;
};
