import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { serialize } from "object-to-formdata";
import { NOTIFICATION_TYPE, Store } from "react-notifications-component";

import { getCategories, insertProduct } from "../../../actions";
import { ProductForm } from "../../../types/form/ProductForm";
import { Actions, StatusCode } from "../../../constants";
import { ValidationError } from "../../../types/model/ValidationError";

import ProductFormInput from "../../../components/ProductFormInput";

import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import "react-notifications-component/dist/theme.css";
import { ShowNotification } from "../../../helpers";

const ProductInsert: React.FC<any> = (props) => {
  const { insertProduct, actionType, message, validationErrors } = props;
  const [form, setForm] = useState<ProductForm>({
    CategoryId: 0,
    ColorIds: [],
    Description: "",
    Name: "",
    Price: 0,
    SizeIds: [],
    Files: [],
  });

  const formSubmit = async () => {
    console.log(form)
    var formData = serialize(form);
    form.Files.forEach((f) => formData.append("Files", f, f.name));
    insertProduct(formData);
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
        <h3>Insert Product</h3>
      </div>
      <hr />
      <ProductFormInput form={form} setForm={setForm} formSubmit={formSubmit} isEditForm={false}/>
    </div>
  );
};

const mapStateToProps = (state: any) => {
  return {
    ...state.categoryReducer,
    ...state.productReducer,
  };
};

export default connect(mapStateToProps, {
  getCategories,
  insertProduct,
})(ProductInsert);
