import { combineReducers } from "redux";
import productReducer from "./product.reducers";
import categoryReducer from "./category.reducer";

const store = {
    categoryReducer,
    productReducer
};

export default combineReducers(store);