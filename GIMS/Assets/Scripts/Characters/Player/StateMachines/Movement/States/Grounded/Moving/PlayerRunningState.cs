using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GIMS
{
  public class PlayerRunningState : PlayerMovementState
  {
    public PlayerRunningState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
  }
}
