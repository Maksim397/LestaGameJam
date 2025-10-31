using Sirenix.OdinInspector;
using UnityEngine;

namespace App.Scripts.Libs.Configs.Variants
{
  public abstract class SoConfig<T> : SerializedScriptableObject, IConfig
  {
    public abstract T Data { get; }
  }
}