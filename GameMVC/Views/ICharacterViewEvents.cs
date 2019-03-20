using System;
namespace GameMvc.Views
{
    public interface ICharacterViewEvents
    {
        event EventHandler<NewCharacterCreatedEventArgs> NewCharacterCreated;
        event Action<int> GetDamaged;
        event Action GoingToMenu;
    }
}
