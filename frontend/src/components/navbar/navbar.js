import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { setUser } from '../../store/reducers/user/userSlice';
import CustomLink, { LINK_COLORS } from '../link/link';
import Button from '../button/button';

const Navbar = () => {
  const userLoggedIn = useSelector((state) => state.user.user.username);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const onLogOutClick = () => {
    dispatch(setUser({}));
    localStorage.clear();
    navigate('/login');
  };

  return (
    <nav className="relative px-4 py-4 flex justify-between items-center bg-white shadow-sm">
      <a className="text-3xl font-bold leading-none" href="/">
        UKS Git
      </a>
      {!userLoggedIn ? (
        <>
          <CustomLink
            color={LINK_COLORS.Secondary}
            content="Sign in"
            className="ml-auto mr-3"
            to="/login"
          />
          <CustomLink
            color={LINK_COLORS.Primary}
            content="Sign up"
            to="/registration"
          />
        </>
      ) : (
        <>
          {' '}
          <label className="ml-auto pr-4"> {userLoggedIn}</label>
          <Button
            linkVariation="primary"
            className="w-auto"
            onClick={onLogOutClick}
          >
            Log Out
          </Button>
        </>
      )}
    </nav>
  );
};

export default Navbar;
