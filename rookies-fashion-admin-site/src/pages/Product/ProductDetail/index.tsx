import React from "react";
import {useParams} from "react-router-dom"
const ProductDetail: React.FC<any> = (props) => {
  console.log(useParams());
  return <>Product Detail Page</>;
};

export default ProductDetail;
