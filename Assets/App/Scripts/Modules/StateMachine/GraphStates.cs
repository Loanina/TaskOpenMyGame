using System.Collections.Generic;
using App.Scripts.Modules.StateMachine.States;
using App.Scripts.Modules.StateMachine.Transitions;

namespace App.Scripts.Modules.StateMachine
{
    public class GraphStates
    {
        private readonly Dictionary<string, IState> _states = new();
        public IState StartNode { get; private set; }

        public void SetStartNode(string startNode)
        {
            StartNode = GetNode(startNode);
        }
        
        public void AddState(string stateId, IState state)
        {
            _states.Add(stateId, state);
        }

        public IState GetNode(string idNextNode)
        {
            if (_states.TryGetValue(idNextNode, out var node))
            {
                return node;
            }

            return null;
        }

        public void AddCompleteTransition(string stateFrom, string stateTo)
        {
            AddTransitionToNode(stateFrom, stateTo,  new TransitionComplete());
        }

        private void AddTransitionToNode(string stateFrom, string stateTo, ITransition transition)
        {
            transition.NextNode = stateTo;
            var node = GetNode(stateFrom);
            node.AddTransition(transition);
        }

        public void AddTransition(string stateFrom, string stateTo, ITransition transition)
        {
            AddTransitionToNode(stateFrom, stateTo, transition);
        }
    }
}