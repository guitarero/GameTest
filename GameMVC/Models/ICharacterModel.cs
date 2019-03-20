using System;

namespace GameMvc.Models
{
    public interface ICharacterModel : ICharacterProperties
    {
        void GetDamaged(int damage);

        event Action<string> NameChanged;
        event Action<int> SpeedChanged;
        event Action<int> HealthChanged;
        event Action<int> AmmoChanged;
    }
}
