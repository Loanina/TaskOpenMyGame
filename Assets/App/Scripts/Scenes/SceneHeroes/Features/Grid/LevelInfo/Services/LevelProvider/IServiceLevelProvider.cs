namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Services.LevelProvider
{
    public interface IServiceLevelProvider
    {
        ILevelInfo GetLevel(int index);
        int LevelCount();
    }
}