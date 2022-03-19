import { Reducer } from "redux";
import { Actions } from "../constants";
import {
  badRequestGot,
  getPagingProductsAction,
  gotPagingProducts,
  gotProductById,
  insertedProduct,
  internalErrorGot,
  updatedProduct,
} from "../types/actionTypes";
import { storeType } from "../types/storeType";

type actions =
  | gotPagingProducts
  | getPagingProductsAction
  | gotProductById
  | updatedProduct
  | insertedProduct
  | badRequestGot
  | internalErrorGot;

const initialState: storeType = {};

const productReducer: Reducer<storeType, actions> = (
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
