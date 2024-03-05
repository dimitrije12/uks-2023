import React from 'react';
import { Navigate } from 'react-router-dom';
import PageWrapper from '../components/pageWrapper/pageWrapper';
import useIsAuthenticated from '../hooks/useIsAuthenticated';

const PrivateRoute = ({ element }) => {
  const { loading, isAuthenticated } = useIsAuthenticated();

  if (loading) {
    return <PageWrapper />;
  }

  console.log(isAuthenticated);

  return <>{isAuthenticated ? element : <Navigate to="/login" />}</>;
};
export default PrivateRoute;
