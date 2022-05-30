namespace Pokemon.Models
{
    public class PokemonModel
    {
        public PokemonModel(string name, string description, string sprite)
        {
            Name = name;
            Description = description;
            Sprite = sprite;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Sprite { get; private set; }
    }
}
