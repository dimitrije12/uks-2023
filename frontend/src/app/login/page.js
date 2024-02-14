'use client'; // This is a client component 👈🏽

import Button from '@/components/button/button';
import Input from '@/components/input/input';
import { publicRoute } from '@/components/privateRoute/privateRoute';
import PageWrapper from '@/layouts/pageWrapper/pageWrapper';
import { login } from '@/store/reducers/user/thunk';
import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { useDispatch } from 'react-redux';
import * as Yup from 'yup';
import styles from './login.module.scss';

const Login = () => {
  const dispatch = useDispatch();
  const [user, setUser] = useState({ username: '', password: '' });
  const [errors, setErrors] = useState({});
  const [isLoading, setIsLoading] = useState(false);
  const { push } = useRouter();

  const schema = Yup.object().shape({
    username: Yup.string().required('Username is required'),
    password: Yup.string().required('Password is required'),
  });

  const isFormValid = async () => {
    try {
      await schema.validate(user, { abortEarly: false });
      setErrors({});
      return true;
    } catch (error) {
      const validationErrors = {};
      error.inner.forEach((e) => {
        validationErrors[e.path] = e.message;
      });
      setErrors(validationErrors);
      return false;
    }
  };

  const onSubmitClick = async () => {
    if (await isFormValid()) {
      setIsLoading(true);

      const res = await dispatch(login(user));

      if (res?.error?.code === 'ERR_BAD_RESPONSE') {
        setErrors({
          password: 'Wrong username or password. Please try again.',
        });
      } else if (res?.payload?.accessToken) {
        push('/');
      }

      setIsLoading(false);
    }
  };

  const onInputChange = async (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
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
              labelContent="Your username"
              labelFor="username"
              type="text"
              name="username"
              id="username"
              value={user.username}
              placeholder="username"
              onChange={(event) => onInputChange(event)}
              errorMessage={errors.username}
            />

            <Input
              labelContent="Password"
              labelFor="password"
              type="password"
              name="password"
              id="password"
              value={user.password}
              placeholder="••••••••"
              onChange={(event) => onInputChange(event)}
              errorMessage={errors.password}
            />
            <div className="flex items-center justify-end">
              <a
                href="#"
                className="text-sm font-medium text-blue-600 hover:underline dark:text-blue-500"
              >
                Forgot password?
              </a>
            </div>
            <Button
              onClick={onSubmitClick}
              isLoading={isLoading}
              className="w-full"
            >
              Submit
            </Button>
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

export default publicRoute(Login);
