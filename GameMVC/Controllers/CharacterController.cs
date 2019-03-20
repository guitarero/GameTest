using System;
using GameMvc.Models;
using GameMvc.Views;

namespace GameMvc.Controllers
{
    public class CharacterController : ICharacterController
    {
        private ICharacterModel model;
        private ICharacterView view;

        public CharacterController(ICharacterModel model, ICharacterView view)
        {
            this.model = model;
            this.view = view;

            this.model.NameChanged += HandleChangeName;
            this.model.SpeedChanged += HandleChangeSpeed;
            this.model.HealthChanged += HandleChangeHealth;
            this.model.AmmoChanged += HandleChangeAmmo;

            this.view.GetDamaged += HandleGetDamaged;
            this.view.NewCharacterCreated += HandleNewCharacterCreated;
            this.view.GoingToMenu += HandleGoingToMenu;

            view.GoToScene("Menu");
        }

        private void HandleChangeName(string name)
        {
            view.Name = name;
        }

        private void HandleChangeSpeed(int speed)
        {
            view.Speed = speed;
        }

        private void HandleChangeHealth(int health)
        {
            view.Health = health;
        }

        private void HandleChangeAmmo(int ammo)
        {
            view.Ammo = ammo;
        }

        private void HandleGetDamaged(int damage)
        {
            model.GetDamaged(damage);
        }

        private void HandleNewCharacterCreated(object sender, NewCharacterCreatedEventArgs e)
        {
            model.Name = e.Name;
            model.Speed = e.Speed;
            model.Health = e.Health;
            model.Ammo = e.Ammo;

            view.GoToScene("Game");
        }

        void HandleGoingToMenu()
        {
            view.GoToScene("Menu");
        }
    }
}
