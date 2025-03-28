using App.Scripts.Modules.Systems;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services
{
    public interface IHandlerFieldClick
    {
        void ProcessGridClick(SystemContext context, Vector2Int cellIndex);
        void Reset();
    }
}