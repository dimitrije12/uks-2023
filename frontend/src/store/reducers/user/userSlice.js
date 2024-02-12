import { localStorageService } from '@/services/localStorage.service';
import { createSlice } from '@reduxjs/toolkit';
import { login } from './thunk';

const initialState = {
  user: {},
  error: {},
};

const user = createSlice({
  name: 'user',
  initialState,
  reducers: {
    setUser(state, action) {
      state.user = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(login.fulfilled, (state, action) => {
      const { user = {}, accessToken = '', refreshToken = '' } = action.payload;
      storeUserToLocalStorage(user?.username, accessToken, refreshToken);
      state.user = user;
      state.error = null;
    });

    builder.addCase(login.rejected, (state, action) => {
      state.error = action.error;
    });
  },
});

export const { setUser } = user.actions;
export default user.reducer;

const storeUserToLocalStorage = (
  username = '',
  accessToken = '',
  refreshToken = ''
) => {
  localStorageService.set('username', username);
  localStorageService.setAccessToken(accessToken);
  localStorageService.setRefreshToken(refreshToken);
};
