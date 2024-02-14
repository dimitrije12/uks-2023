'use client';
import { useState } from 'react';
import Input from '@/components/input/input';
import styles from './registration.module.scss';
import Button from '@/components/button/button';
import { register } from '@/store/reducers/user/thunk';
import { useDispatch } from 'react-redux';

// This is a client component 👈🏽

const Registration = () => {
  const dispatch = useDispatch();

  const [user, setUser] = useState({
    username: '',
    password: '',
    repeatPassword: '',
    email: '',
  });
  const [passwordsMatch, setPasswordsMatch] = useState(true);
  const [registerError, setRegisterError] = useState(false);

  const [emailError, setEmailError] = useState('');
  const [usernameError, setUsernameError] = useState('');
  const [passwordError, setPasswordError] = useState('');

  const validateEmail = () => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(user.email)) {
      setEmailError('Invalid email address');
      return false;
    }
    setEmailError('');
    return true;
  };

  const validateUsername = () => {
    if (user.username.length < 3) {
      setUsernameError('Username must be at least 3 characters long');
      return false;
    }
    setUsernameError('');
    return true;
  };

  const validatePassword = () => {
    if (user.password.length < 6) {
      setPasswordError('Password must be at least 6 characters long');
      return false;
    }
    setPasswordError('');
    return true;
  };

  const handleRegister = () => {
    const isEmailValid = validateEmail();
    const isUsernameValid = validateUsername();
    const isPasswordValid = validatePassword();

    const doPasswordsMatch = user.password === user.repeatPassword;
    setPasswordsMatch(doPasswordsMatch);

    if (
      isEmailValid &&
      isUsernameValid &&
      isPasswordValid &&
      doPasswordsMatch
    ) {
      const res = dispatch(register(user));

      if (res?.error?.code === 'ERR_BAD_RESPONSE') {
        setRegisterError(true);
      } else if (res?.payload?.response) {
        setRegisterError(false);
        console.log('Registration successful!');

        push('/');
      }

      // Poziv servisa
    }
  };

  const handleInputChange = async (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };

  return (
    <section className={styles.container}>
      <div>
        <div>
          <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
            <h1 className="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl dark:text-white">
              Create your account
            </h1>
            <form className="space-y-4 md:space-y-6" action="#">
              <Input
                labelContent="Your email"
                labelFor="email"
                type="email"
                name="email"
                id="email"
                value={user.email}
                placeholder="name@company.com"
                onChange={(event) => handleInputChange(event)}
              />
              {emailError && (
                <p className="text-sm text-red-500">{emailError}</p>
              )}
              <Input
                labelContent="Username"
                labelFor="username"
                type="text"
                name="username"
                id="username"
                value={user.username}
                placeholder="name@company.com"
                onChange={(event) => handleInputChange(event)}
              />
              {usernameError && (
                <p className="text-sm text-red-500">{usernameError}</p>
              )}
              <Input
                labelContent="Password"
                labelFor="password"
                type="password"
                name="password"
                id="password"
                value={user.password}
                placeholder="••••••••"
                onChange={(event) => handleInputChange(event)}
              />
              {passwordError && (
                <p className="text-sm text-red-500">{passwordError}</p>
              )}

              <Input
                labelContent="Repeat Password"
                labelFor="repeatPassword"
                type="password"
                name="repeatPassword"
                id="repeatPassword"
                value={user.repeatPassword}
                placeholder="••••••••"
                onChange={(event) => handleInputChange(event)}
              />

              {!passwordsMatch && (
                <p className="text-sm text-red-500">
                  Passwords do not match. Please try again.
                </p>
              )}

              {registerError && (
                <p className="text-sm text-red-500">
                  Email or username already exists. Please try another one.
                </p>
              )}

              <div className="flex items-center justify-end">
                <Button onClick={handleRegister}>Register</Button>
              </div>

              <p className="text-sm font-light text-gray-500 dark:text-gray-400">
                Already have an account?{' '}
                <a
                  href="/login"
                  className="font-medium text-blue-600 hover:underline dark:text-blue-500"
                >
                  Sign in
                </a>
              </p>
            </form>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Registration;
