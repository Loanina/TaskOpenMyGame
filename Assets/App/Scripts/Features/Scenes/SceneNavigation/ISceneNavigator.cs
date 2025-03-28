using System.Collections.Generic;
using App.Scripts.Features.Scenes.SceneNavigation.Config;

namespace App.Scripts.Features.Scenes.SceneNavigation
{
    public interface ISceneNavigator
    {
        void LoadScene(SceneInfo sceneId);

        public List<SceneInfo> GetAvailableSwitchScenes();
    }
}