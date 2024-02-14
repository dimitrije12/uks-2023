'use client';
import { useRouter } from 'next/navigation';
import { useEffect } from 'react';
import { useSelector } from 'react-redux';

export function privateRoute(Component) {
  return function PrivateRoute(props) {
    const isLoggedIn = useSelector((state) => state?.user?.user?.username);
    const router = useRouter();

    useEffect(() => {
      if (!isLoggedIn) {
        router.push('/login');
      }
    }, [isLoggedIn]);

    return <Component {...props} />;
  };
}
export function publicRoute(Component) {
  return function PublicRoute(props) {
    const isLoggedIn = useSelector((state) => state?.user?.user?.username);
    const router = useRouter();

    useEffect(() => {
      if (isLoggedIn) {
        router.push('/');
      }
    }, [isLoggedIn]);

    return <Component {...props} />;
  };
}
