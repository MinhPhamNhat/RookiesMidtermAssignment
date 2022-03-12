import React, { lazy } from "react";

const ProductList = lazy(() => import("./ProductList"));
const ProductInsert = lazy(() => import("./ProductInsert"));
const ProductDetail = lazy(() => import("./ProductDetail"));
const ProductEdit = lazy(() => import("./ProductEdit"));

const Product: React.FC<any> & {
  Detail: typeof ProductDetail;
  List: typeof ProductList;
  Insert: typeof ProductInsert;
  Edit: typeof ProductEdit;
} = ({ children }): JSX.Element => <>{children}</>;

Product.Detail = ProductDetail;
Product.List = ProductList;
Product.Insert = ProductInsert;
Product.Edit = ProductEdit;

export default Product;
