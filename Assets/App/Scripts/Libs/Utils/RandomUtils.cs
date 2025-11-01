using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace App.Scripts.Libs
{
  public static class RandomUtils
  {
    public static T PickRandom<T>(this IEnumerable<T> collection) where T : class
    {
      T[] enumerable = collection as T[] ?? collection.ToArray();

      if (enumerable.IsNullOrEmpty())
        return null;
      
      return enumerable[Random.Range(0, enumerable.Length)];
    }
    
    public static bool TryPickRandom<T>(this IEnumerable<T> collection, out T picked) where T : struct
    {
      picked = default;
      T[] enumerable = collection as T[] ?? collection.ToArray();

      if (enumerable.IsNullOrEmpty())
        return false;
      
      picked = enumerable[Random.Range(0, enumerable.Length)];
      return true;
    }
  }
}