import React, { useEffect, useState } from "react";

import DataTable from "react-data-table-component";
import { Link } from "react-router-dom";
import { Badge, Button, Col, Container, Row } from "react-bootstrap";
import { connect } from "react-redux";
import { Chip } from "@mui/material";

import { Actions, PageRoutes, SortOrderValue, SortType } from "../../constants";
import {
  getPagingCategories,
  getCategoryById,
  setCategoryPagingQuery,
  setProductPagingQuery,
  insertCategory,
  updateCategory,
  deleteCategory,
} from "../../actions";
import { Category } from "../../types/model";

import CategoryPagingQuery from "../../types/form/CategoryPagingQuery";
import CategoryFilter from "../../components/CategoryFilter";

import "./index.css";
import "bootstrap/dist/css/bootstrap.min.css";
import DetailModal from "../../components/DetailModal";
import ProductPagingQuery from "../../types/form/ProductPagingQuery";
import InsertModal from "../../components/InsertModal";
import { CategoryForm } from "../../types/form/CategoryForm";
import { ShowDialog, ShowNotification } from "../../helpers";
import { ValidationError } from "../../types/model/ValidationError";
import EditModal from "../../components/EditModal";
const CategoryPage: React.FC<any> = (props) => {
  const {
    getPagingCategories,
    pagingCategory,
    actionType,
    getCategoryById,
    category,
    message,
    setCategoryPagingQuery,
    categoryPagingQuery,
    setProductPagingQuery,
    updateCategory,
    validationErrors,
    insertCategory,
    deleteCategory,
  } = props;
  
  const [modalShow, setModalShow] = useState(false);
  const [insertModalShow, setInsertModalShow] = useState(false);
  const [editModalShow, setEditModalShow] = useState(false);
  const [onChanging, setOnChanging] = useState(true);
  const [loading, setLoading] = useState(false);
  const [currentCategoryClicked, setCurrentCategoryClicked] = useState("");

  const [pagingForm, setPagingForm] = useState<CategoryPagingQuery>(
    (categoryPagingQuery as CategoryPagingQuery) ?? {
      Search: "",
      Page: 1,
      IsParent: undefined,
      SortOrder: 0,
      Limit: 10,
    }
  );

  useEffect(() => {
    if (actionType !== Actions.DONE_SET_CATEGORY_PAGING_QUERY)
      setCategoryPagingQuery(pagingForm);
  }, [pagingForm]);

  useEffect(() => {
    if (onChanging) {
      setLoading(true);
      getPagingCategories(pagingForm);
      setOnChanging(false);
    }
  }, [getPagingCategories, onChanging]);

  useEffect(() => {
    if (currentCategoryClicked) getCategoryById(currentCategoryClicked);
  }, [currentCategoryClicked]);

  useEffect(() => {
    switch (actionType) {
      case Actions.UPDATED_CATEGORY:
        setOnChanging(true);
        break;
      default:
        break;
    }
  }, [actionType]);

  if (loading && actionType === Actions.GOT_PAGING_CATEGORIES)
    setLoading(false);

  const showModal = (id: string) => {
    setModalShow(true);
    setCurrentCategoryClicked(id);
  };

  const hideModel = () => {
    setModalShow(false);
    setCurrentCategoryClicked("");
  };

  const hideInsertModel = () => {
    setInsertModalShow(false);
  };

  const showEditModal = (id: number) => {
    getCategoryById(id);
    setEditModalShow(true);
  };

  const hideEditModel = () => {
    setEditModalShow(false);
  };

  const handlePageChange = (page: number) => {
    setPagingForm({ ...pagingForm, Page: page });
    setOnChanging(true);
  };

  const handlePerRowsChange = async (newPerPage: number, page: number) => {
    setPagingForm({ ...pagingForm, Limit: newPerPage, Page: page });
    setOnChanging(true);
  };

  const handleSortChange = async (column: any, sortDirection: string) => {
    var sortOrderType = `${column.id}_${sortDirection.toUpperCase()}`;
    setPagingForm({ ...pagingForm, SortOrder: SortOrderValue[sortOrderType] });
    setOnChanging(true);
  };

  const setProductPagingCategory = (categoryId: number) => {
    var query = {
      Search: "",
      CategoryId: categoryId,
      Page: 1,
      Rating: 0,
      SortOrder: 0,
      Limit: 10,
    };
    setProductPagingQuery(query);
  };

  const confirmInsert = (form: CategoryForm) => {
    insertCategory(form);
    hideInsertModel();
  };

  const confirmEdit = (id: string, form: CategoryForm) => {
    updateCategory(id, form);
    hideEditModel();
  };

  const confirmDelete = (id: number) => {
    setOnChanging(true);
    deleteCategory(id);
  };

  const columns = [
    {
      id: SortType.NAME,
      name: "Name",
      sortable: true,
      cell: (row: Category) => <span>{row.Name}</span>,
    },
    {
      name: "Is Parent",
      cell: (row: Category) => (
        <span style={{ fontSize: "32px" }}>
          {row.IsParent ? (
            <Chip label="True" color="success" />
          ) : (
            <Chip label="False" color="primary" />
          )}
        </span>
      ),
    },
    {
      name: "Parent",
      cell: (row: Category) => (
        <span>{row.IsParent ? "" : row.Parent.Name}</span>
      ),
    },
    {
      name: "Action",
      cell: (row: Category) => (
        <span>
          <div className="text-end">
            <button
              type="button"
              onClick={() => showEditModal(row.CategoryId)}
              className="btn btn-outline-info"
            >
              <i className="fa-solid fa-pen"></i>
            </button>
            <button
              type="button"
              onClick={() => 
                ShowDialog("Are you sure", <p>You wanna delete this</p>, () =>
                  confirmDelete(row.CategoryId)
                )
              }
              className="btn btn-outline-danger"
            >
              <i className="fa-solid fa-trash"></i>
            </button>
            <button
              type="button"
              onClick={() => showModal(row.CategoryId.toString())}
              className="btn btn-outline-primary"
            >
              <i className="fas fa-eye"></i>
            </button>
          </div>
        </span>
      ),
      width: "fit-content",
    },
  ];
  return (
    <div>
      <div className="page-title">
        <h3>Categories</h3>
        <Button
          variant="outline-primary"
          onClick={() => setInsertModalShow(true)}
        >
          <i className="fa-solid fa-plus"></i> Add
        </Button>
      </div>
      <hr />
      <Container fluid={true}>
        <Row>
          <Col xl={2} lg={3}>
            <CategoryFilter
              pagingForm={pagingForm}
              setPagingForm={setPagingForm}
              onChanging={onChanging}
              setOnChanging={setOnChanging}
              loading={loading}
              setLoading={setLoading}
            />
          </Col>
          <Col xl={10} lg={9}>
            <DataTable
              className="data-table"
              columns={columns}
              data={pagingCategory?.Items}
              pagination={true}
              responsive={true}
              customStyles={customStyles}
              paginationServer
              paginationTotalRows={pagingCategory?.TotalItems}
              onChangeRowsPerPage={handlePerRowsChange}
              onChangePage={handlePageChange}
              onSort={handleSortChange}
            />
          </Col>
        </Row>
      </Container>

      {actionType === Actions.GOT_CATEGORY_BY_ID ? (
        <DetailModal.Category
          show={modalShow}
          onHide={hideModel}
          category={category}
          actionType={actionType}
          setProductPagingCategory={setProductPagingCategory}
        />
      ) : (
        <></>
      )}
      <InsertModal
        show={insertModalShow}
        onHide={hideInsertModel}
        confirmInsert={confirmInsert}
      />
      <EditModal
        category={category}
        show={editModalShow}
        onHide={hideEditModel}
        confirmEdit={confirmEdit}
      />
    </div>
  );
};
const mapDispatchToProps = (state: any) => {
  return {
    ...state.categoryReducer,
    ...state.productReducer,
  };
};
export default connect(mapDispatchToProps, {
  getPagingCategories,
  getCategoryById,
  setCategoryPagingQuery,
  setProductPagingQuery,
  insertCategory,
  updateCategory,
  deleteCategory,
})(CategoryPage);

const customStyles = {
  rows: {
    style: {
      minHeight: "72px",
    },
  },
  headCells: {
    style: {
      backgroundColor: "gray",
      color: "white",
      fontWeight: "bold",
      fontSize: "16px",
      alignItems: "left",
    },
  },
  cells: {
    style: {
      fontWeight: "600",
      paddingTop: "8px",
      paddingBottom: "8px",
    },
  },
};
