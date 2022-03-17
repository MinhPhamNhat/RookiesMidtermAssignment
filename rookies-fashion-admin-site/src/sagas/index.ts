import { takeEvery, put, call, StrictEffect } from "redux-saga/effects";
import {
  getPagingProductsAction,
  gotCategories,
  gotPagingProducts,
} from "../types/actionTypes";
import { Actions } from "../constants";
import { categoryService, productService } from "../services";
import { Response } from "../types/model";
import { PagingForm } from "../types/form/PagingForm";
// watchers

function* sagaSagaLaydyGaga(): Generator<StrictEffect> {
  yield takeEvery(Actions.GET_CATEGORIES, getCategoriesWorker);
  yield takeEvery(Actions.GET_PAGING_PRODUCTS, getProductsWorker);
}

// workers

function* getProductsWorker({query}: getPagingProductsAction) {
  // create todo using api
  try {
    const response: Response = yield call(productService.getProducts, query);
    switch (response.code) {
      case 200:
        const data: gotPagingProducts = {
          type: "GOT_PAGING_PRODUCTS",
          paging: response.data,
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
