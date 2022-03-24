import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { serialize } from "object-to-formdata";
import { NOTIFICATION_TYPE, Store } from "react-notifications-component";
import { useParams } from "react-router-dom";

import { getProductById, updateProduct } from "../../../actions";
import { ProductForm } from "../../../types/form/ProductForm";
import { Actions, StatusCode } from "../../../constants";
import { ValidationError } from "../../../types/model/ValidationError";

import ProductFormInput from "../../../components/ProductFormInput";

import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import "react-notifications-component/dist/theme.css";
import { Color, Size } from "../../../types/model";

const ProductEdit: React.FC<any> = (props: any) => {
  const {
    product,
    getProductById,
    updateProduct,
    validationErrors,
    actionType,
    message,
  } = props;
  const { id } = useParams();
  const [form, setForm] = useState<ProductForm>({
    ...product,
    ColorIds: product?.Colors?.map((c: Color) => c.ColorId),
    SizeIds: product?.Sizes?.map((c: Size) => c.SizeId),
  });
  const [getProductTrigger, setGetProductTrigger] = useState(false);

  if (!getProductTrigger && (product?.ProductId != id || !product)) {
    setGetProductTrigger(true);
  }

  useEffect(() => {
    switch (actionType) {
      case Actions.BAD_REQUEST_GOT:
        validationErrors.forEach((err: ValidationError) =>
          ShowNotification(err.ErrorMessage, err.Field, "danger")
        );
        break;
      case Actions.UPDATED_PRODUCT:
        ShowNotification(message, "Success", "success");
        break;
      default:
        break;
    }
  }, [actionType]);
  
  useEffect(() => {
    if (getProductTrigger) {
      getProductById(id);
    }
  }, [getProductTrigger]);

  if (actionType === Actions.GOT_PRODUCT_BY_ID && getProductTrigger) {
    setGetProductTrigger(false);
    setForm({
      ...product,
      ColorIds: product?.Colors.map((c: Color) => c.ColorId),
      SizeIds: product?.Sizes.map((c: Size) => c.SizeId),
    });
  }

  const formSubmit = async () => {
    var formData = serialize(form);
    form?.Files?.forEach((f) => formData.append("Files", f, f.name));
    updateProduct(id, formData);
  };

  useEffect(() => {
    switch (actionType) {
      case Actions.BAD_REQUEST_GOT:
        validationErrors.forEach((err: ValidationError) =>
          ShowNotification(err.ErrorMessage, err.Field, "danger")
        );
        break;
      case Actions.INSERTED_PRODUCT:
        ShowNotification(message, "Success", "success");
        break;
      default:
        break;
    }
  }, [actionType]);

  return (
    <div>
      <div className="page-title">
        <h3>Edit Product</h3>
      </div>
      <hr />
      {!getProductTrigger ? (
        <ProductFormInput
          form={form}
          setForm={setForm}
          formSubmit={formSubmit}
          isEditForm={true}
        />
      ) : (
        <></>
      )}
    </div>
  );
};

const mapStateToProps = (state: any) => {
  return {
    ...state.productReducer,
  };
};

export default connect(mapStateToProps, {
  getProductById,
  updateProduct,
})(ProductEdit);

const ShowNotification = (
  message: string,
  title: string,
  type: NOTIFICATION_TYPE
) => {
  Store.addNotification({
    title: title,
    message: message,
    type: type,
    insert: "top",
    container: "bottom-right",
    animationIn: ["animate__animated", "animate__fadeIn"],
    animationOut: ["animate__animated", "animate__fadeOut"],
    dismiss: {
      duration: 5000,
      onScreen: true,
    },
  });
};
