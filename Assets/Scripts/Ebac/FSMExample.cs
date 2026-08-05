using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class FSMExample : MonoBehaviour
{
    public enum ExampleEnum
    {
        MOVE,
        JUMP,
        IDLE
    }

    public StateMachine<ExampleEnum> stateMachine;
    public Player player;
    /*
    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleEnum.MOVE, new StateMoving());
        stateMachine.RegisterStates(ExampleEnum.JUMP, new StateJumping());
        stateMachine.RegisterStates(ExampleEnum.IDLE, new StateIdle());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.SwitchState(ExampleEnum.MOVE, player);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchState(ExampleEnum.JUMP, player);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            stateMachine.SwitchState(ExampleEnum.IDLE, player);
        }
    }
    */
}
