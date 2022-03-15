import { useReducer } from "../../../hooks/AsyncHookService";
import { Container, Table, Button, Row, Col, Card } from "react-bootstrap";
import DataTable from "react-data-table-component";
import { connect } from "react-redux";
import { getProducts } from "../../../actions";
import { confirmAlert } from "react-confirm-alert"; // Import
import "react-confirm-alert/src/react-confirm-alert.css"; // Import css
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Product } from "../../../types/model";

const List: React.FC<any> = (props) => {
  const { getProducts, products } = props;
  const onDeleteAccepted = (id: number) => {
    console.log("OK DELETE " + id);
  };
  const customStyles = {
    rows: {
      style: {
        minHeight: "72px", // override the row height
      },
    },
    headCells: {
      style: {
        paddingLeft: "8px", // override the cell padding for head cells
        paddingRight: "8px",
      },
    },
    cells: {
      style: {
        paddingTop: "8px", // override the cell padding for data cells
        paddingBottom: "8px",
      },
    },
  };
  const columns = [
    {
      name: "Thumbnail",
      cell: (row: Product) => (
        <img className="product-thumbnail" src={row.Thumbnail[0]?.ImageUrl} />
      ),
      sortable: true,
    },
    {
      name: "Name",
      selector: (row: Product) => row.Name,
      sortable: true,
    },
    {
      name: "Category",
      selector: (row: Product) => row.Category.Name,
      sortable: true,
    },
    {
      name: "Price",
      selector: (row: Product) => "$" + row.Price,
      sortable: true,
      right: true,
    },
    {
      name: "Colors",
      selector: (row: Product) =>
        row.Colors.reduce((out, val) => out + ` ${val.Name}`, ""),
      sortable: true,
      right: true,
    },
    {
      name: "Sizes",
      selector: (row: Product) =>
        row.Sizes.reduce((out, val) => out + ` ${val.Name}`, ""),
      sortable: true,
      right: true,
    },
    {
      button: true,
      cell: (row: Product) => (
        <div className="text-end">
          <a href="" className="btn btn-outline-info btn-rounded">
            <i className="fas fa-pen"></i>
          </a>
          <button
            type="button"
            onClick={() =>
              ShowDialog(
                "Are you sure",
                "You wanna delete this",
                onDeleteAccepted,
                row.ProductId
              )
            }
            className="btn btn-outline-danger btn-rounded"
          >
            <i className="fas fa-trash"></i>
          </button>
        </div>
      ),
      sortable: false,
      right: true,
    },
  ];
  useReducer(getProducts);

  return (
    <Container>
      <div className="page-title">
        <h3>
          Products
          <a
            href="/product/insert"
            className="btn btn-sm btn-outline-primary float-end"
          >
            <i className="fas fa-user-shield"></i> Add
          </a>
        </h3>
      </div>
      <div className="box box-primary">
        <div className="box-body">
          <DataTable
            columns={columns}
            data={products}
            progressPending={!products}
            pagination={true}
            // selectableRows
            customStyles={customStyles}
          />
        </div>
      </div>
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

const ShowDialog = (
  title: string,
  message: string,
  onAccepted?: any,
  id?: any
) => {
  confirmAlert({
    customUI: ({ onClose }) => {
      return (
        <div className="custom-ui">
          <h1>{title}</h1>
          <p>{message}</p>
          <div className="dialog-button">
            <button
              onClick={() => {
                onClose();
              }}
            >
              No
            </button>
            <button
              onClick={() => {
                onAccepted(id);
                onClose();
              }}
            >
              Yes
            </button>
          </div>
        </div>
      );
    },
  });
};
