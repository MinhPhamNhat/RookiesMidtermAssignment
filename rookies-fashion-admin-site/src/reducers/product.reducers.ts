import { Reducer } from "redux";
import { Actions } from "../constants";
import { getProductsAction, gotProducts } from "../types/actionTypes";
import { storeType } from "../types/storeType";

type actions = gotProducts | getProductsAction;

const initialState: storeType = {};

const productReducer: Reducer<storeType, actions> = (
  state = initialState,
  action
) => {
  switch (action.type) {
    case Actions.GOT_PRODUCTS:
      return { ...state, products: (action as gotProducts).products };
    default:
      return { ...state };
  }
};

export default productReducer;
