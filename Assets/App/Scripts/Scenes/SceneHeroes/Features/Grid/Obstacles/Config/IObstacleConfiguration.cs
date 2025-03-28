using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.Config
{
    public interface IObstacleConfiguration
    {
        IEnumerable<int> AvailableObstacleTypes { get;  }
    }
}