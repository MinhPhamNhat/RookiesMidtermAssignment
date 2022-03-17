import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import reportWebVitals from "./reportWebVitals";
import { Provider } from "react-redux";
import MyRoutes from "./routes";
import { createStore, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import createSagaMiddleware from "redux-saga";
import reducers from "./reducers";
import { BrowserRouter as Router } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import sagaSagaLaydyGaga from "./sagas";
import { ReactNotifications } from "react-notifications-component";
import SideBar from "./components/Sidebar";
const sagaMiddleWare = createSagaMiddleware();

const store = createStore(
  reducers,
  composeWithDevTools(applyMiddleware(sagaMiddleWare))
);
sagaMiddleWare.run(sagaSagaLaydyGaga);
ReactDOM.render(
  <React.StrictMode>
    <ReactNotifications />
    <Provider store={store}>
      <Router>
        <div className="main-wrapper">
          <div
            className="sidebar-warrper"
            ref={(element) => {
              if (element?.parentElement)
                element.parentElement.style.paddingLeft =
                  element?.clientWidth + "px";
            }}
          >
            <SideBar />
          </div>
          <div className="body-warrper">
            <MyRoutes />
          </div>
        </div>
      </Router>
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);
// require('dotenv').config()

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
