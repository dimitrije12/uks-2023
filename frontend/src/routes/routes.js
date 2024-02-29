import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home from '../pages/home/home';
import Login from '../pages/login/login';
import Registration from '../pages/registration/registration';
import TestPage from '../pages/test/test';
import PrivateRoute from './privateRoute';
import PublicRoute from './publicRoute';

const PrivateRoutes = () => {
  return [
    <Route
      key="test"
      path="/test"
      element={<PrivateRoute element={<TestPage />} />}
    ></Route>,
  ];
};
const PublicRoutes = () => {
  return [
    <Route
      key="login"
      path="/login"
      element={<PublicRoute element={<Login />} />}
    ></Route>,
    <Route
      key="registration"
      path="/registration"
      element={<PublicRoute element={<Registration />} />}
    ></Route>,
  ];
};

const WebRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      {[...PrivateRoutes()]}
      {[...PublicRoutes()]}
    </Routes>
  );
};

export default WebRoutes;
