import { Container, Row, Col } from "react-bootstrap";
import { connect } from "react-redux";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

import {
  getPagingProducts,
  getProductById,
  deleteProduct,
} from "../../../actions";
import { PagingForm } from "../../../types/form/PagingForm";
import { Actions } from "../../../constants";

import ProductFilter from "../../../components/ProductFilter";
import DetailModal from "../../../components/DetailModal";
import ProductTable from "../../../components/ProductTable";

import "react-confirm-alert/src/react-confirm-alert.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { ShowNotification } from "../../../helpers";

const ProductList: React.FC<any> = (props) => {
  const {
    pagingProduct,
    product,
    actionType,
    getPagingProducts,
    getProductById,
    deleteProduct,
    message
  } = props;

  const [pagingForm, setPagingForm] = useState<PagingForm>({
    Search: "",
    CategoryId: 0,
    Page: 1,
    Rating: 0,
    SortOrder: 0,
    Limit: 10,
  });

  const [modalShow, setModalShow] = useState(false);
  const [onChanging, setOnChanging] = useState(true);
  const [loading, setLoading] = useState(false);
  const [currentProductClicked, setCurrentProductClicked] = useState("");

  useEffect(() => {
    if (onChanging) {
      setLoading(true);
      getPagingProducts(pagingForm);
      setOnChanging(false);
    }
  }, [getPagingProducts, onChanging, pagingProduct]);

  useEffect(() => {
    if (currentProductClicked) getProductById(currentProductClicked);
  }, [currentProductClicked]);
  
  useEffect(() => {
    console.log(props)
    if (actionType === Actions.DELETED_PRODUCT){
      ShowNotification(message, "Success", "success");
      setOnChanging(true)
    }
  }, [actionType]);

  const showModal = (id: string) => {
    setModalShow(true);
    setCurrentProductClicked(id);
  };

  const hideModel = () => {
    setModalShow(false);
    setCurrentProductClicked("");
  };
  
  const onDeleteAccepted = (id: string) => {
    deleteProduct(id)
  };

  if (loading && actionType === Actions.GOT_PAGING_PRODUCTS) setLoading(false);

  return (
    <div>
      <div className="page-title">
        <h3>Products</h3>
        <Link to="/product/insert" className="btn btn-outline-primary">
          <i className="fa-solid fa-plus"></i> Add
        </Link>
      </div>
      <hr />
      <Container fluid={true}>
        <Row>
          <Col xl={2} lg={3}>
            <ProductFilter
              pagingForm={pagingForm}
              setPagingForm={setPagingForm}
              onChanging={onChanging}
              setOnChanging={setOnChanging}
              loading={loading}
              setLoading={setLoading}
            />
          </Col>
          <Col xl={10} lg={9}>
            <ProductTable
              showModal={showModal}
              pagingProduct={pagingProduct}
              pagingForm={pagingForm}
              setPagingForm={setPagingForm}
              onChanging={onChanging}
              setOnChanging={setOnChanging}
              loading={loading}
              setLoading={setLoading}
              onDeleteAccepted={onDeleteAccepted}
            />
          </Col>
        </Row>
      </Container>
      {actionType === Actions.GOT_PRODUCT_BY_ID ? (
        <DetailModal
          show={modalShow}
          onHide={hideModel}
          product={product}
          actionType={actionType}
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
  getPagingProducts,
  getProductById,
  deleteProduct,
})(ProductList);
