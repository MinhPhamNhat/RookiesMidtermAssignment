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
} from "@mui/material";
import { Button, Col, Modal, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import { setProductPagingQuery } from "../../../actions";
import { PageRoutes } from "../../../constants";
import { Category, Product } from "../../../types/model";
import "../index.css";

const CategoryDetailModal = (props: any) => {
  const { onHide, category, setProductPagingCategory } = props;

  return (
    <Modal
      {...props}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header>
        <Modal.Title id="contained-modal-title-vcenter">
          Category Detail{" "}
          <span className="small-title">
            Category ID:{" "}
            <Chip
              label={<b>#{category?.CategoryId}</b>}
              size="small"
              variant="filled"
            />
          </span>
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Row>
          <Col>
            <FormControl focused fullWidth sx={{ m: 1 }} variant="standard">
              <InputLabel htmlFor="standard-name" focused color="info">
                <strong>Name</strong>
              </InputLabel>
              <Input
                id="standard-name"
                value={category?.Name}
                color="info"
                fullWidth
              />
            </FormControl>
            <FormControl focused fullWidth sx={{ m: 1 }} variant="standard">
              <InputLabel htmlFor="standard-name" focused color="info">
                <strong>Description</strong>
              </InputLabel>
              <Input
                id="standard-name"
                value={category?.Description}
                color="info"
                fullWidth
              />
            </FormControl>
            <FormControl focused fullWidth sx={{ m: 1 }} variant="standard">
              <FormLabel style={{fontSize: "16px"}} id="radio-buttons-group-label">
                <strong>Is Parent Category</strong>
              </FormLabel>
              <RadioGroup
                row
                aria-labelledby="radio-buttons-group-label"
                name="row-radio-buttons-group"
              >
                <FormControlLabel
                  value="true"
                  control={<Radio />}
                  label="True"
                  checked={category?.IsParent}
                />
                <FormControlLabel
                  value="false"
                  control={<Radio />}
                  label="False"
                  checked={!category?.IsParent}
                />
              </RadioGroup>
            </FormControl>
          </Col>
          <Col>
            <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
              <InputLabel htmlFor="standard-category" focused color="info">
                <strong>Parent Category</strong>
              </InputLabel>
              <Input
                id="standard-category"
                value={category?.Parent ? category?.Parent?.Name : "None"}
                color="info"
              />
            </FormControl>
            <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
              <InputLabel htmlFor="standard-sizes" focused color="info">
                <strong>Children</strong>
              </InputLabel>
              <Select
                labelId="select-sizes"
                id="select-sizes"
                value={category?.Children[0]?.CategoryId}
              >
                {category?.Children?.map((_: Category) => (
                  <MenuItem key={_.CategoryId} value={_.CategoryId}>
                    <strong>{_.Name}</strong>
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
              <InputLabel htmlFor="standard-sizes" focused color="info">
                <strong>
                  Products Reference{" "}
                  <Chip
                    label={category?.Products?.length}
                    size="small"
                    color="info"
                    variant="outlined"
                  />{" "}
                  <Link onClick={()=>setProductPagingCategory(category?.CategoryId)} to={PageRoutes.PRODUCT_LIST}>
                        Go to references <i className="fa-solid fa-caret-right"></i>
                  </Link>
                </strong>
              </InputLabel>
              <Select
                labelId="select-sizes"
                id="select-sizes"
                value={category?.Products[0]?.ProductId}
              >
                {category?.Products?.map((_: Product) => (
                  <MenuItem key={_.ProductId} value={_.ProductId}>
                    <strong>
                      <Chip label={`#${_.ProductId}`} size="small" /> {_.Name}
                    </strong>
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          </Col>
        </Row>
      </Modal.Body>
      <Modal.Footer>
        <div className="detail-bottom-action">
          <Button className="remove-button" variant="danger" onClick={onHide}>
            <i className="fa-solid fa-trash"></i> Remove
          </Button>
          <div className="bottom-right-action">
            <Button variant="outline-secondary" onClick={onHide}>
              Cancel
            </Button>
            <Button variant="primary">Update</Button>
          </div>
        </div>
      </Modal.Footer>
    </Modal>
  );
};

export default CategoryDetailModal;
