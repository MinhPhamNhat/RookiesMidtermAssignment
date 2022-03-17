import { useReducer } from "../../../hooks/AsyncHookService";
import { Container, Table, Button, Row, Col, Card } from "react-bootstrap";
import { connect } from "react-redux";
import { getPagingProducts } from "../../../actions";
import ProductTable from "../../../components/ProductTable";
import { Link } from "react-router-dom";
import { useEffect, useState } from "react";
import TableFilter from "../../../components/TableFilter";
import "react-confirm-alert/src/react-confirm-alert.css"; // Import css
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { PagingForm } from "../../../types/form/PagingForm";
import { Actions } from "../../../constants";

const ProductList: React.FC<any> = (props) => {
  const { pagingProduct, actionType, getPagingProducts } = props;
  const [pagingForm, setPagingForm] = useState<PagingForm>({
    Search: "",
    CategoryId: 0,
    Page: 1,
    Rating: 0,
    SortOrder: 0,
    Limit: 10,
  });
  const [onChanging, setOnChanging] = useState(true);
  const [loading, setLoading] = useState(false);

  console.log(pagingProduct)
  useEffect(() => {
    if (onChanging) {
      setLoading(true);
      getPagingProducts(pagingForm);
      setOnChanging(false);
    }
  }, [getPagingProducts, onChanging, pagingProduct]);

  if (loading && actionType == Actions.GOT_PAGING_PRODUCTS) setLoading(false);
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
            <TableFilter
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
              pagingProduct={pagingProduct}
              pagingForm={pagingForm}
              setPagingForm={setPagingForm}
              onChanging={onChanging}
              setOnChanging={setOnChanging}
              loading={loading}
              setLoading={setLoading}
            />
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
