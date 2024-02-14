'use client';
import Button from '@/components/button/button';
import Link, { LINK_COLORS } from '@/components/link/link';
import { setUser } from '@/store/reducers/user/userSlice';
import { useRouter } from 'next/navigation';
import { useDispatch, useSelector } from 'react-redux';

const Navbar = () => {
  const userLoggedIn = useSelector((state) => state.user.user.username);
  const dispatch = useDispatch();
  const { push } = useRouter();

  const onLogOutClick = () => {
    dispatch(setUser({}));
    localStorage.clear();
    push('/login');
  };

  return (
    <nav className="relative px-4 py-4 flex justify-between items-center bg-white shadow-sm">
      <a className="text-3xl font-bold leading-none" href="/">
        UKS Git
      </a>
      {!userLoggedIn ? (
        <>
          <Link
            color={LINK_COLORS.Secondary}
            content="Sign in"
            className="ml-auto mr-3"
            href="/login"
          />
          <Link
            color={LINK_COLORS.Primary}
            content="Sign up"
            href="/registration"
          />{' '}
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
