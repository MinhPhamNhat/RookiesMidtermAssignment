import {
  Chip,
  FormControl,
  FormControlLabel,
  FormLabel,
  Input,
  InputLabel,
  MenuItem,
  Radio,
  RadioGroup,
  Select,
  Badge,
  TextField,
} from "@mui/material";
import { useEffect, useState } from "react";
import { Button, Col, Modal, Row } from "react-bootstrap";
import { useAsyncService } from "../../hooks/AsyncHookService";
import { categoryService } from "../../services";
import { CategoryForm } from "../../types/form/CategoryForm";
import { Category } from "../../types/model";
import "./index.css";

const InsertModal = (props: any) => {
  const { onHide, categories, confirmInsert } = props;
  const [parentCategories, setParentCategories] = useState([]);
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [parentCategoryId, setParentCategoryId] = useState(0);
  const [categoryForm, setCategoryForm] = useState<CategoryForm>({});

  useEffect(() => {
    const getService = async () => {
      const myResp = await categoryService.getParentCategories();
      setParentCategories(myResp.data);
    };
    getService();
  }, []);

  const handleOnChangeName = (value: any) => {
    setName(value.target.value);
  };

  const handleOnChangeDescription = (value: any) => {
    setDescription(value.target.value);
  };

  const handleOnSelectCategory = (value: any) => {
    setParentCategoryId(value.target.value);
  };

  const handleSubmitForm = () => {
    confirmInsert(categoryForm);
  };
  
  useEffect(() => {
    setCategoryForm({
      ...categoryForm,
      Name: name,
      Description: description,
      ParentCategoryId: parentCategoryId,
    });
  }, [name, description, parentCategoryId]);

  return (
    <Modal
      {...props}
      size="sm"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header>
        <Modal.Title id="contained-modal-title-vcenter">
          Insert Category{" "}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <FormControl focused fullWidth sx={{ m: 1 }} variant="standard">
          <InputLabel htmlFor="standard-name" focused color="info">
            <strong>Name</strong>
          </InputLabel>
          <Input
            id="standard-name"
            color="info"
            fullWidth
            value={name}
            onChange={handleOnChangeName}
          />
        </FormControl>
        <FormControl focused fullWidth sx={{ m: 1 }} variant="standard">
          <InputLabel htmlFor="standard-name" focused color="info">
            <strong>Description</strong>
          </InputLabel>
          <Input
            id="standard-name"
            color="info"
            fullWidth
            value={description}
            onChange={handleOnChangeDescription}
          />
        </FormControl>

        <TextField
          focused
          sx={{ m: 1 }}
          id="standard-select-currency"
          select
          fullWidth
          label={<strong>Parent Category</strong>}
          value={parentCategoryId}
          onChange={handleOnSelectCategory}
          helperText="None means this Category is parent"
          variant="standard"
        >
          {[
            <MenuItem key={0} value={0}>
              None
            </MenuItem>,
          ].concat(
            parentCategories?.map((_: Category) => (
              <MenuItem key={_.CategoryId} value={_.CategoryId}>
                {_.Name}
              </MenuItem>
            ))
          )}
        </TextField>
      </Modal.Body>
      <Modal.Footer>
        <div className="detail-bottom-action">
          <span></span>
          <div className="bottom-right-action">
            <Button variant="outline-secondary" onClick={onHide}>
              Cancel
            </Button>
            <Button variant="primary" onClick={handleSubmitForm}>
              Create
            </Button>
          </div>
        </div>
      </Modal.Footer>
    </Modal>
  );
};

export default InsertModal;
