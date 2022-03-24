import { Reducer } from "redux";
import { Actions } from "../constants";
import {
  badRequestGot,
  doneSetProductPagingQuery,
  getPagingProductsAction,
  gotPagingProducts,
  gotProductById,
  insertedProduct,
  internalErrorGot,
  setProductPagingQueryAction,
  updatedProduct,
} from "../types/ActionTypes";
import { StoreType } from "../types/StoreType";

type actions =
  | gotPagingProducts
  | getPagingProductsAction
  | gotProductById
  | updatedProduct
  | insertedProduct
  | doneSetProductPagingQuery
  | badRequestGot
  | internalErrorGot;

const initialState: StoreType = {};

const productReducer: Reducer<StoreType, actions> = (
  state = initialState,
  action
) => {
  state.actionType = action.type;
  state.message = (action as any).message;
  switch (action.type) {
    case Actions.GOT_PAGING_PRODUCTS:
      return { ...state, pagingProduct: (action as gotPagingProducts).paging };
    case Actions.GOT_PRODUCT_BY_ID:
      return { ...state, product: (action as gotProductById).product };
    case Actions.INSERTED_PRODUCT:
      return { ...state, product: (action as insertedProduct).product };
    case Actions.UPDATED_PRODUCT:
      return { ...state, product: (action as updatedProduct).product };
    case Actions.DELETED_PRODUCT:
      return { ...state };
    case Actions.DONE_SET_PRODUCT_PAGING_QUERY:
      return {
        ...state,
        productPagingQuery: (action as doneSetProductPagingQuery).query,
      };
    case Actions.BAD_REQUEST_GOT:
      return {
        ...state,
        validationErrors: (action as badRequestGot).validationErrors,
      };
    case Actions.INTERNAL_ERROR_GOT:
      return {
        ...state,
        message: (action as internalErrorGot).message,
      };
    default:
      return { ...state };
  }
};

export default productReducer;
