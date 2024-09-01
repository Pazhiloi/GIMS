using System;
using System.Collections.Generic;
using UnityEngine;

namespace GIMS
{
  [Serializable]
  public class PlayerIdleData
  {
    [field: SerializeField] public List<PlayerCameraRecenteringData> BackwardsCameraRecenteringData { get; private set; }
  }
}
