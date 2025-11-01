using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Physic
{
  public interface IPhysicsService
  {
    IEnumerable<T> OverlapCircle<T>(Vector3 worldPos, float radius, int layerMask);
  }
}