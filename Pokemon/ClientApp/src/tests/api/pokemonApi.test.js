import axios from "axios";
import { pokemonApi, baseUrl } from '../../api/pokemonApi';

jest.mock('axios');;

describe("PokemonApi test", () => {
    afterEach(() => {
        jest.clearAllMocks();
    });

    test("get pokemon api call - fail", async () => {
        const inputName = "pika";
        const response = { data: {} };

        axios.get.mockRejectedValueOnce(response);

        const result = await pokemonApi.getPokemonDetails(inputName);

        expect(axios.get).toHaveBeenCalledWith(`${baseUrl}/${inputName}`);
        expect(axios.get).toHaveBeenCalledTimes(1);
        expect(result).toEqual(undefined);
    });

    test("get pokemon api call - success", async () => {
        const inputName = "pikachu";
        const pokemon = { name: inputName, description: "description" };
        const response = { data: pokemon };

        axios.get.mockResolvedValue(response);

        const result = await pokemonApi.getPokemonDetails(inputName);

        expect(axios.get).toHaveBeenCalledWith(`${baseUrl}/${inputName}`);
        expect(axios.get).toHaveBeenCalledTimes(1);
        expect(result).toEqual(pokemon);
    });
});