import {
    deleteProductAction,
    getCategoriesAction,
    getPagingProductsAction,
    getProductByIdAction,
    insertProductAction,
    updateProductAction,
    getPagingCategoriesAction,
    getCategoryByIdAction,
    setProductPagingQueryAction,
    setCategoryPagingQueryAction,
  } from "./ActionTypes";
  import ProductPagingQuery from "./form/ProductPagingQuery";
  import CategoryPagingQuery from "./form/CategoryPagingQuery";
  
  export type getPagingProductsActionCreator = (query: ProductPagingQuery) => getPagingProductsAction;
  export type getProductByIdActionCreator = (id: string) => getProductByIdAction; 
  export type insertProductActionCreator = (form: FormData) => insertProductAction;
  export type updateProductActionCreator = (id: string, form: FormData) => updateProductAction;
  export type deleteProductActionCreator = (id: string) => deleteProductAction;
  export type getCategoriesActionCreator = () => getCategoriesAction;
  export type getPagingCategoriesActionCreator = (query: CategoryPagingQuery) => getPagingCategoriesAction;
  export type getCategoryByIdActionCreator = (id: string) => getCategoryByIdAction;
  export type setProductPagingQueryCreator = (query: ProductPagingQuery) => setProductPagingQueryAction;
  export type setCategoryPagingQueryCreator = (query: CategoryPagingQuery) => setCategoryPagingQueryAction;
  