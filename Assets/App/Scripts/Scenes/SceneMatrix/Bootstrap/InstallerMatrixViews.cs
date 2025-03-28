using App.Scripts.Features.GridField.GridContainer;
using App.Scripts.Features.GridField.GridContainer.Step;
using App.Scripts.Modules.Factory;
using App.Scripts.Modules.SceneContainer.Installer;
using App.Scripts.Scenes.SceneMatrix.Features.FigurePreviewContainer.View.ViewFigureContainer;
using App.Scripts.Scenes.SceneMatrix.Features.Grid.View;
using App.Scripts.Scenes.SceneMatrix.Features.Scores.View;
using UnityEngine;

namespace App.Scripts.Scenes.SceneMatrix.Bootstrap
{
    public class InstallerMatrixViews : MonoInstaller
    {
        [SerializeField] private ViewGridContainer viewGridContainer;
        [SerializeField] private StepInitializeGridView.Config configField;
        [SerializeField] private ViewCellSpriteRender prefabCell;
        [SerializeField] private ViewFigureContainer viewFigureContainer;
        [SerializeField] private SettingsMatrixField settingsMatrixField;
        [SerializeField] private ViewScore viewScore;

        protected override void OnInstallBindings()
        {
            Container.SetService<IViewGridContainer, ViewGridContainer>(viewGridContainer);
            Container.SetServiceSelf(configField);
            Container.SetServiceSelf(viewFigureContainer);

            var factoryViewCell = new FactoryViewCell(prefabCell);
            Container.SetService<IFactory<ViewCell>, FactoryViewCell>(factoryViewCell);

            var viewMatrixField = new ViewMatrixField(settingsMatrixField, viewGridContainer, factoryViewCell);
            Container.SetService<IViewMatrixField, ViewMatrixField>(viewMatrixField);
            Container.SetService<IViewScore, ViewScore>(viewScore);
        }
    }
}