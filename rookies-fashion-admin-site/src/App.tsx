import { connect } from "react-redux";
import { BrowserRouter as Router } from "react-router-dom";
import SideBar from "./components/Sidebar";
import MyRoutes from "./routes";
import { useEffect } from "react";
import { Actions } from "./constants";
import { ShowNotification } from "./helpers";
import { ValidationError } from "./types/model/ValidationError";
import { ReactNotifications, Store } from "react-notifications-component";
import 'react-notifications-component/dist/theme.css'

const App:React.FC<any> = (props) => {
  
  return (
    <Router>
    <div className="main-wrapper">
        <div
        className="sidebar-warrper"
        ref={(element) => {
            if (element?.parentElement)
            element.parentElement.style.paddingLeft =
                element?.clientWidth + "px";
        }}>
        <ReactNotifications />
        <SideBar />
        </div>
        <div className="body-warrper">
        <MyRoutes />
        </div>
    </div>
    </Router>
  );
};

export default App;
