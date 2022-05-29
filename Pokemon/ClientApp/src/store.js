import { configureStore } from '@reduxjs/toolkit';
import searchReducer from './searches';

export const store = configureStore({
    reducer: {
        searches: searchReducer,
    },
});