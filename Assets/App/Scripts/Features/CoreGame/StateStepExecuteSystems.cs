using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine;
using App.Scripts.Modules.StateMachine.States;
using App.Scripts.Modules.Systems;
using UnityEngine;

namespace App.Scripts.Features.CoreGame
{
    public class StateStepExecuteSystems : StateStep
    {
        private readonly SystemsGroup _systemsGroup;

        public StateStepExecuteSystems(SystemsGroup systemsGroup)
        {
            _systemsGroup = systemsGroup;
        }
        
        public override Task OnEnter()
        {
            _systemsGroup.Init();
            return base.OnEnter();
        }

        public override void Update()
        {
            _systemsGroup.Update(Time.deltaTime);
        }

        public override Task OnExit()
        {
            _systemsGroup.Cleanup();
            return base.OnExit();
        }
    }
}