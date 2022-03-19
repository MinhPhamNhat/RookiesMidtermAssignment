import React, { lazy, Suspense, useEffect, useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Loading from "../components/Loading";
import { PageRoutes } from "../constants";
import Product from "../pages/Product";

const Home = lazy(() => import("../pages/Home"));
const User = lazy(() => import("../pages/User"));

const SusspenseLoading: React.FC<any> = ({ children }) => {
  return <Suspense fallback={<Loading />}>{children}</Suspense>;
};

const MyRoutes = () => {
  return (
    <SusspenseLoading>
      <Routes>
        <Route path={PageRoutes.USER} element={<User />} />
        <Route path={PageRoutes.PRODUCT_LIST} element={<Product.List />} />
        <Route path={PageRoutes.PRODUCT_INSERT} element={<Product.Insert />} />
        <Route path={PageRoutes.PRODUCT_DETAIL+"/:id"} element={<Product.Detail />} />
        <Route path={PageRoutes.PRODUCT_EDIT+"/:id"} element={<Product.Edit />} />
        <Route path={PageRoutes.HOME} element={<Home />} />
      </Routes>
    </SusspenseLoading>
  );
};

export default MyRoutes;
