using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Features.Scenes.SceneNavigation.Config;

namespace App.Scripts.Features.Scenes.SceneSelector.View.ViewSwitcher
{
    public interface IViewSceneSwitcher
    {
        event Action<SceneInfo> OnItemSelected;
        bool IsShow { get; }
        void UpdateItems(IEnumerable<SceneInfo> sceneInfos);

        Task Show();
        Task Hide();
    }
}