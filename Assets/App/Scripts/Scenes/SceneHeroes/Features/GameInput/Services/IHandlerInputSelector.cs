using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services
{
    public interface IHandlerInputSelector
    {
        IList<string> AvailableHandlers { get; }
        void AddHandler(string id, IHandlerFieldClick handlerFieldClick);
        void ChangeHandler(string id);
        void Reset();
    }
}