import React from 'react';
import { Navigate } from 'react-router-dom';
import useIsAuthenticated from '../hooks/useIsAuthenticated';
import PageWrapper from '../components/pageWrapper/pageWrapper';

const PublicRoute = ({ element }) => {
  const { loading, isAuthenticated } = useIsAuthenticated();

  if (loading) {
    return <PageWrapper />;
  }

  return <>{!isAuthenticated ? element : <Navigate to="/" />}</>;
};
export default PublicRoute;
