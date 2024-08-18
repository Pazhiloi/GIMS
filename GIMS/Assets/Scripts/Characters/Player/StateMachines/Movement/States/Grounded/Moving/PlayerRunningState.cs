using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GIMS
{
  public class PlayerRunningState : PlayerMovingState
  {
    public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }


    #region  IState Methods
    public override void Enter()
    {
      base.Enter();
      stateMachine.ReusableData.MovementSpeedModifier = movementData.RunData.SpeedModifier;
    }

    #endregion


    #region  Input Methods
    protected override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
      base.OnWalkToggleStarted(context);

      stateMachine.ChangeState(stateMachine.WalkingState);
    }
    #endregion

  }
}
