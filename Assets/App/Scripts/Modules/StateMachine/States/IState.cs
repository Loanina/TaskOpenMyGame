using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine.Transitions;

namespace App.Scripts.Modules.StateMachine.States
{
    public interface IState
    {
        Task OnEnter<T>(T payload);
        Task OnExit();
        Task OnEnter();
        List<ITransition> Transitions { get;  }
        bool IsComplete { get; }
        void AddTransition(ITransition transition);

        void Setup(IStateMachineTrigger stateMachineTrigger);
        void Update();
    }
}