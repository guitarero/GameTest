using GameMvc.Models;

namespace GameMvc.Views
{
    public interface ISceneView : ICharacterProperties, ICharacterViewEvents
    {
        void Display();
    }
}
