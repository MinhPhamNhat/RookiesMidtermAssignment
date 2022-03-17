import { useReducer } from "../../../hooks/AsyncHookService";
import { Container, Table, Button, Row, Col, Card } from "react-bootstrap";
import { connect } from "react-redux";
import { getPagingProducts } from "../../../actions";
import ProductTable from "../../../components/ProductTable";
import { Link } from "react-router-dom";
import { useState } from "react";
import TableFilter from "../../../components/TableFilter";
import "react-confirm-alert/src/react-confirm-alert.css"; // Import css
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";

const ProductList: React.FC<any> = (props) => {
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
            <TableFilter />
          </Col>
          <Col xl={10} lg={9}>
            <ProductTable {...props} />
          </Col>
        </Row>
      </Container>
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
})(ProductList);
