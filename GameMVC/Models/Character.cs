using System;
using System.ComponentModel;

namespace GameMvc.Models
{
    public class CharacterModel : ICharacterModel
    {
        private string name;
        private int speed;
        private int health;
        private int ammo;

        public string Name {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NameChanged(value);
                }
            }
        }

        public int Speed {
            get { return speed; }
            set
            {
                if (speed != value)
                {
                    speed = value;
                    SpeedChanged(value);
                }
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (health != value)
                {
                    health = value;
                    HealthChanged(value);
                }
            }
        }

        public int Ammo
        {
            get { return ammo; }
            set
            {
                if (ammo != value)
                {
                    ammo = value;
                    AmmoChanged(value);
                }
            }
        }

        public event Action<string> NameChanged = delegate { };
        public event Action<int> SpeedChanged = delegate { };
        public event Action<int> HealthChanged = delegate { };
        public event Action<int> AmmoChanged = delegate { };

        public void GetDamaged(int damage)
        {
            Health = damage > Health ? 0 : Health - damage;
        }
    }
}
