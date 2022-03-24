import ProductPagingQuery from "./form/ProductPagingQuery";
import CategoryPagingQuery from "./form/CategoryPagingQuery";
import { Category, PagingProduct, Product, User } from "./model";
import { ValidationError } from "./model/ValidationError";
import { PagingCategory } from "./model/PagingCategory";
import { CategoryForm } from "./form/CategoryForm";

export type getPagingProductsAction = {
  type: "GET_PAGING_PRODUCTS";
  query: ProductPagingQuery;
};

export type gotPagingProducts = {
  type: "GOT_PAGING_PRODUCTS";
  paging: PagingProduct;
  message?: string;
};

export type getProductByIdAction = {
  type: "GET_PRODUCT_BY_ID";
  id: string;
};

export type gotProductById = {
  type: "GOT_PRODUCT_BY_ID";
  product: Product;
  message?: string;
};

export type insertProductAction = {
  type: "INSERT_PRODUCT";
  form: FormData;
};

export type insertedProduct = {
  type: "INSERTED_PRODUCT";
  product: Product;
  message?: string;
};

export type updateProductAction = {
  type: "UPDATE_PRODUCT";
  form: FormData;
  id: string;
};

export type updatedProduct = {
  type: "UPDATED_PRODUCT";
  product: Product;
  message?: string;
};

export type deleteProductAction = {
  type: "DELETE_PRODUCT";
  id: string;
};

export type deletedProduct = {
  type: "DELETED_PRODUCT";
  message?: string;
};

export type getPagingCategoriesAction = {
  type: "GET_PAGING_CATEGORIES";
  query: CategoryPagingQuery;
};

export type gotPagingCategories = {
  type: "GOT_PAGING_CATEGORIES";
  paging: PagingCategory;
  message?: string;
};

export type getCategoriesAction = {
  type: "GET_CATEGORIES";
};

export type gotCategories = {
  type: "GOT_CATEGORIES";
  categories: Array<Category>;
  message?: string;
};

export type getCategoryByIdAction = {
  type: "GET_CATEGORY_BY_ID";
  id: string;
};

export type gotCategoryById = {
  type: "GOT_CATEGORY_BY_ID";
  category: Category;
  message?: string;
};

export type setProductPagingQueryAction = {
  type: "SET_PRODUCT_PAGING_QUERY";
  query: ProductPagingQuery;
};

export type doneSetProductPagingQuery = {
  type: "DONE_SET_PRODUCT_PAGING_QUERY";
  query: ProductPagingQuery;
};

export type setCategoryPagingQueryAction = {
  type: "SET_CATEGORY_PAGING_QUERY";
  query: CategoryPagingQuery;
};

export type doneSetCategoryPagingQuery = {
  type: "DONE_SET_CATEGORY_PAGING_QUERY";
  query: CategoryPagingQuery;
};

export type insertCategoryAction = {
  type: "INSERT_CATEGORY",
  form: CategoryForm
}

export type insertedCategory = {
  type: "INSERT_CATEGORY";
  category: Category;
  message?: string;
}

export type updateCategoryAction = {
  type: "UPDATE_CATEGORY",
  form: CategoryForm,
  id: string
}

export type updatedCategory = {
  type: "UPDATED_CATEGORY";
  category: Category;
  message?: string;
}

export type deleteCategoryAction = {
  type: "DELETE_CATEGORY",
  id: string
}

export type deletedCategory = {
  type: "DELETED_CATEGORY";
  message?: string;
}

export type getUsersAction = {
  type: "GET_USERS";
};

export type gotUsers = {
  type: "GOT_USERS";
  user: User,
  message?: string;
};


export type internalErrorGot = {
  type: "INTERNAL_ERROR_GOT";
  message?: string;
};

export type badRequestGot = {
  type: "BAD_REQUEST_GOT";
  validationErrors: Array<ValidationError>;
  message?: string;
};

export type storeUserAction = {
  type: "STORE_USER";
  user: any;
};

export type doneStoreUser = {
  type: "DONE_STORE_USER";
};

export type storeUserErrorAction = {
  type: "STORE_USER_ERROR";
};

export type doneStoreUserError = {
  type: "DONE_STORE_USER_ERROR";
};

export type loginRedirectAction = {
  type: "LOGIN_REDIRECT";
};

export type doneLoginRedirect = {
  type: "DONE_LOGIN_REDIRECT";
};

export type loginRedirectCallbackAction = {
  type: "LOGIN_REDIRECT_CALLBACK";
};

export type doneLoginRedirectCallback = {
  type: "DONE_LOGIN_REDIRECT_CALLBACK";
  user: any;
};
