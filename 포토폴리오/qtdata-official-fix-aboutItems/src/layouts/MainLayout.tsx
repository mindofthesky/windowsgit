import React from "react";
import Header from "../components/header/Header";
import Footer from "../components/footer/Footer";
import { Outlet } from "react-router-dom";
import ToTopBtn from "../utils/ToTopBtn";

const MainLayout = () => {
  return (
    <>
      <Header />
      <Outlet />
      <ToTopBtn />
      <Footer />
    </>
  );
};

export default MainLayout;
