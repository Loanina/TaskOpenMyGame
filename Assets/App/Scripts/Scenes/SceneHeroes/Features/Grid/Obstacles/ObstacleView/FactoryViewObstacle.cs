using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Modules.Factory;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.Config;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.Obstacles.ObstacleView
{
    public class FactoryViewObstacle : IFactory<int, ViewCell>
    {
        private readonly ConfigViewObstacle _configViewObstacle;
        private readonly FactoryViewCell _factoryViewCell;

        public FactoryViewObstacle(ConfigViewObstacle configViewObstacle, FactoryViewCell factoryViewCell)
        {
            _configViewObstacle = configViewObstacle;
            _factoryViewCell = factoryViewCell;
        }
        
        public ViewCell Create(int obstacleType)
        {
            var obstacleConfig = _configViewObstacle.FindObstacleConfig(obstacleType);
            return _factoryViewCell.Create(_configViewObstacle.ObstacleLayer, obstacleConfig.spriteObstacle);
            
        }
    }
}