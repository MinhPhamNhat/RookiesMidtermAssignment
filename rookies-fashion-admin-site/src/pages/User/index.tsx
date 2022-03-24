import { useEffect } from "react";
import DataTable from "react-data-table-component";
import { connect } from "react-redux";
import { getUsers } from "../../actions";
import { User } from "../../types/model";

const UserPage: React.FC<any> = (props) => {
  const { getUsers, user } = props;
  
  useEffect(() => {
    getUsers();
  }, [])

  const columns = [
    {
      name: "Name",
      sortable: true,
      cell: (row: User) => <span>{row.Name}</span>,
    },
    {
      name: "Email",
      sortable: true,
      cell: (row: User) => (<span>{row.Email}</span> ),
    },
    {
      name: "Username",
      sortable: true,
      cell: (row: User) => (<span>{row.UserName}</span> ),
    },
  ];
  return (
    <div>
      <div className="page-title">
        <h3>Users</h3>
      </div>
      <hr />
      <DataTable
        className="data-table"
        columns={columns}
        data={user}
        pagination={true}
        responsive={true}
        customStyles={customStyles}
        paginationServer
      />
    </div>
  );
};
const mapDispatchToProps = (state: any) => {
  return {
    ...state.userReducer,
  };
};
export default connect(mapDispatchToProps, {
  getUsers,
})(UserPage);

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
