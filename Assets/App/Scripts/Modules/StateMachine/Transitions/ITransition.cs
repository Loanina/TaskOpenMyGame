using System.Threading.Tasks;
using App.Scripts.Modules.StateMachine.States;

namespace App.Scripts.Modules.StateMachine.Transitions
{
    public interface ITransition
    {
        bool CanTransit(IState currentState);
        string NextNode { get; set; }
        Task ProcessEnter(IState currentState);
    }
}