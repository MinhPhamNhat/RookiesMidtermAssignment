import { takeEvery, put, call, StrictEffect } from "redux-saga/effects";
import {
  getProductsAction,
  gotCategories,
  gotProducts,
} from "../types/actionTypes";
import { Actions } from "../constants";
import { categoryService, productService } from "../services";
import { Response } from "../types/model";
// watchers

function* sagaSagaLaydyGaga(): Generator<StrictEffect> {
  console.log(10)
  yield takeEvery(Actions.GET_CATEGORIES, getCategoriesWorker);
  yield takeEvery(Actions.GET_PRODUCTS, getProductsWorker);
}

// workers

function* getProductsWorker() {
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

function* getCategoriesWorker() {
  // create todo using api
  try {
    const response: Response = yield call(categoryService.getCategories);
    switch (response.code) {
      case 200:
        const data: gotCategories = {
          type: "GOT_CATEGORIES",
          categories: response.data,
        };
        yield put(data);
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

export default sagaSagaLaydyGaga;
