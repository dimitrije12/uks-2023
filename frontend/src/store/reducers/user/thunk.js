import { createAsyncThunk } from '@reduxjs/toolkit';
import { userService } from '../../../services/user.service';

export const login = createAsyncThunk('auth/login', async (user) => {
  return {
    username: user?.username,
    accessToken: await userService.login(user),
  };
});

export const register = createAsyncThunk('auth/register', async (user) => {
  return {
    username: user?.username,
    response: await userService.register(user),
  };
});
