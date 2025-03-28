using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Modules.Systems;
using App.Scripts.Scenes.SceneCalculator.Features.Calculator;
using App.Scripts.Scenes.SceneCalculator.Features.Process;
using App.Scripts.Scenes.SceneCalculator.Features.Process.InputExpression;
using App.Scripts.Scenes.SceneCalculator.Features.ViewLog;
using UnityEngine;

namespace App.Scripts.Scenes.SceneCalculator.Bootstrap.Installers
{
    public class InstallerSystemsCalculator : MonoInstaller
    {
        [SerializeField] private ViewInputExpressionMono viewExpression;
        [SerializeField] private ViewInputExpressionMono viewExecute;
        
        protected override void OnInstallBindings()
        {
            var systemGroup = new SystemsGroup();

            var viewLog = Container.Get<IViewLog>();
            var calculator = new CalculatorExpression();
            systemGroup.AddSystem(new SystemProcessCalculator(viewLog, 
                viewExpression,
                viewExecute, calculator));
            
            Container.SetServiceSelf(systemGroup);
        }
    }
}