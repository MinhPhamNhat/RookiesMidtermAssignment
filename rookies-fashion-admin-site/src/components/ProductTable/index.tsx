import { useEffect, useState } from "react";
import DataTable from "react-data-table-component";
import { Link } from "react-router-dom";
import { ratingStar, ShowDialog } from "../../helpers";
import { Product } from "../../types/model";
import { PagingForm } from "../../types/form/PagingForm";
import "./index.css";
import { Actions, SortOrderValue, SortType } from "../../constants";
const ProductTable = (props: any) => {
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
        backgroundColor: "gray",
        color: "white",
        fontWeight: "bold",
        fontSize: "16px",
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

  const columns = [
    {
      name: "Thumbnail",
      cell: (row: Product) => (
        <img className="product-thumbnail" src={row.Thumbnail[0]?.ImageUrl} />
      ),
    },
    {
      id: SortType.NAME,
      name: "Name",
      sortable: true,
      selector: (row: Product) => row.Name,
      cell: (row: Product) => <p title={row.Name}>{row.Name}</p>,
    },
    {
      id: SortType.CREATED_DATE,
      name: "Created Date",
      sortable: true,
      cell: (row: Product) => (
        <span>
          {new Date(row.CreatedDate).toLocaleTimeString("en-US", {
            year: "numeric",
            month: "long",
            day: "numeric",
            hour: "numeric",
            minute: "numeric",
          })}
        </span>
      ),
    },
    {
      id: SortType.PRICE,
      sortable: true,
      name: "Price",
      selector: (row: Product) => "$" + row.Price,
    },
    {
      id: SortType.RATING,
      name: "Rating",
      sortable: true,
      selector: (row: Product) => row.AvgRating,
      cell: (row: Product) => (
        <div className="product-rating">
          <div className="rating-stars">{ratingStar(row.AvgRating)}</div>
          <div className="rating-value">{row.AvgRating}/5</div>
        </div>
      ),
    },
    {
      name: "Category",
      cell: (row: Product) => (
        <p>
          {!row.Category.IsParent ? (
            <Link to="/product">{row.Category.Parent.Name}, </Link>
          ) : (
            <></>
          )}
          {<Link to="/product">{row.Category.Name}</Link>}
        </p>
      ),
    },
    {
      name: "Action",
      cell: (row: Product) => (
        <div className="text-end">
          <button type="button" className="btn btn-outline-info btn-rounded">
            <i className="fa-solid fa-pen"></i>
          </button>
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
            <i className="fa-solid fa-trash"></i>
          </button>
          <button type="button" className="btn btn-outline-primary btn-rounded">
            <i className="fas fa-eye"></i>
          </button>
        </div>
      ),
      width: "fit-content",
    },
  ];

  const { getPagingProducts, pagingProduct, actionType } = props;

  const [pagingForm, setPagingForm] = useState<PagingForm>({
    Search: "",
    CategoryId: undefined,
    Page: 1,
    Rating: undefined,
    SortOrder: 0,
    Limit: 10,
  });

  console.log(pagingForm)
  const [onChanging, setOnChanging] = useState(true);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (onChanging) {
      setLoading(true);
      getPagingProducts(pagingForm);
      setOnChanging(false);
    }
  }, [getPagingProducts, onChanging, pagingProduct]);

  if (loading && actionType == Actions.GOT_PAGING_PRODUCTS) setLoading(false);

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

  return (
    <DataTable
      columns={columns}
      data={pagingProduct?.Items}
      pagination={true}
      responsive={true}
      customStyles={customStyles}
      progressPending={loading}
      paginationServer
      paginationTotalRows={pagingProduct?.TotalItems}
      onChangeRowsPerPage={handlePerRowsChange}
      onChangePage={handlePageChange}
      onSort={handleSortChange}
    />
  );
};
export default ProductTable;
