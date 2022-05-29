import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    searches: [],
};

export const searchSlice = createSlice({
    name: 'searches',
    initialState,
    reducers: {
        addSearch: (state, action) => {
            state.searches = [...state.searches, action.payload]
        },
    }
});

export const { addSearch } = searchSlice.actions;

export default searchSlice.reducer;