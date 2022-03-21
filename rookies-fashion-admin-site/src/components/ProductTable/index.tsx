import DataTable from "react-data-table-component";
import { Product } from "../../types/model";
import { SortOrderValue, SortType } from "../../constants";
import ProductRow from "../ProductRow";
import "./index.css";

const ProductTable = ({
  pagingProduct,
  pagingForm,
  setPagingForm,
  setOnChanging,
  loading,
  showModal,
  onDeleteAccepted
}: any) => {

  const columns = [
    {
      name: "Thumbnail",
      cell: (row: Product) => <ProductRow.Thumbnail product={row} />,
    },
    {
      id: SortType.NAME,
      name: "Name",
      sortable: true,
      cell: (row: Product) => <ProductRow.Name product={row} />,
    },
    {
      id: SortType.CREATED_DATE,
      name: "Created Date",
      sortable: true,
      cell: (row: Product) => <ProductRow.CreatedDate product={row} />,
    },
    {
      id: SortType.PRICE,
      sortable: true,
      name: "Price",
      cell: (row: Product) => <ProductRow.Price product={row} />,
    },
    {
      id: SortType.RATING,
      name: "Rating",
      sortable: true,
      cell: (row: Product) => <ProductRow.Rating product={row} />,
    },
    {
      name: "Category",
      cell: (row: Product) => (
        <ProductRow.Category
          product={row}
          handleCategoryClick={handleCategoryClick}
        />
      ),
    },
    {
      name: "Action",
      cell: (row: Product) => (
        <ProductRow.Action
          product={row}
          onDeleteAccepted={onDeleteAccepted}
          showModal={showModal}
        />
      ),
      width: "fit-content",
    },
  ];

  const handleCategoryClick = (value: any) => {
    setPagingForm({ ...pagingForm, CategoryId: value });
    setOnChanging(true);
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

  return (
    <DataTable
      className="data-table"
      columns={columns}
      data={pagingProduct?.Items}
      pagination={true}
      responsive={true}
      customStyles={customStyles}
      paginationServer
      progressPending={loading}
      paginationTotalRows={pagingProduct?.TotalItems}
      onChangeRowsPerPage={handlePerRowsChange}
      onChangePage={handlePageChange}
      onSort={handleSortChange}
    />
  );
};
export default ProductTable;

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
