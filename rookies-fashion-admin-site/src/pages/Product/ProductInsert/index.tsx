import { Card, Container } from "react-bootstrap";
import React, { useState, useEffect } from "react";
import { Editor } from "react-draft-wysiwyg";
import { EditorState, convertToRaw } from "draft-js";
import draftToHtml from "draftjs-to-html";
import { connect } from "react-redux";
import { getCategories } from "../../../actions";
import { categoryService, colorService, sizeService, productService } from "../../../services";
import { serialize } from 'object-to-formdata';
import { Category, Color, Size } from "../../../types/model";
import Option from "../../../components/Option";
import AsyncSelect from "react-select/async";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import UploadZone from "../../../components/UploadZone";
import InputSection from "../../../components/InputSection";
import { ProductForm } from "../../../types/form/ProductForm";

const ProductInsert: React.FC<any> = (props) => {
  const [form, setForm] = useState<ProductForm>({
    CategoryId: 0,
    ColorIds: [],
    Description: "",
    Name: "",
    Price: 0,
    SizeIds: [],
    Files: [],
  });
  const [editorState, setEditorState] = useState(() =>
    EditorState.createEmpty()
  );
  const onFileUploaded = (files: Array<File>) => {
    setForm({ ...form, Files: files });
  };
  const formSubmit = () => {
    var formData = new FormData()
    productService.insertProduct(form)
  }
  useEffect(() => {
    setForm({
      ...form,
      Description: draftToHtml(convertToRaw(editorState.getCurrentContent())),
    });
  }, [editorState]);
  return (
    <Container>
      <div className="page-title">
        <h3>Insert Product</h3>
      </div>
      <Card>
        <div className="card-body">
          <h5 className="card-title"></h5>
          <form className="">
            <InputSection
              title="Name"
              component={
                <>
                  <input
                    type="text"
                    className="form-control"
                    onChange={(e: any) =>
                      setForm({ ...form, Name: e.target.value })
                    }
                  />
                  <small className="form-text text-muted">
                    A help text that brings hint to users.
                  </small>
                </>
              }
            />

            <InputSection
              title="Description"
              component={
                <Editor
                  editorState={editorState}
                  onEditorStateChange={setEditorState}
                />
              }
            />
            <InputSection
              title="Category"
              component={
                <AsyncSelect
                  onChange={(value: any) =>
                    setForm({ ...form, CategoryId: value.value })
                  }
                  cacheOptions
                  defaultOptions
                  loadOptions={promiseCategoryOptions}
                />
              }
            />
            <InputSection
              title="Color"
              component={
                <AsyncSelect
                  onChange={(value: any) =>
                    setForm({ ...form, ColorIds: value.map((c: any) => c.value) })
                  }
                  cacheOptions
                  defaultOptions
                  isMulti={true}
                  loadOptions={promiseColorOptions}
                />
              }
            />
            <InputSection
              title="Size"
              component={
                <AsyncSelect
                  onChange={(value: any) =>
                    setForm({ ...form, SizeIds: value.map((s: any) => s.value) })
                  }
                  cacheOptions
                  defaultOptions
                  isMulti={true}
                  loadOptions={promiseSizeOptions}
                />
              }
            />
            <InputSection
              title="Price"
              component={
                <div className="mb-3">
                  <div className="input-group mb-3">
                    <span className="input-group-text">$</span>
                    <input
                      type="number"
                      className="form-control"
                      aria-label="Amount (to the nearest dollar)"
                      onChange={(e: any) =>
                        setForm({ ...form, Price: parseInt(e.target.value) })
                      }
                    />
                    <span className="input-group-text">.00</span>
                  </div>
                </div>
              }
            />
            <InputSection
              title="Thumbnails"
              component={<UploadZone onFileUploaded={onFileUploaded} />}
            />
            <div className="mb-3 row">
              <div className="col-sm-4 offset-sm-2">
                <button type="button" className="btn btn-secondary mb-2">
                  <i className="fas fa-times"></i> Cancel
                </button>
                <button type="button" className="btn btn-primary mb-2" onClick={formSubmit}>
                  <i className="fas fa-save"></i> Save
                </button>
              </div>
            </div>
          </form>
        </div>
      </Card>
    </Container>
  );
};

const mapStateToProps = (state: any) => {
  return {
    ...state.categoryReducer,
  };
};

export default connect(mapStateToProps, {
  getCategories,
})(ProductInsert);

const promiseCategoryOptions = async () => {
  var data = (await categoryService.getCategories()).data;
  return data.map((c: Category) => {
    return {
      value: c.CategoryId,
      name: c.Name,
      label: (
        <Option.Category
          name={c.Name}
          isParent={c.IsParent}
          value={c.CategoryId}
        />
      ),
    };
  });
};
const promiseColorOptions = async () => {
  var data = (await colorService.getColors()).data;
  return data.map((c: Color) => {
    return {
      value: c.ColorId,
      name: c.Name,
      label: <Option.Color name={c.Name} url={c.Thumbnail.ImageUrl} />,
    };
  });
};
const promiseSizeOptions = async () => {
  var data = (await sizeService.getSizes()).data;
  return data.map((c: Size) => {
    return {
      value: c.SizeId,
      label: c.Name,
      name: c.Name,
    };
  });
};
