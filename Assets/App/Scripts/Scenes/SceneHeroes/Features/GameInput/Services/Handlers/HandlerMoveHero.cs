using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneHeroes.Features.Units;
using UnityEngine;

namespace App.Scripts.Scenes.SceneHeroes.Features.GameInput.Services.Handlers
{
    public class HandlerMoveHero : IHandlerFieldClick
    {
        public void ProcessGridClick(SystemContext context, Vector2Int cellIndex)
        {
            var unit = context.Data.GetComponent<Unit>();
            unit.PlaceAt(cellIndex);
        }

        public void Reset()
        {
        }
    }
}