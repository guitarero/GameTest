using System;
using GameMvc.Models;

namespace GameMvc.Views
{
    public class NewCharacterCreatedEventArgs : EventArgs, ICharacterProperties
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public int Ammo { get; set; }
    }
}
