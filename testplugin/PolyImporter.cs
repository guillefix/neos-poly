using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrooxEngine;
using FrooxEngine.UIX;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Collections.Generic;

namespace FrooxEngine.LogiX
{
    [Category("LogiX/AAAA")]
    [NodeName("Import Model")]
    public class ModelImporterWithArgument : LogixNode
    {
        public Slot thingo;
        public ModelImportDialog modelImportDialog;
        public readonly Input<string> path;
        public readonly Impulse OnDone;
        protected override void OnStart()
        {
            if (this.LocalUser == this.World.HostUser)
            {
                base.OnStart();
                thingo = this.LocalUserSpace.AddSlot("Thingo");
                thingo.PersistentSelf = false;
                modelImportDialog = thingo.AttachComponent<ModelImportDialog>();
                FieldInfo fi = typeof(ImportDialog).GetField("_importingUser", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(modelImportDialog, this.LocalUser);
                modelImportDialog._snappable.Value = false;
                modelImportDialog._scale.Value = 1f;
                modelImportDialog._autoScale.Value = true;
                modelImportDialog._calculateTangents.Value = false;
                modelImportDialog._optimizeModel.Value = true;
            }

        }
        [ImpulseTarget]
        public void Run()
        {
            if (modelImportDialog.Paths.Count > 0) modelImportDialog.Paths[0] = path.Evaluate();
            else modelImportDialog.Paths.AddRange(new List<string>() { path.Evaluate() });
            Slot thingo2 = this.LocalUserSpace.AddSlot("Thingo");
            ModelImportDialog modelImportDialog2 = thingo2.CopyComponent(thingo.GetComponent<ModelImportDialog>());
            modelImportDialog.RunImport();
            thingo = thingo2;
            modelImportDialog = modelImportDialog2;
            //this.StartTask(this.WaitForImport);
        }
        private async Task WaitForImport()
        {
            await Task.Run(() =>
            {
                List<Slot> indicators = this.World.AllSlots.Where((Slot s) => s.Name == "Import indicator").ToList();
                if (indicators.Count > 0)
                {
                    Slot indicator = indicators.Last();
                    while (indicator != null) { }
                }
                OnDone.Trigger();
            });
        }
    }
    [Category("LogiX/AAAA")]
    [NodeName("UploadItem")]
    public class UploadThingy : LogixOperator<int>
    {
        public readonly Input<Slot> slot;
        public InventoryBrowser component;
        public readonly Output<string> uri;
        public readonly Input<SolidColorTexture> thumbnail_texture;
        TextureThumbnailSource thumbnail_source;
        SolidColorTexture texture;

        public override int Content
        {
            get
            {
                return this.Engine.RecordManager.SyncingRecordsCount;
            }
        }
        protected override void OnStart()
        {
            if (this.LocalUser == this.World.HostUser)
            {
                base.OnStart();
                Slot thingo = this.LocalUserSpace.AddSlot("Thingo");
                thingo.PersistentSelf = false;
                component = thingo.AttachComponent<InventoryBrowser>();
                FieldInfo fi = typeof(InventoryBrowser).GetField("_user", BindingFlags.NonPublic | BindingFlags.Instance);
                //fi.SetValue(component, this.LocalUser);
                ((UserRef)fi.GetValue(component)).Target = this.LocalUser;
                component.OpenDefault();
            }
        }

        [ImpulseTarget]
        public void Run()
        {
            Slot slott = slot.Evaluate();
            var components = slott.GetComponentsInChildren<IItemThumbnailSource>((Predicate<IItemThumbnailSource>)(s => s.HasThumbnail && s.Slot.IsActive), true, false);
            texture = thumbnail_texture.Evaluate();
            if (components.Count == 0)
            {
                //texture.Color.Value = new BaseX.color(0,0,0,0);
                //texture.Color.Value = new BaseX.color(0,0,0,1);
                thumbnail_source = slott.AttachComponent<TextureThumbnailSource>(true);
                thumbnail_source.Texture.Target = texture;
                Debug.Log(thumbnail_source.HasThumbnail.ToString());
            }
            else
            {
                thumbnail_source = (TextureThumbnailSource) components[0];
            }
            MethodInfo privMethod = typeof(AssetProvider<Texture2D>).GetMethod("RefreshAssetState", BindingFlags.NonPublic | BindingFlags.Instance);
            privMethod.Invoke(texture, new object[] { });
            Debug.Log(thumbnail_source.HasThumbnail.ToString());
            this.StartCoroutine(this.AddItem(slott));
        }
        private IEnumerator<Context> AddItem(Slot slot1)
        {
            //while (!thumbnail_source.HasThumbnail) { 
            //    texture.Color.Value = new BaseX.color(0,0,0,0);
            //    texture.Color.Value = new BaseX.color(0,0,0,1);
            //}
            Task<ItemHelper.SavedItem> itemTask = (Task<ItemHelper.SavedItem>)null;
            this.Engine.WorldManager.FocusedWorld.RunSynchronously((Action)(() =>
            {
                itemTask = ItemHelper.SaveItem(slot1, true);
            }), false, (IUpdatable)null, false);
            while (itemTask == null)
                yield return Context.WaitForNextUpdate();
            yield return Context.WaitFor((Task)itemTask);
            Debug.Log(slot1.ToString());
            ItemHelper.SavedItem item = itemTask.Result;
            MethodInfo privMethod = component.CurrentDirectory.GetType().GetMethod("FullyLoad", BindingFlags.NonPublic | BindingFlags.Instance);
            component.OpenDefault();
            ((Task)privMethod.Invoke(component.CurrentDirectory, new object[] {})).ConfigureAwait(false).GetAwaiter().GetResult();
            Record tempRecord = component.CurrentDirectory.AddItem(item.Name, item.Asset, item.Thumbnail, (IEnumerable<string>)item.Tags);
            component.OpenDefault();
            ((Task)privMethod.Invoke(component.CurrentDirectory, new object[] {})).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        [ImpulseTarget]
        public void GetURL()
        {
            MethodInfo privMethod = component.CurrentDirectory.GetType().GetMethod("FullyLoad", BindingFlags.NonPublic | BindingFlags.Instance);
            component.OpenDefault();
            ((Task)privMethod.Invoke(component.CurrentDirectory, new object[] {})).ConfigureAwait(false).GetAwaiter().GetResult();
            Record record = component.CurrentDirectory.Records.Last<Record>();
            uri.Value = record.AssetURI;
            this.SaveURL();
        }
        public void SaveURL()
        {
            System.IO.File.WriteAllText("neosDBURL.txt", uri.Value);
        }
    }

    //[Category("LogiX/AAAA")]
    //[NodeName("PolyImporter")]
    //public class PolyImporter : LogixNode
    //{
    //    protected override void OnStart()
    //    {
    //        Task.Run(() =>
    //        {
    //            try
    //            {

    //            }
    //            catch (Exception exception)
    //            {
    //                Debug.Log("Server threw exeception : " + exception.Message);
    //                Debug.Log("Server threw exeception : " + exception.ToString());
    //                Debug.Log("Server threw exeception : " + exception.InnerException.Message);
    //                Debug.Log("Server threw exeception : " + exception.InnerException.InnerException.Message);
    //            }

    //        });
    //}
}

