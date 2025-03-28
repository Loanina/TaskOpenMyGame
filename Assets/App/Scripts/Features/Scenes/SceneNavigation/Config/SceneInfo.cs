using System;

namespace App.Scripts.Features.Scenes.SceneNavigation.Config
{
    [Serializable]
    public class SceneInfo
    {
        public string SceneKey;
        public string SceneViewName;

        public override string ToString()
        {
            return SceneViewName;
        }
    }
}