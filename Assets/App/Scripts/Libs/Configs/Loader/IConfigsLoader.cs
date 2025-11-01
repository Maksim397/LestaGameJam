using System.Collections.Generic;
using App.Scripts.Libs.Configs.Variants;
using UnityEngine;

namespace App.Scripts.Libs.Configs.Loader
{
  public interface IConfigsLoader
  {
    T LoadSoConfig<T>() where T : Object, IConfig;
  }
}