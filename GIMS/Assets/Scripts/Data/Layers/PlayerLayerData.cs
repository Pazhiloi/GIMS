using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GIMS
{
  [Serializable]
    public class PlayerLayerData 
    {
       [field: SerializeField] public LayerMask GroundLayer { get; private set; }
    }
}
