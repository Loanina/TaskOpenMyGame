using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneMatrix.Features.FieldInteractions.Signal;
using App.Scripts.Scenes.SceneMatrix.Features.FigureSwitcher;
using App.Scripts.Scenes.SceneMatrix.Features.PackLevel.Component;

namespace App.Scripts.Scenes.SceneMatrix.Features.Grid.Systems
{
    public class SystemResetField : ISystem
    {
        public SystemContext Context { get; set; }

        public void Init()
        {
            
        }

        public void Update(float dt)
        {
            if (Context.Signals.HasComponent<SignalResetField>() is false)
            {
                return;
            }

            var available = Context.Data.GetComponent<ComponentAvailableFigures>();
            var used = Context.Data.GetComponent<ComponentUsedFigures>();
            available.Figures.AddRange(used.Figures);
            used.Figures.Clear();

            var fieldGrid = Context.Data.GetComponent<ComponentField>().Grid;
            
            fieldGrid.Clear();
            
            Context.Signals.SetComponent(new SignalFieldChanged());
        }

        public void Cleanup()
        {
        }
    }
}