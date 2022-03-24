import { combineReducers } from "redux";
import productReducer from "./product.reducers";
import categoryReducer from "./category.reducers";
import authReducer from "./auth.reducer";
import userReducer from "./user.reducers";

const store = {
    categoryReducer,
    productReducer,
    authReducer,
    userReducer
};

export default combineReducers(store);