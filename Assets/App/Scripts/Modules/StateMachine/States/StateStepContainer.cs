using System.Collections.Generic;
using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine.Transitions;

namespace App.Scripts.Modules.StateMachine.States
{

    public interface IStateStep
    {
        Task OnEnter();
        Task OnExit();
        void Update();
        
        bool IsComplete { get; set; }
        
        IStateMachineTrigger StateMachine { get; set; }
    }
    
    public interface IStateStepPayload<T> : IStateStep
    {
        Task OnEnter(T value);
    }
    
    public class StateStepContainer : IState
    {
        private readonly List<IStateStep> _steps = new ();
        private readonly List<ITransition> _transitions = new ();
        public List<ITransition> Transitions => _transitions;
        public bool IsComplete => IsCompleteSteps();

        public void Setup(IStateMachineTrigger stateMachineTrigger)
        {
            foreach (IStateStep stateStep in _steps)
            {
                stateStep.StateMachine = stateMachineTrigger;
            }
        }

        public async Task OnEnter<T>(T payload)
        {
            foreach (IStateStep stateStep in _steps)
            {
                await ProcessEnterStep(payload, stateStep);
            }
        }

        private static async Task ProcessEnterStep<T>(T payload, IStateStep stateStep)
        {
            if (stateStep is IStateStepPayload<T> stepPayload)
            {
                await stepPayload.OnEnter(payload);
                return;
            }

            await stateStep.OnEnter();
        }

        public void AddStep(IStateStep step)
        {
            _steps.Add(step);   
        }

        public void AddTransition(ITransition transition)
        {
            _transitions.Add(transition);    
        }

        public async Task OnExit()
        {
            foreach (IStateStep stateStep in _steps)
            {
                await stateStep.OnExit();
                stateStep.IsComplete = false;
            }
        }

        public async Task OnEnter()
        {
            foreach (IStateStep stateStep in _steps)
            {
                await stateStep.OnEnter();
            }
        }

        public void Update()
        {
            foreach (IStateStep stateStep in _steps)
            {
                stateStep.Update();
            }
        }
        
        private bool IsCompleteSteps()
        {
            foreach (IStateStep stateStep in _steps)
            {
                if (stateStep.IsComplete is false)
                {
                    return false;
                }
            }

            return true;
        }

    }
}