using UnityEngine.InputSystem;

namespace GIMS
{
  public class PlayerStoppingState : PlayerGroundedState
  {
    public PlayerStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    #region IState Methods
    public override void Enter()
    {
      stateMachine.ReusableData.MovementSpeedModifier = 0f;

      SetBaseCameraRecenteringData();

      base.Enter();
      StartAnimation(stateMachine.Player.AnimationData.StoppingParameterHash);
    }

    public override void Exit()
    {
      base.Exit();
      StopAnimation(stateMachine.Player.AnimationData.StoppingParameterHash);
    }

    public override void PhysicsUpdate()
    {
      base.PhysicsUpdate();

      RotateTowardsTargetRotation();

      if (!IsMovingHorizontally())return;

      DecelerateHorizontally();
    }

    public override void OnAnimationTransitionEvent()
    {
      stateMachine.ChangeState(stateMachine.IdlingState);
    }

    #endregion

    protected override void AddInputActionsCallbacks()
    {
      base.AddInputActionsCallbacks();
      stateMachine.Player.Input.PlayerActions.Movement.started += OnMovementStarted;
    }

    protected override void RemoveInputActionsCallbacks()
    {
      base.RemoveInputActionsCallbacks();
      stateMachine.Player.Input.PlayerActions.Movement.started -= OnMovementStarted;
    }


    #region Reusable Methods


    #endregion
    #region Input Methods

    private void OnMovementStarted(InputAction.CallbackContext context)
    {
      OnMove();
    }

    #endregion
  }
}
