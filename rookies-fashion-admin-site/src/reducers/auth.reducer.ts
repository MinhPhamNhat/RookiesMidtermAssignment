import { Reducer } from "redux";
import { Actions } from "../constants";
import {
    doneLoginRedirect,
    doneLoginRedirectCallback
} from "../types/ActionTypes";
import { StoreType } from "../types/StoreType";

type actions =
  | doneLoginRedirect
  | doneLoginRedirectCallback;

const initialState: StoreType = {};

const authReducer: Reducer<StoreType, actions> = (
  state = initialState,
  action
) => {
  state.actionType = action.type;
  state.message = (action as any).message;
  switch (action.type) {
    case Actions.DONE_LOGIN_REDIRECT:
      return { ...state };
    case Actions.DONE_LOGIN_REDIRECT_CALBACK:
      return {
        ...state,
        user: (action as doneLoginRedirectCallback).user,
      };
    default:
      return { ...state };
  }
};

export default authReducer;
