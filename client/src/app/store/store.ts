import { configureStore } from '@reduxjs/toolkit';
import { uiSlice } from '../layout/uiSlice';
import { useDispatch, useSelector } from 'react-redux';
import { accountApi } from '../../features/account/accountApi';

export const store = configureStore({
  reducer: {
    [accountApi.reducerPath]: accountApi.reducer,
    ui: uiSlice.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(accountApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = useDispatch.withTypes<AppDispatch>();
export const useAppSelector = useSelector.withTypes<RootState>();
