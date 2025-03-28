using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model;

namespace App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Services
{
    public interface IProviderPackLevels
    {
        int GetAvailableLevelCount();
        
        PackLevelData LoadLevel(int id);
    }
}