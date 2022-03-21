import React, { lazy } from "react";
import ProductDetailModal from "./Product"
import CategoryDetailModal from "./Category"

const DetailModal: React.FC<any> & {
  Product: typeof ProductDetailModal;
  Category: typeof CategoryDetailModal;
} = ({ children }): JSX.Element => <>{children}</>;

DetailModal.Product = ProductDetailModal;
DetailModal.Category = CategoryDetailModal;

export default DetailModal;
