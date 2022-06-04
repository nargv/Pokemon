import { render, screen } from '@testing-library/react';
import SearchResult from '../../components/SearchResult';


describe("SearchPokemon tests", () => {

    test("No results displayed", async () => {
        render(
            <SearchResult />
        );

        const text = screen.getByText("No Results.")

        expect(text).toBeInTheDocument();
    });

    test("Results displayed", async () => {
        const pokemon = { name: "pikachu", description: "yellow", sprite: "" };

        render(
            <SearchResult result={pokemon} />
        );

        expect(screen.getByText("pikachu")).toBeInTheDocument();
        expect(screen.getByText("yellow")).toBeInTheDocument();
    });
});