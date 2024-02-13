'use client';
import { useState } from 'react';
import Input from '@/components/input/input';
import styles from './registration.module.scss';
import Button from '@/components/button/button';

// This is a client component 👈🏽

const Registration = () => {
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [repeatPassword, setRepeatPassword] = useState('');
  const [passwordsMatch, setPasswordsMatch] = useState(true);

  const [emailError, setEmailError] = useState('');
  const [usernameError, setUsernameError] = useState('');
  const [passwordError, setPasswordError] = useState('');

  const validateEmail = () => {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setEmailError('Invalid email address');
      return false;
    }
    setEmailError('');
    return true;
  };

  const validateUsername = () => {
    if (username.length < 3) {
      setUsernameError('Username must be at least 3 characters long');
      return false;
    }
    setUsernameError('');
    return true;
  };

  const validatePassword = () => {
    if (password.length < 6) {
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

    const doPasswordsMatch = password === repeatPassword;
    setPasswordsMatch(doPasswordsMatch);

    if (
      isEmailValid &&
      isUsernameValid &&
      isPasswordValid &&
      doPasswordsMatch
    ) {
      // Poziv servisa
      console.log('Registration successful!');
    }
  };

  const handleUsernameChange = (e) => {
    setUsername(e.target.value);
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleRepeatPasswordChange = (e) => {
    setRepeatPassword(e.target.value);
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
                placeholder="name@company.com"
                onChange={handleEmailChange}
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
                placeholder="name@company.com"
                onChange={handleUsernameChange}
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
                placeholder="••••••••"
                onChange={handlePasswordChange}
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
                placeholder="••••••••"
                onChange={handleRepeatPasswordChange}
              />

              {!passwordsMatch && (
                <p className="text-sm text-red-500">
                  Passwords do not match. Please try again.
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
