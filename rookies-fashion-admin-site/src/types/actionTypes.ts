import { PagingForm } from "./form/PagingForm";
import { ProductForm } from "./form/ProductForm";
import { Category, PagingProduct, Product } from "./model";
import { ValidationError } from "./model/ValidationError";

export type getPagingProductsAction = {
  type: "GET_PAGING_PRODUCTS";
  query: PagingForm;
};

export type gotPagingProducts = {
  type: "GOT_PAGING_PRODUCTS";
  paging: PagingProduct;
  message?: string;
};

export type getProductByIdAction = {
  type: "GET_PRODUCT_BY_ID";
  id: string;
};

export type gotProductById = {
  type: "GOT_PRODUCT_BY_ID";
  product: Product;
  message?: string;
};

export type insertProductAction = {
  type: "INSERT_PRODUCT";
  form: FormData;
};

export type insertedProduct = {
  type: "INSERTED_PRODUCT";
  product: Product;
  message?: string;
};

export type updateProductAction = {
  type: "UPDATE_PRODUCT";
  form: FormData;
  id: string;
};

export type updatedProduct = {
  type: "UPDATED_PRODUCT";
  product: Product;
  message?: string;
};

export type deleteProductAction = {
  type: "DELETE_PRODUCT";
  id: string;
};

export type deletedProduct = {
  type: "DELETED_PRODUCT";
  message?: string;
};

export type getCategoriesAction = {
  type: "GET_CATEGORIES";
};

export type gotCategories = {
  type: "GOT_CATEGORIES";
  categories: Array<Category>;
  message?: string;
};

export type internalErrorGot = {
  type: "INTERNAL_ERROR_GOT";
  message?: string;
};


export type badRequestGot = {
  type: "BAD_REQUEST_GOT";
  validationErrors: Array<ValidationError>;
  message?: string;
};
