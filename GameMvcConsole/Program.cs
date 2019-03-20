using System;
using GameMvc.Models;
using GameMvc.Views;
using GameMvc.Controllers;
using GameMvcConsole.Views;

namespace GameMvcConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Game start!");

            var model = new CharacterModel();
            var view = new CharacterView();

            view.AddScene("Menu", new MenuSceneView());
            view.AddScene("Game", new GameSceneView());

            var controller = new CharacterController(model, view);

            Console.WriteLine("Game over!");
        }
    }
}
