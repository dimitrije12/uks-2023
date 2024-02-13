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
      if (action?.payload) {
        const { username = '', accessToken = '' } = action.payload;

        localStorageService.setAccessToken(username, accessToken);
        localStorageService.set('username', username);

        state.user = { username };
      }
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
