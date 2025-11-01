using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Physic
{

  public class PhysicsService : IPhysicsService
  {
    private static readonly Collider[] OverlapHits = new Collider[128];
    public IEnumerable<T> OverlapCircle<T>(Vector3 worldPos, float radius, int layerMask)
    {
      int hitCount = Physics.OverlapSphereNonAlloc(worldPos, radius, OverlapHits, layerMask);
      if(hitCount > 0)
      {
        for(int i = 0; i < hitCount; i++)
        {
          if (OverlapHits[i].TryGetComponent(out T hitInstance))
            yield return hitInstance;
        }
      }
      
      DrawDebug(worldPos, radius, 5, Color.red);
    }
    
    private static void DrawDebug(Vector3 worldPos, float radius, float seconds, Color color)
    {
      Debug.DrawRay(worldPos, radius * Vector3.up, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.down, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.left, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.right, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.forward, color, seconds);
      Debug.DrawRay(worldPos, radius * Vector3.back, color, seconds);
    }
  }
}