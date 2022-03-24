import { Navbar, Container, NavDropdown, Nav } from "react-bootstrap";
import {
  ProSidebar,
  Menu,
  MenuItem,
  SubMenu,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
} from "react-pro-sidebar";
import "react-pro-sidebar/dist/css/styles.css";
import "./index.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Link, BrowserRouter } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHome } from "@fortawesome/free-solid-svg-icons";
import { PageRoutes } from "../../constants";
import { connect } from "react-redux";
import { loginRedirect, loginRedirectCalback } from "../../actions";
const SideBar: React.FC<any> = (props) => {
  const { loginRedirect, loginRedirectCallback } = props;
  return (
    <ProSidebar breakPoint="md">
      <SidebarHeader>
        <div className="sidebar-header">Rookies Fashion</div>
      </SidebarHeader>
      <SidebarContent>
        <Menu iconShape="circle">
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
          >
            <Link to={PageRoutes.PRODUCT_LIST}>Products</Link>
          </MenuItem>
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
          >
            <Link to={PageRoutes.CATEGORY_LIST}>Categories</Link>
          </MenuItem>
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
          >
            
            <Link to={PageRoutes.USER}>Users</Link>
            
          </MenuItem>
        </Menu>
      </SidebarContent>

      <SidebarFooter style={{ textAlign: "center" }}>
        <div
          className="sidebar-btn-wrapper"
          style={{
            padding: "20px 24px",
          }}
        >
          {/* <a onClick={() => loginRedirect()}>Login</a> */}
        </div>
      </SidebarFooter>
    </ProSidebar>
  );
};

const mapDispatchToProps = (state: any) => {
  return {
    ...state.authReducer,
  };
};
export default connect(mapDispatchToProps, {
  loginRedirect,
  loginRedirectCalback,
})(SideBar);
