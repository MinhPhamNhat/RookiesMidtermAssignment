import { connect } from "react-redux";
import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { getProductById } from "../../../actions";
const ProductDetail: React.FC<any> = (props) => {
  const { id } = useParams();

  console.log(props);
  return (
    <div>
      <div className="page-title">
        <h3>Details</h3>
      </div>
      <hr />
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
    </div>
  );
};
const mapDispatchToProps = (state: any) => {
  return {
    ...state.productReducer,
  };
};
export default ProductDetail;
