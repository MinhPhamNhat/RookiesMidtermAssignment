import { Reducer } from "redux";
import { Actions } from "../constants";
import {
    doneLoginRedirect,
    doneLoginRedirectCallback,
    gotUsers
} from "../types/ActionTypes";
import { StoreType } from "../types/StoreType";

type actions =
  | gotUsers;

const initialState: StoreType = {};

const userReducer: Reducer<StoreType, actions> = (
  state = initialState,
  action
) => {
  state.actionType = action.type;
  state.message = (action as any).message;
  switch (action.type) {
    case Actions.GOT_USERS:
      return { ...state, user: (action as gotUsers).user };
    default:
      return { ...state };
  }
};

export default userReducer;
