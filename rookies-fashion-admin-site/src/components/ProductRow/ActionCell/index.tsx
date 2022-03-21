import { ShowDialog } from "../../../helpers";

import DetailModal from "../../DetailModal";
import { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link } from "react-router-dom";
import { PageRoutes } from "../../../constants";

const ActionCell = ({ product, onDeleteAccepted, showModal }: any) => {
  return (
    <span>
      <div className="text-end">
        <Link to={PageRoutes.PRODUCT_EDIT + `/${product.ProductId}`}>
          <button type="button" className="btn btn-outline-info">
            <i className="fa-solid fa-pen"></i>
          </button>
        </Link>
        <button
          type="button"
          onClick={() =>
            ShowDialog("Are you sure", <p>You wanna delete this</p>, () =>
              onDeleteAccepted(product.ProductId)
            )
          }
          className="btn btn-outline-danger"
        >
          <i className="fa-solid fa-trash"></i>
        </button>
        <button
          type="button"
          onClick={() => showModal(product.ProductId)}
          className="btn btn-outline-primary"
        >
          <i className="fas fa-eye"></i>
        </button>
      </div>
    </span>
  );
};

export default ActionCell;
