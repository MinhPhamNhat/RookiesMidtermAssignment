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
const SideBar = () => {
  return (
    <ProSidebar breakPoint="md">
      <SidebarHeader>
        <div className="sidebar-header">
          Rookies Fashion
        </div>
      </SidebarHeader>
      <SidebarContent>
        <Menu iconShape="circle">
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
            suffix={<span className="badge red">50</span>}
          >
            <Link to={PageRoutes.PRODUCT_LIST}>Products</Link>
          </MenuItem>
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
            suffix={<span className="badge red">10</span>}
          >
             <Link to={PageRoutes.CATEGORY_LIST}>Categories</Link>
          </MenuItem>
          <MenuItem
            icon={<FontAwesomeIcon icon={faHome} />}
            suffix={<span className="badge red">10</span>}
          >
            Users
          </MenuItem>
          <SubMenu
            prefix={<span className="badge gray">2</span>}
            title="Properties"
            icon={<FontAwesomeIcon icon={faHome} />}
          >
            <MenuItem>Colors</MenuItem>
            <MenuItem>Sizes</MenuItem>
          </SubMenu>
        </Menu>
      </SidebarContent>

      <SidebarFooter style={{ textAlign: "center" }}>
        <div
          className="sidebar-btn-wrapper"
          style={{
            padding: "20px 24px",
          }}
        >
          <a
            href="https://github.com/azouaoui-med/react-pro-sidebar"
            target="_blank"
            className="sidebar-btn"
            rel="noopener noreferrer"
          >
            <span
              style={{
                whiteSpace: "nowrap",
                textOverflow: "ellipsis",
                overflow: "hidden",
              }}
            >
              Source
            </span>
          </a>
        </div>
      </SidebarFooter>
    </ProSidebar>
  );
};

export default SideBar;
