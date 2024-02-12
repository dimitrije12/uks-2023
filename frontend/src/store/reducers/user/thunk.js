import { userService } from '@/services/user.service';
import { createAsyncThunk } from '@reduxjs/toolkit';

export const login = createAsyncThunk('auth/login', async (user) => {
  return await userService.login(user);
});
