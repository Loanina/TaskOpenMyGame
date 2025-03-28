using System;

namespace App.Scripts.Features.LevelSelection
{
    public interface IViewSwitchNavigator
    {
        public event Action<int> ChangeLevel;
    }
}