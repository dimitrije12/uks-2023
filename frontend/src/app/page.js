'use client';
import PageWrapper, {
  PAGE_WRAPPER_ORIENTATION,
} from '@/layouts/pageWrapper/pageWrapper';
import { useRouter } from 'next/navigation';
import { useEffect } from 'react';
import { useSelector } from 'react-redux';

export default function Home() {
  const isLoggedIn = useSelector((state) => state?.user?.user?.username);
  const { push } = useRouter();

  useEffect(() => {
    if (!isLoggedIn) {
      push('/login');
    }
  }, [isLoggedIn]);

  return (
    <PageWrapper orientation={PAGE_WRAPPER_ORIENTATION.TopCenter}>
      <div className="mx-auto px-4 mt-40 h-full">
        <h1 className="text-3xl font-bold mb-4 text-center">Home Page</h1>
        <p className="text-lg mb-4 text-center">Welcome to the home page!</p>
      </div>
    </PageWrapper>
  );
}
