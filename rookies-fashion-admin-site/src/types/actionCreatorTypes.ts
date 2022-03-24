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
    insertCategoryAction,
    updateCategoryAction,
    storeUserAction,
    storeUserErrorAction,
    loginRedirectAction,
    loginRedirectCallbackAction,
    deleteCategoryAction,
    getUsersAction,
  } from "./ActionTypes";
  import ProductPagingQuery from "./form/ProductPagingQuery";
  import CategoryPagingQuery from "./form/CategoryPagingQuery";
import { CategoryForm } from "./form/CategoryForm";
  
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
  export type insertCategoryCreator = (form: CategoryForm) => insertCategoryAction;
  export type updateCategoryCreator = (id: string, form: CategoryForm) => updateCategoryAction;
  export type deleteCategoryCreator = (id: string) => deleteCategoryAction;
  export type storeUserCreator = (user: any) => storeUserAction;
  export type storeUserErrorCreator = () => storeUserErrorAction;
  export type loginRedirectCreator = () => loginRedirectAction;
  export type loginRedirectCalbackCreator = () => loginRedirectCallbackAction;
  export type getUsersCreator = () => getUsersAction;
  