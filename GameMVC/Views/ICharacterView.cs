using GameMvc.Models;

namespace GameMvc.Views
{
    public interface ICharacterView : ICharacterProperties, ICharacterViewEvents
    {
        void AddScene(string sceneName, ISceneView sceneView);
        void GoToScene(string sceneName);
        void CreateNewCharacter(NewCharacterCreatedEventArgs e);
        void GetDamage(int damage);
        void GoToMenu();
    }
}
