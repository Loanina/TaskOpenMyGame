using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine.States;
using App.Scripts.Modules.StateMachine.Transitions;
using UnityEngine;

namespace App.Scripts.Modules.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly GraphStates _graphStates;
        private IState _currentState;
        private bool _changingState;

        public StateMachine(GraphStates graphStates)
        {
            _graphStates = graphStates;
        }

        public void Initialize()
        {
            ChangeStateTo(_graphStates.StartNode, new TransitionNavigate());
        }

        private async void ChangeStateTo(IState node, ITransition transition)
        {
            await ProcessChangeNode(node, transition);
        }

        private async Task ProcessChangeNode(IState node, ITransition transition)
        {
            if (_changingState)
            {
                return;
            }

            _changingState = true;

            if (_currentState != null)
            {
                await _currentState.OnExit();
            }

            _currentState = node;
            _currentState.Setup(this);

            await transition.ProcessEnter(_currentState);
            
            _changingState = false;
        }

        public void Update()
        {
            if (_currentState is null || _changingState)
            {
                return;
            }

            _currentState.Update();

            foreach (var transition in _currentState.Transitions)
            {
                if (transition.CanTransit(_currentState))
                {
                    IState navigateState = _graphStates.GetNode(transition.NextNode);
                    ChangeStateTo(navigateState, transition);
                }
            }
        }

        public void FireTrigger<T>(T triggerSceneChange)
        {
            if (_currentState is null)
            {
                Debug.LogError("current state is empty cant trigger");
                return;
            }

            foreach (var transition in _currentState.Transitions)
            {
                if (transition is ITransitionTrigger<T> transitionTrigger)
                {
                    transitionTrigger.Trigger(triggerSceneChange);
                }
            }
        }
    }
}