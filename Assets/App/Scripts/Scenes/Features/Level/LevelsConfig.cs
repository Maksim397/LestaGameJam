using System.Collections.Generic;
using App.Scripts.Libs.Configs.Variants;
using UnityEngine;

namespace App.Scripts.Scenes.Features.Level
{
  [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
  public class LevelsConfig : SoConfig<List<LevelData>>
  {
    [SerializeField] private List<LevelData> _levels = new List<LevelData>();
    
    public override List<LevelData> Data  => _levels;
  }
}