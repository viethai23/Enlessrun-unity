using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki
{
    public class FSM
    {
        public State CurrentState {  get; private set; }

        public void Initialization(State iniState)
        {
            CurrentState = iniState;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
