using System;
using System.Collections.Generic;

namespace GameMvc.Views
{
    public class CharacterView : ICharacterView
    {
        private Dictionary<string, ISceneView> Scenes = new Dictionary<string, ISceneView>();
        private ISceneView SceneCurrent;

        private string name;
        private int speed;
        private int health;
        private int ammo;

        public string Name
        {
            get { return name; }
            set { name = SceneCurrent.Name = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = SceneCurrent.Speed = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = SceneCurrent.Health = value; }
        }

        public int Ammo
        {
            get { return ammo; }
            set { ammo = SceneCurrent.Ammo = value; }
        }

        public event EventHandler<NewCharacterCreatedEventArgs> NewCharacterCreated = delegate { };
        public event Action<int> GetDamaged = delegate { };
        public event Action GoingToMenu = delegate { };

        public void AddScene(string sceneName, ISceneView sceneView)
        {
            Scenes.Add(sceneName, sceneView);
        }

        public void GoToScene(string sceneName)
        {
            // Unsubscribe from old scene events
            if (SceneCurrent != null)
            {
                SceneCurrent.NewCharacterCreated -= SceneCurrent_NewCharacterCreated;
                SceneCurrent.GetDamaged -= SceneCurrent_GetDamaged;
                SceneCurrent.GoingToMenu -= SceneCurrent_GoingToMenu;
            }

            SceneCurrent = Scenes[sceneName];
            SyncProperties();

            // Subscribe to new scene events
            SceneCurrent.NewCharacterCreated += SceneCurrent_NewCharacterCreated;
            SceneCurrent.GetDamaged += SceneCurrent_GetDamaged;
            SceneCurrent.GoingToMenu += SceneCurrent_GoingToMenu;

            SceneCurrent.Display();
        }

        void SceneCurrent_NewCharacterCreated(object sender, NewCharacterCreatedEventArgs e)
        {
            NewCharacterCreated(this, e);
        }

        void SceneCurrent_GetDamaged(int damage)
        {
            GetDamaged(damage);
        }

        void SceneCurrent_GoingToMenu()
        {
            GoingToMenu();
        }

        private void SyncProperties()
        {
            SceneCurrent.Name = name;
            SceneCurrent.Speed = speed;
            SceneCurrent.Health = health;
            SceneCurrent.Ammo = ammo;
        }

        public void CreateNewCharacter(NewCharacterCreatedEventArgs e)
        {
            NewCharacterCreated(this, e);
        }

        public void GetDamage(int damage)
        {
            GetDamaged(damage);
        }

        public void GoToMenu()
        {
            GoingToMenu();
        }
    }
}
