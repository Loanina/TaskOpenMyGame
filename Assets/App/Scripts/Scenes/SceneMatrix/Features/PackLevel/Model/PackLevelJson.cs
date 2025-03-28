using System;
using System.Collections.Generic;

namespace App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Model
{
    [Serializable]
    public class PackLevelJson
    {
        public int width;
        public int height;
        public List<int> figuresIds;
    }
}