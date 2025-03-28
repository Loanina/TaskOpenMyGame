using System.Collections.Generic;
using App.Scripts.Features.Scenes.SceneNavigation.Config;
using UnityEngine.SceneManagement;

namespace App.Scripts.Features.Scenes.SceneNavigation
{
    public class SceneNavigatorLoader : ISceneNavigator
    {
        private readonly ConfigScenes _configScenes;

        public SceneNavigatorLoader(ConfigScenes configScenes)
        {
            _configScenes = configScenes;
        }

        public void LoadScene(SceneInfo sceneInfo)
        {
            SceneManager.LoadScene(sceneInfo.SceneKey);
        }

        public List<SceneInfo> GetAvailableSwitchScenes()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;

            var result = new List<SceneInfo>();

            foreach (var sceneInfo in _configScenes.AvailableScenes)
                if (sceneInfo.SceneKey != currentSceneName)
                    result.Add(sceneInfo);

            return result;
        }
    }
}