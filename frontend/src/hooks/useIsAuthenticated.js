import { useSelector } from 'react-redux';
import { isNotEmptyString } from '../utils/helpers';

const useIsAuthenticated = () => {
  const { loading, user } = useSelector((state) => state?.user);

  return {
    loading,
    isAuthenticated: isNotEmptyString(user?.username),
  };
};

export default useIsAuthenticated;
