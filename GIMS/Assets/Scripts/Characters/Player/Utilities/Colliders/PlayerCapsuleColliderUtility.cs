using System;
using UnityEngine;

namespace GIMS
{
  [Serializable]
    public class PlayerCapsuleColliderUtility : CapsuleColliderUtility
    {
    [field: SerializeField] public PlayerTriggerColliderData TriggerColliderData { get; private set; }

    protected override void OnInitialize()
    {
      base.OnInitialize();

      TriggerColliderData.Initialize();
    }
  }
}
