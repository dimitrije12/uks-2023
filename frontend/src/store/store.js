import { combineReducers, configureStore } from '@reduxjs/toolkit';
import userReducer from './reducers/user/userSlice';
import logger from 'redux-logger';

const combinedReducer = combineReducers({ user: userReducer });

const rootReducer = (state, action) => {
  return combinedReducer(state, action);
};

const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) => [
    ...getDefaultMiddleware({ serializableCheck: false }),
    logger,
  ],
});

export default store;
