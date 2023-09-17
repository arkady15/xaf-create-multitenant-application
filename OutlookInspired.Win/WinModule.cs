﻿using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using OutlookInspired.Module;
using OutlookInspired.Win.Controllers;
using OutlookInspired.Win.Controllers.Evaluations;
using OutlookInspired.Win.Controllers.GridListEditor;
using OutlookInspired.Win.Controllers.Maps;
using OutlookInspired.Win.Controllers.Quotes;

namespace OutlookInspired.Win;

[ToolboxItemFilter("Xaf.Platform.Win")]
// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class OutlookInspiredWinModule : ModuleBase {
    //private void Application_CreateCustomModelDifferenceStore(object sender, CreateCustomModelDifferenceStoreEventArgs e) {
    //    e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
    //    e.Handled = true;
    //}

    private void Application_CreateCustomUserModelDifferenceStore(object sender, CreateCustomModelDifferenceStoreEventArgs e) {
        e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Win");
        e.Handled = true;
    }
    public OutlookInspiredWinModule() {
        FormattingProvider.UseMaskSettings = true;
        RequiredModuleTypes.Add(typeof(OutlookInspiredModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) 
        => new[] { new ModuleUpdater(objectSpace, versionFromDB) };

    protected override IEnumerable<Type> GetDeclaredControllerTypes() 
        => new[]{
            typeof(RemoveMenuItemController), typeof(SchedulerResourceDeletingController),
            typeof(FontSizeController), typeof(NewItemRowHandlingModeController),
            typeof(WinMapsController),typeof(PaletteEntriesController),typeof(ChildViewCriteriaController),
            typeof(RouteMapsViewController), typeof(SalesMapsViewController),
            typeof(PropertyEditorController), typeof(MapItemController), 
            typeof(DisableSkinsController), typeof(SplitterPositionController)
        };

    public override void Setup(XafApplication application) {
        base.Setup(application);
        // application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
        application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
    }
}
