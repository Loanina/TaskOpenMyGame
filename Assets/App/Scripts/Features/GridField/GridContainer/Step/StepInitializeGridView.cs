using System;
using System.Threading.Tasks;
using App.Scripts.Features.FieldSizeProvider;
using App.Scripts.Modules.StateMachine.States;
using UnityEngine;

namespace App.Scripts.Features.GridField.GridContainer.Step
{
    public class StepInitializeGridView : StateStep
    {
        private readonly IViewGridContainer _viewGridContainer;
        private readonly IFieldSizeProvider _fieldSizeProvider;
        private readonly Config _config;

        public StepInitializeGridView(IViewGridContainer viewGridContainer, IFieldSizeProvider fieldSizeProvider, Config config)
        {
            _viewGridContainer = viewGridContainer;
            _fieldSizeProvider = fieldSizeProvider;
            _config = config;
        }
        
        public override Task OnEnter()
        {
            var rect = _fieldSizeProvider.GetFieldRect();

            var fieldPos = rect.position + rect.size * _config.relativePosition;
            var fieldRect = new Rect(fieldPos, rect.size * _config.relativeFieldSize);
            
            _viewGridContainer.SetupFieldSize(fieldRect);
            CompleteStep();
            return base.OnEnter();
        }
        
        [Serializable]
        public class Config
        {
            public Vector2 relativeFieldSize;
            public Vector2 relativePosition;
        }
    }
}