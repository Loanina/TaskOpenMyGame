using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Services.LevelProvider
{
    public class ServiceLevelProviderConfig : IServiceLevelProvider
    {
        private readonly List<ILevelInfo> _levelInfos;

        public ServiceLevelProviderConfig(IEnumerable<ILevelInfo> levelInfos)
        {
            _levelInfos = levelInfos.ToList();
        }
        
        public ILevelInfo GetLevel(int index)
        {
            return _levelInfos[index];
        }

        public int LevelCount()
        {
            return _levelInfos.Count;
        }
    }
}