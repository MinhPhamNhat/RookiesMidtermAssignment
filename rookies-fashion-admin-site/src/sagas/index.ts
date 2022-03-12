import { takeEvery, put, call, StrictEffect } from "redux-saga/effects";
import {  getProductsAction, gotProducts } from "../types/actionTypes";
import { Actions } from "../constants";
import { productService } from "../services";
import { Response } from "../types/model";
// watchers

function* sagaSagaLaydyGaga(): Generator<StrictEffect> {
  yield takeEvery(Actions.GET_PRODUCTS, getProductWorker);
}

// workers

function* getProductWorker() {
  // create todo using api
  try {
    const response: Response = yield call(productService.getProducts);
    switch (response.code) {
      case 200:
        const data: gotProducts = {
          type: "GOT_PRODUCTS",
          products: response.data.Items,
        };
        yield put(data);
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

export default sagaSagaLaydyGaga;
