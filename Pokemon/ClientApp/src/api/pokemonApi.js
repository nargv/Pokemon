import axios from "axios";

export const baseUrl = "pokemon";

function getPokemonDetails(name) {
    return axios.get(`${baseUrl}/${name}`)
            .then(response => response.data)
            .catch(response => undefined);
}

export const pokemonApi = {
    getPokemonDetails,
};