using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component;
using App.Scripts.Scenes.SceneMatrix.Features.Scores.Components;

namespace App.Scripts.Scenes.SceneMatrix.Features.Scores.Systems
{
    public class SystemUpdateScores : ISystem
    {
        public SystemContext Context { get; set; }
        public void Init()
        {
            Context.Data.SetComponent(new ComponentCurrentScore());
            Context.Signals.SetComponent(new SignalScoreChanged());
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<SignalFieldChanged>() is false)
            {
                return;
            }

            var field = Context.Data.GetComponent<ComponentField>();
            var currentScore = Context.Data.GetComponent<ComponentCurrentScore>();

            int score = 0;
            
            for (int i = 0; i < field.Grid.Height; i++)
            {
                for (int j = 0; j < field.Grid.Width; j++)
                {
                    if (field.Grid[j, i] != null)
                    {
                        score++;
                    }
                }
            }

            currentScore.Scores = score;
            Context.Signals.SetComponent(new SignalScoreChanged());
        }

        public void Cleanup()
        {
        }
    }
}