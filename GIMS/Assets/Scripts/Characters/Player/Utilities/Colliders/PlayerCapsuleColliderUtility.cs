using System;
using UnityEngine;

namespace GIMS
{
  [Serializable]
    public class PlayerCapsuleColliderUtility : CapsuleColliderUtility
    {
    [field: SerializeField] public PlayerTriggerColliderData TriggerColliderData { get; private set; }
  }
}
