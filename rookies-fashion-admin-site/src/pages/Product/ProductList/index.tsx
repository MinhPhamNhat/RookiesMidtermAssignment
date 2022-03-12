import { useReducer } from "../../../hooks/AsyncHookService";
import { productService } from "../../../services";
import { Product } from "../../../types/model";
import { Container, Table, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useEffect } from "react";
import { connect } from "react-redux";
import { getProducts } from "../../../actions";

import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";

const List: React.FC<any> = (props) => {
  const { getProducts, products } = props;
  useReducer(getProducts);

  return (
    <Container>
      <h1>Product List</h1>
      <Table responsive>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Category</th>
            <th>Price</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {products ? (
            products.map((a: Product) => (
              <tr key={a.ProductId}>
                <td>{a.ProductId}</td>
                <td>{a.Name}</td>
                <td>{a.Category.Name}</td>
                <td>${a.Price}</td>
                <td>{a.Description}</td>
                <td className="table-action">
                  <Link to={`edit/${a.ProductId}`}>Edit</Link>
                  <Link to="delete">Delete</Link>
                </td>
              </tr>
            ))
          ) : (
            <></>
          )}
        </tbody>
      </Table>
    </Container>
  );
};

const mapStateToProps = (state: any) => {
  return {
    ...state.productReducer,
  };
};

export default connect(mapStateToProps, {
  getProducts,
})(List);
