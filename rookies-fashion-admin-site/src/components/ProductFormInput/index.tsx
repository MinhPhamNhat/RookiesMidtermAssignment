import {
  ContentState,
  convertFromHTML,
  convertToRaw,
  EditorState,
} from "draft-js";
import { Editor } from "react-draft-wysiwyg";
import { useEffect, useState } from "react";
import { Button, Card, Col, Form, Row } from "react-bootstrap";

import draftToHtml from "draftjs-to-html";
import AsyncSelect from "react-select/async";

import { categoryService, colorService, sizeService } from "../../services";
import { Category, Color, Image, Size } from "../../types/model";

import Option from "../Option";
import InputSection from "../InputSection";
import UploadZone from "../UploadZone";
import ImagePreview from "../ImagePreview";

import "./index.css";

const ProductFormInput = ({ form, setForm, formSubmit, isEditForm }: any) => {
  
  const [editorState, setEditorState] = useState(() =>
    EditorState.createWithContent(
      ContentState.createFromBlockArray(
        convertFromHTML(form?.Description ? form?.Description : "")
          .contentBlocks
      )
    )
  );

  const [defaultCategoryOption, setDefaultCategoryOption] = useState<any>(
    parseCategoryOptions(form?.Category)
  );
  const [defaultSizesOption, setDefaultSizesOption] = useState(
    form?.Sizes?.map(parseSizeOptions)
  );
  const [defaultColorsOption, setDefaultColorsOption] = useState(
    form?.Colors?.map(parseColorOptions)
  );

  const [categories, setCategories] = useState([]);
  const [sizes, setSizes] = useState([]);
  const [colors, setColors] = useState([]);

  useEffect(() => {
    setForm({
      ...form,
      Description: draftToHtml(convertToRaw(editorState.getCurrentContent())),
    });
  }, [editorState]);
  useEffect(() => {
    setDefaultCategoryOption(
      categories.find((c: any) => c.value == form.CategoryId)
    );
  }, [form.CategoryId]);
  useEffect(() => {
    if (colors.length)
    setDefaultColorsOption(
      colors.filter((c: any) => form?.ColorIds?.includes(c.value))
    );
  }, [form.ColorIds]);
  useEffect(() => {
    if (sizes.length)
    setDefaultSizesOption(
      sizes.filter((c: any) => form?.SizeIds?.includes(c.value))
    );
  }, [form.SizeIds]);

  const promiseCategoryOptions = async () => {
    var data = (await categoryService.getCategories()).data;
    var out = data.map(parseCategoryOptions);
    setCategories(out);
    return out;
  };
  const promiseColorOptions = async () => {
    var data = (await colorService.getColors()).data;
    var out = data.map(parseColorOptions);
    setColors(out);
    return out;
  };
  const promiseSizeOptions = async () => {
    var data = (await sizeService.getSizes()).data;
    var out = data.map(parseSizeOptions);
    setSizes(out);
    return out;
  };

  const onFileUploaded = (files: Array<File>) => {
    setForm({ ...form, Files: files });
  };
  return (
    <Card>
      <Card.Body>
        <h5 className="card-title"></h5>
        <Form>
          <Row>
            <Col>
              <InputSection
                title="Name"
                component={
                  <Form.Control
                    type="text"
                    placeholder="Nice Product Name Here ... "
                    value={form?.Name}
                    onChange={(e: any) =>
                      setForm({ ...form, Name: e.target.value })
                    }
                  />
                }
              />
              <Row>
                <Col>
                  <InputSection
                    title="Color"
                    component={
                      <AsyncSelect
                        onChange={(value: any) =>
                          setForm({
                            ...form,
                            ColorIds: value.map((c: any) => c.value),
                          })
                        }
                        cacheOptions
                        defaultOptions
                        isMulti={true}
                        value={defaultColorsOption}
                        loadOptions={promiseColorOptions}
                      />
                    }
                  />
                </Col>
                <Col>
                  <InputSection
                    title="Size"
                    component={
                      <AsyncSelect
                        onChange={(value: any) =>
                          setForm({
                            ...form,
                            SizeIds: value.map((s: any) => s.value),
                          })
                        }
                        value={defaultSizesOption}
                        cacheOptions
                        defaultOptions
                        isMulti={true}
                        loadOptions={promiseSizeOptions}
                      />
                    }
                  />
                </Col>
              </Row>
              <InputSection
                title="Description"
                component={
                  <Editor
                    wrapperClassName="editor-wrapper"
                    editorClassName="editor"
                    editorState={editorState}
                    onEditorStateChange={setEditorState}
                  />
                }
              />
            </Col>
            <Col>
              <InputSection
                title="Category"
                component={
                  <AsyncSelect
                    onChange={({ value }: any) =>
                      setForm({ ...form, CategoryId: value.value })
                    }
                    cacheOptions
                    defaultOptions
                    value={defaultCategoryOption}
                    loadOptions={promiseCategoryOptions}
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
                          setForm({
                            ...form,
                            Price: parseInt(e.target.value),
                          })
                        }
                        value={form?.Price}
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
              {isEditForm ? (
                <InputSection
                  title="Default Thumbnails"
                  component={
                    <div
                      style={{
                        display: "flex",
                        flexDirection: "row",
                        gap: "10px",
                      }}
                    >
                      {form?.Thumbnail.map((image: Image) => (
                        <ImagePreview key={image.ImageId} image={image} />
                      ))}
                    </div>
                  }
                />
              ) : (
                <></>
              )}
            </Col>
          </Row>

          <div className="bottom-action">
            <Button variant="secondary">
              <i className="fas fa-times"></i>Cancel
            </Button>
            <Button variant="primary" onClick={formSubmit}>
              <i className="fas fa-save"></i> {isEditForm ? "Save" : "Create"}
            </Button>
          </div>
        </Form>
      </Card.Body>
    </Card>
  );
};

export default ProductFormInput;

const parseCategoryOptions = (data?: Category) => {
  return data
    ? {
        value: data.CategoryId,
        name: data.Name,
        label: (
          <Option.Category
            name={data.Name}
            isParent={data.IsParent}
            value={data.CategoryId}
          />
        ),
      }
    : {};
};
const parseSizeOptions = (data?: Size) => {
  return data
    ? {
        value: data.SizeId,
        label: data.Name,
        name: data.Name,
      }
    : {};
};

const parseColorOptions = (data?: Color) => {
  return data
    ? {
        value: data.ColorId,
        name: data.Name,
        label: <Option.Color name={data.Name} url={data.Thumbnail.ImageUrl} />,
      }
    : {};
};
