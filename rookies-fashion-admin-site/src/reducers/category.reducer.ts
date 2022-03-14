import { Reducer } from "redux";
import { Actions } from "../constants";
import { getCategoriesAction, gotCategories } from "../types/actionTypes";
import { storeType } from "../types/storeType";

type actions = gotCategories | getCategoriesAction;

const initialState: storeType = {};

const categoryReducer: Reducer<storeType, actions> = (
  state = initialState,
  action
) => {
  switch (action.type) {
    case Actions.GOT_CATEGORIES:
      return { ...state, categories: (action as gotCategories).categories };
    default:
      return { ...state };
  }
};

export default categoryReducer;
