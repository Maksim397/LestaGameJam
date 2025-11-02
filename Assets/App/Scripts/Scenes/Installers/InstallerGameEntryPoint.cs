using App.Scripts.Infrastructure.ProjectSetup;
using App.Scripts.Infrastructure.ProjectSetup.ProjectSettings.Config;
using UnityEngine;
using Zenject;

namespace App.Scripts.Scenes.Installers
{
  public class InstallerGameEntryPoint : MonoInstaller
  {
    [SerializeField] private ConfigProjectSettings _configProjectSettings;
    
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<ProjectSetuper>().AsSingle().WithArguments(_configProjectSettings);
    }
  }
}