export const baseUrl = "pokemon";

function getPokemonDetails(name) {
    return fetch(`${baseUrl}/${name}`)
            .then(response => {
                if(response.ok)
                    return response.json();
            })
            .catch(response => response);
}

export const pokemonApi = {
    getPokemonDetails,
};