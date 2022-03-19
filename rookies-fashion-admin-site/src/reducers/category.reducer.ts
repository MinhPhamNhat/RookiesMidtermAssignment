import { Reducer } from "redux";
import { Actions } from "../constants";
import {
  badRequestGot,
  doneSetCategoryPagingQuery,
  gotCategories,
  gotCategoryById,
  gotPagingCategories,
  internalErrorGot,
  setCategoryPagingQueryAction,
} from "../types/ActionTypes";
import { StoreType } from "../types/StoreType";

type actions =
  | gotCategories
  | gotPagingCategories
  | gotCategoryById
  | doneSetCategoryPagingQuery
  | badRequestGot
  | internalErrorGot;

const initialState: StoreType = {};

const categoryReducer: Reducer<StoreType, actions> = (
  state = initialState,
  action
) => {
  state.actionType = action.type;
  state.message = (action as any).message;
  switch (action.type) {
    case Actions.GOT_CATEGORIES:
      return { ...state, categories: (action as gotCategories).categories };
    case Actions.GOT_PAGING_CATEGORIES:
      return {
        ...state,
        pagingCategory: (action as gotPagingCategories).paging,
      };
    case Actions.GOT_CATEGORY_BY_ID:
      return { ...state, category: (action as gotCategoryById).category };
    case Actions.DONE_SET_CATEGORY_PAGING_QUERY:
      return {
        ...state,
        categoryPagingQuery: (action as doneSetCategoryPagingQuery).query,
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

export default categoryReducer;
