'use client'; // This is a client component 👈🏽
import Input from '@/components/input/input';
import styles from './login.module.scss';
import Button from '@/components/button/button';
import { useDispatch } from 'react-redux';
import { setUser } from '@/store/reducers/user/userSlice';
import PageWrapper from '@/layouts/pageWrapper/pageWrapper';

const Login = () => {
  const dispatch = useDispatch();

  const onSubmitClick = (event) => {
    dispatch(setUser({ username: 'test', password: '123' }));
  };

  return (
    <PageWrapper>
      <div className={styles.container}>
        <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
            Sign in to your account
          </h1>
          <form className="space-y-4 md:space-y-6" action="#">
            <Input
              labelContent="Your email"
              labelFor="email"
              type="email"
              name="email"
              id="email"
              placeholder="name@company.com"
            />
            <Input
              labelContent="Password"
              labelFor="password"
              type="password"
              name="password"
              id="password"
              placeholder="••••••••"
            />

            <div className="flex items-center justify-end">
              <a
                href="#"
                className="text-sm font-medium text-blue-600 hover:underline dark:text-blue-500"
              >
                Forgot password?
              </a>
            </div>
            <Button onClick={onSubmitClick}>Submit</Button>
            <p className="text-sm font-light text-gray-500 dark:text-gray-400">
              Don’t have an account yet?{' '}
              <a
                href="/registration"
                className="font-medium text-blue-600 hover:underline dark:text-blue-500"
              >
                Sign up
              </a>
            </p>
          </form>
        </div>
      </div>
    </PageWrapper>
  );
};

export default Login;
