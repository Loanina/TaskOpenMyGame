using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Components
{
    public class ComponentRequestRebuildLevel
    {
        public ILevelInfo LevelInfo { get; }

        public ComponentRequestRebuildLevel(ILevelInfo levelInfo)
        {
            LevelInfo = levelInfo;
        }
    }
}