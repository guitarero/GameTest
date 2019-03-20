using System;
using GameMvc.Views;

namespace GameMvcConsole.Views
{
    public class GameSceneView : ISceneView
    {
        public GameSceneView()
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

            while (true)
            {
                DisplayState();

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GoingToMenu();
                        return;
                        break;

                    case "2":
                        GetDamaged(50);
                        break;

                    default:
                        break;
                }
            }
        }

        void DisplayState()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("|| GAME");
            Console.WriteLine("==============================================");
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Speed: {0}", Speed);
            Console.WriteLine("Health: {0}", Health);
            Console.WriteLine("Ammo: {0}", Ammo);
            Console.WriteLine("==============================================");
            Console.WriteLine("Choose your destiny:");
            Console.WriteLine("1. Go back to menu.");
            Console.WriteLine("2. Get damaged!");
        }
    }
}
