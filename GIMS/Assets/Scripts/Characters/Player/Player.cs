using UnityEngine;

namespace GIMS
{
  [RequireComponent(typeof(PlayerInput))]
  public class Player : MonoBehaviour
  {
    
    [field: Header("References")]
    [field:SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Collisions")]
    [field:SerializeField] public PlayerCapsuleColliderUtility ColliderUtility { get; private set; }
    [field:SerializeField] public PlayerLayerData LayerData { get; private set; }
    [field: Header("Animations")]
    [field:SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    [field: Header("Cameras")]
    [field:SerializeField] public PlayerCameraUtility CameraUtility { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public Transform MainCameraTransform { get; private set; }

    private PlayerMovementStateMachine movementStateMachine;

    private void Awake()
    {
      Rigidbody = GetComponent<Rigidbody>();
      Animator = GetComponentInChildren<Animator>();
      Input = GetComponent<PlayerInput>();

      ColliderUtility.Initialize(gameObject);
      ColliderUtility.CalculateCapsuleColliderDimensions();
      CameraUtility.Initialize();
      AnimationData.Initialize();

      MainCameraTransform = Camera.main.transform;

      movementStateMachine = new PlayerMovementStateMachine(this);
    }

    private void OnValidate() {
      ColliderUtility.Initialize(gameObject);
      ColliderUtility.CalculateCapsuleColliderDimensions();
    }

    private void Start()
    {
      movementStateMachine.ChangeState(movementStateMachine.IdlingState);
    }

    private void OnTriggerEnter(Collider collider) {
      movementStateMachine.OnTriggerEnter(collider);
    }

    private void OnTriggerExit(Collider collider) {
      movementStateMachine.OnTriggerExit(collider);
    }

    private void Update()
    {
      movementStateMachine.HandleInput();

      movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
      movementStateMachine.PhysicsUpdate();
    }

    public void OnMovementStateAnimationEnterEvent(){
      movementStateMachine.OnAnimationEnterEvent();
    }
    public void OnMovementStateAnimationExitEvent(){
      movementStateMachine.OnAnimationExitEvent();
    }
    public void OnMovementStateAnimationTransitionEvent(){
      movementStateMachine.OnAnimationTransitionEvent();
    }
  }
}
