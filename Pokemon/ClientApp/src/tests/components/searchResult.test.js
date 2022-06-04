import { render, screen } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import SearchResult from '../../components/SearchResult';


describe("SearchResult tests", () => {
    beforeEach(() => {
        jest.resetAllMocks();
    });

    test("get pokemon api call - fail", async () => {
        const pokemon = { name: "pichu", description: "description" };

        render(
            <SearchResult
                    result={pokemon}
                />
        );

        const result = screen.getByText("No Results.")

        expect(result).toBeInTheDocument();
    });
});