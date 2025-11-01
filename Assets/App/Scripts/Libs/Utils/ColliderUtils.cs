using UnityEngine;

namespace App.Scripts.Libs
{
  public static class ColliderUtils
  {
    public static bool TryGetComponentInParent<T>(this Collider collider, out T component) where T : Component
    {
      component = collider.GetComponentInParent<T>();
      return component != null;
    }
  }
}