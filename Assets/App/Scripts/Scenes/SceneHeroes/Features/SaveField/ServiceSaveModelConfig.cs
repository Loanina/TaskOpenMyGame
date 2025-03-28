using System;
using System.IO;
using App.Scripts.Scenes.SceneHeroes.Features.Grid.LevelInfo.Serializable;
using Newtonsoft.Json;

namespace App.Scripts.Scenes.SceneHeroes.Features.SaveField
{
    public class ServiceSaveModelConfig : IServiceSaveField
    {
        private readonly Config _config;

        public ServiceSaveModelConfig(Config config)
        {
            _config = config;
        }
        
        public void SaveField(LevelInfoTarget fieldModel)
        {
            var modelText = JsonConvert.SerializeObject(fieldModel);
            string savePath = FormSavePath();
            File.WriteAllText(savePath, modelText);
        }

        private string FormSavePath()
        {
            int i = 0;
            string savePath = BuildPath(i);
            while (File.Exists(savePath))
            {
                i++;
                savePath = BuildPath(i);
            }

            return savePath;
        }

        private string BuildPath(int index)
        {
            return string.Format(_config.savePath, _config.fileName, index.ToString());
        }
        
        
        [Serializable]
        public class Config
        {
            public string savePath;
            public string fileName;
        }
    }
}