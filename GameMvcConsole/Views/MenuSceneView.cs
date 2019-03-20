using System;
using GameMvc.Views;

namespace GameMvcConsole.Views
{
    public class MenuSceneView : ISceneView
    {
        public MenuSceneView()
        {
        }

        public string Name { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public int Ammo { get; set; }

        public event EventHandler<NewCharacterCreatedEventArgs> NewCharacterCreated = delegate { };
        public event Action<int> GetDamaged = delegate { };
        public event Action GoingToMenu = delegate { };

        public void Display()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("|| MENU");
            Console.WriteLine("==============================================");
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1. Scout");
            Console.WriteLine("2. Heavy");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NewCharacterCreated(this, new NewCharacterCreatedEventArgs()
                    {
                        Name = "Scout",
                        Speed = 133,
                        Health = 125,
                        Ammo = 250
                    });
                    break;

                case "2":
                    NewCharacterCreated(this, new NewCharacterCreatedEventArgs()
                    {
                        Name = "Havy",
                        Speed = 77,
                        Health = 300,
                        Ammo = 1000
                    });
                    break;

                default:
                    break;
            }
        }
    }
}
