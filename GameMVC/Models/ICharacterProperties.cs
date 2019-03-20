namespace GameMvc.Models
{
    public interface ICharacterProperties
    {
        string Name { get; set; }
        int Speed { get; set; }
        int Health { get; set; }
        int Ammo { get; set; }
    }
}
