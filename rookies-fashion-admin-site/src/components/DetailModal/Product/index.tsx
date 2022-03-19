import {
    Chip,
    FormControl,
    ImageList,
    ImageListItem,
    ImageListItemBar,
    Input,
    InputAdornment,
    InputLabel,
    ListSubheader,
    MenuItem,
    Select,
  } from "@mui/material";
  import { Button, Col, Modal, Row } from "react-bootstrap";
  import { Link } from "react-router-dom";
  import { PageRoutes } from "../../../constants";
  import { UpdatedDate, Image, Color, Size } from "../../../types/model";
  import "../index.css";
  
  const ProductDetailModal = (props: any) => {
    const { onHide, product } = props;
  
    const getLocaleDateTime = (time: Date) =>
      new Date(time).toLocaleTimeString("en-US", {
        year: "numeric",
        month: "long",
        day: "numeric",
        hour: "numeric",
        minute: "numeric",
      });
    const category =
      (product.Category.IsParent ? "" : product.Category.Parent.Name + " > ") +
      product.Category.Name;
    return (
      <Modal
        {...props}
        size="xl"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header>
          <Modal.Title id="contained-modal-title-vcenter">
            Product Detail{" "}
            <span className="small-title">
              Product ID:{" "}
              <Chip
                label={<b>#{product?.ProductId}</b>}
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
                  value={product?.Name}
                  color="info"
                  fullWidth
                />
              </FormControl>
              <Row>
                <Col>
                  <FormControl focused sx={{ m: 1 }} variant="standard">
                    <InputLabel
                      htmlFor="standard-adornment-amount"
                      focused
                      color="info"
                    >
                      <strong>Price</strong>
                    </InputLabel>
                    <Input
                      id="standard-adornment-amount"
                      value={product?.Price}
                      color="info"
                      startAdornment={
                        <InputAdornment position="start">
                          <strong>$</strong>
                        </InputAdornment>
                      }
                      endAdornment={
                        <InputAdornment position="end">
                          <strong>.00</strong>
                        </InputAdornment>
                      }
                    />
                  </FormControl>
                </Col>
                <Col>
                  <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                    <InputLabel htmlFor="standard-category" focused color="info">
                      <strong>Category</strong>
                    </InputLabel>
                    <Input id="standard-category" value={category} color="info" />
                  </FormControl>
                </Col>
              </Row>
              <Row>
                <Col>
                  <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                    <InputLabel htmlFor="standard-sizes" focused color="info">
                      <strong>Sizes</strong>
                    </InputLabel>
                    <Select
                      labelId="select-sizes"
                      id="select-sizes"
                      value={product.Sizes[0].SizeId}
                    >
                      {product?.Sizes?.map((_: Size) => (
                        <MenuItem key={_.SizeId} value={_.SizeId}>
                          <strong>{_.Name}</strong>
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Col>
                <Col>
                  <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                    <InputLabel htmlFor="standard-colors" focused color="info">
                      <strong>Colors</strong>
                    </InputLabel>
                    <Select
                      labelId="select-colors"
                      id="select-colors"
                      value={product.Colors[0].ColorId}
                    >
                      {product?.Colors?.map((_: Color) => (
                        <MenuItem key={_.ColorId} value={_.ColorId}>
                          <img
                            src={_.Thumbnail.ImageUrl}
                            height={25}
                            width={25}
                            style={{
                              marginRight: "10px",
                              border: "1px solid black",
                            }}
                          />
                          <strong>{_.Name}</strong>
                        </MenuItem>
                      ))}
                    </Select>
                  </FormControl>
                </Col>
              </Row>
              <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                <InputLabel htmlFor="standard-description" focused color="info">
                  <strong>Description</strong>
                </InputLabel>
                <Input
                  id="standard-description"
                  multiline
                  maxRows={5}
                  value={product?.Description}
                  color="info"
                />
              </FormControl>
            </Col>
            <Col>
              <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                <InputLabel htmlFor="standard-category" focused color="info">
                  <strong>Created Date</strong>
                </InputLabel>
                <Input
                  id="standard-category"
                  value={getLocaleDateTime(product?.CreatedDate)}
                  color="info"
                />
              </FormControl>
              <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                <InputLabel htmlFor="standard-category" focused color="info">
                  <strong>Updated Date</strong>
                </InputLabel>
                <Select
                  labelId="select-updated-date"
                  id="select-updated-date"
                  value={product?.UpdatedDates[product?.UpdatedDates.length-1]?.UpdatedDateId}
                >
                  {product?.UpdatedDates?.map((_: UpdatedDate) => (
                    <MenuItem key={_.UpdatedDateId} value={_.UpdatedDateId}>
                      {getLocaleDateTime(_.Time)}
                    </MenuItem>
                  )).reverse()}
                </Select>
              </FormControl>
              <FormControl fullWidth focused sx={{ m: 1 }} variant="standard">
                <ImageList sx={{ width: 500, height: 350 }}>
                  <ImageListItem key="Subheader" cols={2}>
                    <ListSubheader component={"div"} color="primary">
                      <strong>Thumbnails</strong>
                    </ListSubheader>
                  </ImageListItem>
                  {product?.Thumbnail?.map((item: Image) => (
                    <ImageListItem key={item.ImageId}>
                      <img src={item.ImageUrl} loading="lazy" />
                      <ImageListItemBar
                        title={item.ImageName}
                        subtitle={<span>extension: {item.Extension}</span>}
                      />
                    </ImageListItem>
                  ))}
                </ImageList>
              </FormControl>
            </Col>
          </Row>
          {/* <div className="advanced-button">
            <Button variant="outline-primary">Advanced <i className="fa-solid fa-caret-down"></i></Button>
          </div> */}
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
  
              <Link to={PageRoutes.PRODUCT_EDIT + `/${product.ProductId}`}>
                <Button variant="primary">Update</Button>
              </Link>
            </div>
          </div>
        </Modal.Footer>
      </Modal>
    );
  };
  
  export default ProductDetailModal;
  