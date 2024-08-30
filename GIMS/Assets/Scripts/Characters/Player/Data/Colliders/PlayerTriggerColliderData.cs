using System;
using UnityEngine;

namespace GIMS
{
  [Serializable]
    public class PlayerTriggerColliderData 
    {
    [field: SerializeField] public BoxCollider GroundCheckCollider { get; private set; }
  }
}
