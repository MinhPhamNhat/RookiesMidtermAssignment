import { takeEvery, put, call, StrictEffect } from "redux-saga/effects";
import {
  badRequestGot,
  deletedProduct,
  deleteProductAction,
  doneSetCategoryPagingQuery,
  doneSetProductPagingQuery,
  getCategoryByIdAction,
  getPagingCategoriesAction,
  getPagingProductsAction,
  getProductByIdAction,
  gotCategories,
  gotCategoryById,
  gotPagingCategories,
  gotPagingProducts,
  gotProductById,
  insertCategoryAction,
  insertedCategory,
  insertedProduct,
  insertProductAction,
  internalErrorGot,
  setCategoryPagingQueryAction,
  setProductPagingQueryAction,
  updateCategoryAction,
  updatedCategory,
  updatedProduct,
  updateProductAction,
} from "../types/ActionTypes";
import { Actions } from "../constants";
import { categoryService, productService } from "../services";
import { Response } from "../types/model";
import ProductPagingQuery from "../types/form/ProductPagingQuery";
// watchers

function* sagaSagaLaydyGaga(): Generator<StrictEffect> {
  yield takeEvery(Actions.GET_CATEGORIES, getCategoriesWorker);
  yield takeEvery(Actions.GET_PAGING_PRODUCTS, getProductsWorker);
  yield takeEvery(Actions.GET_PRODUCT_BY_ID, getProductByIdWorker);
  yield takeEvery(Actions.INSERT_PRODUCT, insertProductWorker);
  yield takeEvery(Actions.UPDATE_PRODUCT, updateProductWorker);
  yield takeEvery(Actions.DELETE_PRODUCT, deleteProductWorker);
  yield takeEvery(Actions.GET_PAGING_CATEGORIES, getPagingCategoriesdWorker);
  yield takeEvery(Actions.GET_CATEGORY_BY_ID, getCategoryByIdWorker);
  yield takeEvery(
    Actions.SET_PRODUCT_PAGING_QUERY,
    setProductPagingQueryWorker
  );
  yield takeEvery(
    Actions.SET_CATEGORY_PAGING_QUERY,
    setCategoryPagingQueryWorker
  );
  yield takeEvery(Actions.INSERT_CATEGORY, insertCategoryWorker);
  yield takeEvery(Actions.UPDATE_CATEGORY, updateCategoryWorker);
}

// workers

function* getProductsWorker({ query }: getPagingProductsAction) {
  try {
    const response: Response = yield call(productService.getProducts, query);
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as gotPagingProducts) = {
          type: "GOT_PAGING_PRODUCTS",
          paging: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* getProductByIdWorker({ id }: getProductByIdAction) {
  try {
    const response: Response = yield call(productService.getProductById, id);
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as gotProductById) = {
          type: "GOT_PRODUCT_BY_ID",
          product: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* updateProductWorker({ id, form }: updateProductAction) {
  try {
    const response: Response = yield call(
      productService.updateProduct,
      id,
      form
    );
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as updatedProduct) = {
          type: "UPDATED_PRODUCT",
          product: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* insertProductWorker({ form }: insertProductAction) {
  try {
    const response: Response = yield call(productService.insertProduct, form);
    var data: any = null;
    switch (response.code) {
      case 201:
        (data as insertedProduct) = {
          type: "INSERTED_PRODUCT",
          product: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* deleteProductWorker({ id }: deleteProductAction) {
  try {
    const response: Response = yield call(productService.deleteProduct, id);
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as deletedProduct) = {
          type: "DELETED_PRODUCT",
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* getCategoriesWorker() {
  try {
    const response: Response = yield call(categoryService.getCategories);
    switch (response.code) {
      case 200:
        const data: gotCategories = {
          type: "GOT_CATEGORIES",
          categories: response.data,
          message: response.message,
        };
        yield put(data);
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* getPagingCategoriesdWorker({ query }: getPagingCategoriesAction) {
  try {
    const response: Response = yield call(
      categoryService.getPagingCategories,
      query
    );
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as gotPagingCategories) = {
          type: "GOT_PAGING_CATEGORIES",
          paging: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* setProductPagingQueryWorker({ query }: setProductPagingQueryAction) {
  var data: doneSetProductPagingQuery = {
    type: "DONE_SET_PRODUCT_PAGING_QUERY",
    query,
  };
  yield put(data);
  // update our redux store by dispatching a new action
}

function* setCategoryPagingQueryWorker({
  query,
}: setCategoryPagingQueryAction) {
  var data: doneSetCategoryPagingQuery = {
    type: "DONE_SET_CATEGORY_PAGING_QUERY",
    query,
  };
  yield put(data);
  // update our redux store by dispatching a new action
}

function* getCategoryByIdWorker({ id }: getCategoryByIdAction) {
  try {
    const response: Response = yield call(categoryService.getCategoryById, id);
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as gotCategoryById) = {
          type: "GOT_CATEGORY_BY_ID",
          category: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* insertCategoryWorker({ form }: insertCategoryAction) {
  try {
    const response: Response = yield call(categoryService.insertCategory, form);
    var data: any = null;
    switch (response.code) {
      case 201:
        (data as insertedCategory) = {
          type: "INSERT_CATEGORY",
          category: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}

function* updateCategoryWorker({ id, form }: updateCategoryAction) {
  try {
    const response: Response = yield call(
      categoryService.updateCategory,
      id,
      form
    );
    var data: any = null;
    switch (response.code) {
      case 200:
        (data as updatedCategory) = {
          type: "UPDATED_CATEGORY",
          category: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 400:
        (data as badRequestGot) = {
          type: "BAD_REQUEST_GOT",
          validationErrors: response.data,
          message: response.message,
        };
        yield put(data);
        break;
      case 500:
        (data as internalErrorGot) = {
          type: "INTERNAL_ERROR_GOT",
          message: response.message,
        };
        yield put(data);
        break;
    }
  } catch (err) {}
  // update our redux store by dispatching a new action
}
export default sagaSagaLaydyGaga;
