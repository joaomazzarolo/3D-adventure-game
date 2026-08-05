using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class StateBase
    {

        public virtual void OnStateEnter(params object[] objs)
        {
            Debug.Log("OnStateEnter");
        }
        public virtual void OnStateStay()
        {
            Debug.Log("OnStateStay");
        }
        public virtual void OnStateExit()
        {
            Debug.Log("OnStateExit");
        }
    }

   /* public class StateMoving : StateBase
    {
        public Player player;

        public override void OnStateEnter(object o = null)
        {
            player = (Player)o;
            //player.canMove = true;
            base.OnStateEnter(o);
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }

    public class StateJumping : StateBase
    {
        public Player player;

        public override void OnStateEnter(object o = null)
        {
            player = (Player)o;
            //player.canJump = true;
            base.OnStateEnter(o);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }

    public class StateIdle : StateBase
    {
        public Player player;

        public override void OnStateEnter(object o = null)
        {
            player = (Player)o;
            //player.canMove = false;
            //player.canJump = false;
            base.OnStateEnter(o);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }
    }*/
}
