using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Features.FigureProvider.ProviderResource
{
    public class ProviderResourceUnity : IProviderResource
    {
        public string LoadTextResource(string resourceKey)
        {
            return Resources.Load<TextAsset>(resourceKey).text;
        }
    }
}