using System;

namespace App.Scripts.Infrastructure.PersistentProgress.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public string PlayerName;
    public float BestScore;
    
    public PlayerProgress()
    {
      
    }
  }
}