using App.Scripts.Features.Scenes.SceneNavigation.Config;

namespace App.Scripts.Features.Scenes.SceneSelector.Triggers
{
    public class TriggerSceneChange 
    {
        public SceneInfo SceneInfo { get; }

        public TriggerSceneChange(SceneInfo sceneInfo)
        {
            SceneInfo = sceneInfo;
        }
    }
}