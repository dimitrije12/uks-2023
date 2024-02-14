'use client';

import { localStorageService } from '@/services/localStorage.service';
import { setUser } from '@/store/reducers/user/userSlice';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';

const ContentWrapper = ({ children }) => {
  const dispatch = useDispatch();
  const username = useSelector((state) => state?.user?.user?.username);

  useEffect(() => {
    if (localStorageService.getAccessToken && !username) {
      dispatch(setUser({ username: localStorageService.get('username') }));
    }
  }, []);

  return (
    <div className="flex flex-col items-stretch min-h-screen w-screen">
      {children}
    </div>
  );
};

export default ContentWrapper;
