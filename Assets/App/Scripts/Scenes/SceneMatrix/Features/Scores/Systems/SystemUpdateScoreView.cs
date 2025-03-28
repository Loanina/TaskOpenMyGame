using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.Scores.Components;
using App.Scripts.Scenes.SceneMatrix.Features.Scores.View;

namespace App.Scripts.Scenes.SceneMatrix.Features.Scores.Systems
{
    public class SystemUpdateScoreView : ISystem
    {
        private readonly IViewScore _viewScore;
        public SystemContext Context { get; set; }

        public SystemUpdateScoreView(IViewScore viewScore)
        {
            _viewScore = viewScore;
        }
        
        public void Init()
        {
            
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<SignalScoreChanged>() is false)
            {
                return;
            }

            var score = Context.Data.GetComponent<ComponentCurrentScore>().Scores;
            
            _viewScore.UpdateScore(score);
        }

        public void Cleanup()
        {
            
        }
    }
}