import { Category, Product } from "./model";

// For Action Creator
export type getProductsAction = {
  type: "GET_PRODUCTS";
};

export type gotProducts = {
  type: "GOT_PRODUCTS";
  products: Array<Product>;
};

export type getCategoriesAction = {
  type: "GET_CATEGORIES";
};

export type gotCategories = {
  type: "GOT_CATEGORIES";
  categories: Array<Category>;
};

// export interface deleteTodoAction {
//   type: "DELETE_TODO";
//   id: string;
// }

// export interface createTodoAction {
//   type: "CREATE_TODO";
//   title: string;
// }

// export interface getTodos {
//   type: "GET_TODOS";
// }
// export interface deletedTodoAction {
//   type: "DELETED_TODO";
//   id: string;
// }

// export interface markedCompleteAction {
//   type: "MARKED_COMPLETE";
//   id: string;
// }

// export interface markedIncompleteAction {
//   type: "MARKED_INCOMPLETE";
//   id: string;
// }

export const actionIds = {
  GET_PRODUCTS: "GET_PRODUCTS",
  GOT_PRODUCTS: "GOT_PRODUCTS",
};
