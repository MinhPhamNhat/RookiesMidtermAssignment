import { combineReducers } from "redux";
import productReducer from "./product.reducers";


const store = {
    productReducer
};

export default combineReducers(store);