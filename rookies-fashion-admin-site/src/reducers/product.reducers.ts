import { Reducer } from "redux";
import { Actions } from "../constants";
import { getPagingProductsAction, gotPagingProducts } from "../types/actionTypes";
import { storeType } from "../types/storeType";

type actions = gotPagingProducts | getPagingProductsAction;

const initialState: storeType = {};

const productReducer: Reducer<storeType, actions> = (
  state = initialState,
  action
) => {
  state.actionType = action.type;
  switch (action.type) {
    case Actions.GOT_PAGING_PRODUCTS:
      return { ...state, pagingProduct: (action as gotPagingProducts).paging };
    default:
      return { ...state };
  }
};

export default productReducer;
