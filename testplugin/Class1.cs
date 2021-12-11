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

namespace FrooxEngine.LogiX
{
    [Category("LogiX/AAAA")]
    [NodeName("UwU")]
    public class UwU : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            ComponentCloneTip cctip = thingo.AttachComponent<ComponentCloneTip>();
            //ComponentAttacher component = slot.AttachComponent<ComponentAttacher>();
            //UIBuilder ui = this.GenerateUI(this.Slot, 0.0f, 0.0f);
            //BaseX.color white = BaseX.color.White;
            //ref BaseX.color local = ref white;
            //ButtonEventHandler<string> callback = new ButtonEventHandler<string>(this.test);
            ////ui.Button<string>("Pulse", in local, action, 0.0f);
            //Button button = ui.Button<string>("Pulse", callback, "");
            //actionTrigger = slot.AttachComponent<ButtonActionTrigger>();
            //Action<Slot> action = (Action<Slot>)Delegate.CreateDelegate(typeof(Action<Slot>), cctip, "PlaceOn");
            MethodInfo privMethod = cctip.GetType().GetMethod("PlaceOn", BindingFlags.NonPublic | BindingFlags.Instance);
            Action<Slot> action = (Action<Slot>)Delegate.CreateDelegate(typeof(Action<Slot>), cctip, privMethod);
            //Action<Slot> action = (Action<Slot>)privMethod.CreateDelegate()
            Slot thingo2 = this.LocalUserSpace.AddSlot("Thingo2");
            CallbackRefArgument<Slot> callback = thingo2.AttachComponent<CallbackRefArgument<Slot>>();
            callback.Callback.Target = action;
            ImpulseTargetProxy proxy = thingo2.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            //proxy.ImpulseTarget.Target = action;
            proxy.ImpulseTarget.Target = (Action)callback.Call;
        }

        [ImpulseTarget]
        public void Run()
        {
            //ImpulseTargetProxy proxy = slot.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            ////proxy.ImpulseTarget.Target = action;
            //proxy.ImpulseTarget.Target = actionTrigger.OnPressed.Target;
            //ComponentCloneTip cctip = slot.AttachComponent<ComponentCloneTip>();
            //this.Slot.AttachComponent<Grabbable>(true, (Action<Grabbable>)null).Scalable.Value = true;
            //UIBuilder uiBuilder3 = new UIBuilder(this.Slot, 600f, 1000f, 0.0005f);
            //UIBuilder uiBuilder2 = uiBuilder3;
            //BaseX.color color = new BaseX.color(1f, 1f, 1f, 0.8f);
            //ref BaseX.color local = ref color;
            //uiBuilder2.Panel(in local, true);
            //uiBuilder3.Style.ForceExpandHeight = false;
            //uiBuilder3.ScrollArea();
            //uiBuilder3.VerticalLayout(8f, 8f, new BaseX.Alignment?());
            //uiBuilder3.FitContent(SizeFit.Disabled, SizeFit.MinSize);
            //this._uiRoot.Target = uiBuilder3.Root;
            //UIBuilder uiBuilder1 = new UIBuilder(this._uiRoot.Target, (Slot)null);
            //uiBuilder1.Style.MinHeight = 32f;

            //ButtonEventHandler<string> callback = new ButtonEventHandler<string>();
            //uiBuilder2.Button<string>("AttachComponent", in local, callback, path1, 0.35f);
        }
        public void test(IButton button, ButtonEventData eventData, string a)
        {
            return;
        }
    }

    [Category("LogiX/AAAA")]
    [NodeName("OwO")]
    public class OwO : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            InventoryBrowser component = thingo.AttachComponent<InventoryBrowser>();
            //ComponentAttacher component = slot.AttachComponent<ComponentAttacher>();
            //UIBuilder ui = this.GenerateUI(this.Slot, 0.0f, 0.0f);
            //BaseX.color white = BaseX.color.White;
            //ref BaseX.color local = ref white;
            //ButtonEventHandler<string> callback = new ButtonEventHandler<string>(this.test);
            ////ui.Button<string>("Pulse", in local, action, 0.0f);
            //Button button = ui.Button<string>("Pulse", callback, "");
            //actionTrigger = slot.AttachComponent<ButtonActionTrigger>();
            //Action<Slot> action = (Action<Slot>)Delegate.CreateDelegate(typeof(Action<Slot>), cctip, "PlaceOn");
            //MethodInfo privMethod = cctip.GetType().GetMethod("PlaceOn", BindingFlags.NonPublic | BindingFlags.Instance);
            Action<Uri> action = (Action<Uri>)Delegate.CreateDelegate(typeof(Action<Uri>), component, "Spawn");
            //Action<Slot> action = (Action<Slot>)privMethod.CreateDelegate()
            Slot thingo2 = this.LocalUserSpace.AddSlot("Thingo2");
            CallbackValueArgument<Uri> callback = thingo2.AttachComponent<CallbackValueArgument<Uri>>();
            callback.Callback.Target = action;
            ImpulseTargetProxy proxy = thingo2.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            //proxy.ImpulseTarget.Target = action;
            proxy.ImpulseTarget.Target = (Action)callback.Call;
        }

        [ImpulseTarget]
        public void Run()
        {
            //ImpulseTargetProxy proxy = slot.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            ////proxy.ImpulseTarget.Target = action;
            //proxy.ImpulseTarget.Target = actionTrigger.OnPressed.Target;
            //ComponentCloneTip cctip = slot.AttachComponent<ComponentCloneTip>();
            //this.Slot.AttachComponent<Grabbable>(true, (Action<Grabbable>)null).Scalable.Value = true;
            //UIBuilder uiBuilder3 = new UIBuilder(this.Slot, 600f, 1000f, 0.0005f);
            //UIBuilder uiBuilder2 = uiBuilder3;
            //BaseX.color color = new BaseX.color(1f, 1f, 1f, 0.8f);
            //ref BaseX.color local = ref color;
            //uiBuilder2.Panel(in local, true);
            //uiBuilder3.Style.ForceExpandHeight = false;
            //uiBuilder3.ScrollArea();
            //uiBuilder3.VerticalLayout(8f, 8f, new BaseX.Alignment?());
            //uiBuilder3.FitContent(SizeFit.Disabled, SizeFit.MinSize);
            //this._uiRoot.Target = uiBuilder3.Root;
            //UIBuilder uiBuilder1 = new UIBuilder(this._uiRoot.Target, (Slot)null);
            //uiBuilder1.Style.MinHeight = 32f;

            //ButtonEventHandler<string> callback = new ButtonEventHandler<string>();
            //uiBuilder2.Button<string>("AttachComponent", in local, callback, path1, 0.35f);
        }
        public void test(IButton button, ButtonEventData eventData, string a)
        {
            return;
        }
    }
    
    [Category("LogiX/AAAA")]
    [NodeName("UwO")]
    public class UwO : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            LogixTip component = thingo.AttachComponent<LogixTip>();
            Action action = (Action)Delegate.CreateDelegate(typeof(Action), component, "OnPrimaryPress");
            Slot thingo2 = this.LocalUserSpace.AddSlot("Thingo2");
            ImpulseTargetProxy proxy = thingo2.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy.ImpulseTarget.Target = action;
        }

        [ImpulseTarget]
        public void Run()
        {
        }
    }

    [Category("LogiX/AAAA")]
    [NodeName("OwU")]
    public class OwU : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            LogixTip component = thingo.AttachComponent<LogixTip>();
            Action action2 = (Action)Delegate.CreateDelegate(typeof(Action), component, "OnPrimaryRelease");
            Slot thingo2 = this.LocalUserSpace.AddSlot("Thingo2");
            ImpulseTargetProxy proxy2 = thingo2.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy2.ImpulseTarget.Target = action2;

            Action action3 = (Action)Delegate.CreateDelegate(typeof(Action), component, "OnPrimaryRelease");
            Slot thingo3 = this.LocalUserSpace.AddSlot("Thingo3");
            ImpulseTargetProxy proxy3 = thingo3.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy3.ImpulseTarget.Target = action3;

            Action action4 = (Action)Delegate.CreateDelegate(typeof(Action), component, "SpawnNode");
            Slot thingo4 = this.LocalUserSpace.AddSlot("Thingo4");
            ImpulseTargetProxy proxy4 = thingo4.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy4.ImpulseTarget.Target = action4;
        }

        [ImpulseTarget]
        public void Run()
        {
        }
    }
    [Category("LogiX/AAAA")]
    [NodeName("3DModelImporterUwU")]
    public class ModelImporterUwU : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            var modelImportDialog = thingo.AttachComponent<ModelImportDialog>();
            //modelImportDialog.Paths.AddRange(new List<string>() { "http://aec237e9a0d5.ngrok.io/model.obj"});
            modelImportDialog.Paths.AddRange(new List<string>() { "D:\\code\\neos\\neosobj\\model.ply" });
            FieldInfo fi = typeof(ImportDialog).GetField("_importingUser", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(modelImportDialog, this.LocalUser);
            modelImportDialog._snappable.Value = false;
            modelImportDialog._scale.Value = 1f;
            modelImportDialog._autoScale.Value = true;

            FrooxEngine.Slot slot1 = this.LocalUserSpace.AddSlot("Display Impulse UwU", true);
            ((LogixNode)slot1.AttachComponent<LogiX.Display.DisplayImpulse>(true, (Action<Component>)null)).GenerateVisual();
            Slot imageSlot = slot1[0][0][0][0];
            var old_impulse_proxy = imageSlot.GetComponent<ImpulseTargetProxy>();
            imageSlot.RemoveComponent(old_impulse_proxy);
            Action action2 = (Action)Delegate.CreateDelegate(typeof(Action), modelImportDialog, "RunImport");
            ImpulseTargetProxy proxy2 = imageSlot.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy2.ImpulseTarget.Target = action2;
        }
    }

    //[Category("LogiX/AAAA")]
    //[NodeName("UploadItem")]
    //public class UploadThingy : LogixOperator<int>
    //{
    //    public readonly Input<Slot> slot;
    //    public InventoryBrowser component;
    //    public readonly Output<string> uri;

    //    public override int Content
    //    {
    //        get
    //        {
    //            return this.Engine.RecordManager.SyncingRecordsCount;
    //        }
    //    }
    //    protected override void OnAttach()
    //    {
    //        Slot thingo = this.LocalUserSpace.AddSlot("Thingo");
    //        component = thingo.AttachComponent<InventoryBrowser>();
    //        component.OpenDefault();
    //    }

    //    [ImpulseTarget]
    //    public void Run()
    //    {
    //        //component.StartTask((Func<Task>)(async () => await this.AddItem().ConfigureAwait(false)));
    //        //component.AddItem(slot.Evaluate(), true);
    //        this.StartCoroutine(this.AddItem());
    //    }
    //    private IEnumerator<Context> AddItem()
    //    {
    //        Task<ItemHelper.SavedItem> itemTask = (Task<ItemHelper.SavedItem>)null;
    //        this.Engine.WorldManager.FocusedWorld.RunSynchronously((Action)(() =>
    //        {
    //            itemTask = ItemHelper.SaveItem(slot.Evaluate(), true);
    //        }), false, (IUpdatable)null, false);
    //        //ItemHelper.SavedItem item = ItemHelper.SaveItem(slot.Evaluate(), true).ConfigureAwait(false).GetAwaiter().GetResult();
    //        while (itemTask == null)
    //            yield return Context.WaitForNextUpdate();
    //        yield return Context.WaitFor((Task)itemTask);
    //        ItemHelper.SavedItem item = itemTask.Result;
    //        Record tempRecord = component.CurrentDirectory.AddItem(item.Name, item.Asset, item.Thumbnail, (IEnumerable<string>)item.Tags);
    //        //this.Engine.LocalDB.DeleteCacheRecord(new System.Uri(tempRecord.AssetURI));
    //        this.GetURL();
    //    }
    //    [ImpulseTarget]
    //    public void GetURL()
    //    {

    //        MethodInfo privMethod = component.CurrentDirectory.GetType().GetMethod("FullyLoad", BindingFlags.NonPublic | BindingFlags.Instance);
    //        //MethodInfo privMethod = this.Engine.RecordManager.GetType().GetMethod("SyncRecords", BindingFlags.NonPublic | BindingFlags.Instance);
    //        //FieldInfo fi = this.Engine.RecordManager.GetType().GetField("currentCancelationToken", BindingFlags.NonPublic | BindingFlags.Instance);
    //        //CancellationTokenSource currentCancelationToken = (CancellationTokenSource) fi.GetValue(this.Engine.RecordManager);
    //        //((Task)privMethod.Invoke(this.Engine.RecordManager, new object[] { currentCancelationToken.Token })).ConfigureAwait(false).GetAwaiter().GetResult();
    //        //while (this.Engine.RecordManager.SyncingRecordsCount > 0) { }
    //        component.OpenDefault();
    //        ((Task)privMethod.Invoke(component.CurrentDirectory, new object[] {})).ConfigureAwait(false).GetAwaiter().GetResult();
    //        //TaskAwaiter awaiter2 = component.CurrentDirectory.EnsureFullyLoaded().GetAwaiter();
    //        //awaiter2.GetResult();
    //        Record record = component.CurrentDirectory.Records.Last<Record>();
    //        uri.Value = record.AssetURI;
    //    }
    //}

    [Category("LogiX/AAAA")]
    [NodeName("TestListAdd")]
    public class ListAdd : LogixNode
    {
        public Slot thingo;
        public ButtonActionTrigger actionTrigger;
        protected override void OnAttach()
        {
            base.OnAttach();
            thingo = this.LocalUserSpace.AddSlot("Thingo");
            CallbackValueArgument<object> callback = thingo.AttachComponent<CallbackValueArgument<object>>();
            ValueField<BaseX.RawList<object>> storage = thingo.AttachComponent<ValueField<BaseX.RawList<object>>>();
            //SyncList<string> thing;
            //BaseX.RawList<string> thing;
            //ValueMultiplexer<BaseX.RawList<object>> list = thingo.AttachComponent<ValueMultiplexer<BaseX.RawList<object>>>();
            //list.Values.Add(new BaseX.RawList<object>(2));
            //list.Index.Value = 0;
            //Action<object> action = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), list.Value, "Add");
            storage.Value.ForceSet(new BaseX.RawList<object>(2));
            Action<object> action = new Action<object>(storage.Value.Value.Add);
            //callback.Callback.Target = action;
            FieldInfo fi = callback.Callback.GetType().GetField("_target", BindingFlags.NonPublic | BindingFlags.Instance);
            fi.SetValue(callback.Callback,action);


            FrooxEngine.Slot slot1 = this.LocalUserSpace.AddSlot("Display Impulse UwU", true);
            ((LogixNode)slot1.AttachComponent<LogiX.Display.DisplayImpulse>(true, (Action<Component>)null)).GenerateVisual();
            Slot imageSlot = slot1[0][0][0][0];
            var old_impulse_proxy = imageSlot.GetComponent<ImpulseTargetProxy>();
            imageSlot.RemoveComponent(old_impulse_proxy);
            ImpulseTargetProxy proxy1 = imageSlot.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            proxy1.ImpulseTarget.Target = callback.Call;

            //CallbackValueArgument<object[]> callback2 = thingo.AttachComponent<CallbackValueArgument<object[]>>();
            //Action<object[], int> aa = (Action<object[], int>)Delegate.CreateDelegate(typeof(Action<object[], int>), storage.Value.Value, "CopyTo");
            //Action<object[]> aaa = new Action<object[]>((Action<object[]>)aa.DynamicInvoke);
            ////AAAAAH DOESNT WORK BECAUSE DynamicInvoke has a non-void return type, so it's not an Action!!! GRRRRR
            //Action<object[]> action2 = new Action<object[]>(aaa);
            //fi.SetValue(callback.Callback, action2);
            //FrooxEngine.Slot slot2 = this.LocalUserSpace.AddSlot("Display Impulse UwU2", true);
            //((LogixNode)slot2.AttachComponent<LogiX.Display.DisplayImpulse>(true, (Action<Component>)null)).GenerateVisual();
            //Slot imageSlot2 = slot2[0][0][0][0];
            //var old_impulse_proxy2 = imageSlot2.GetComponent<ImpulseTargetProxy>();
            //imageSlot2.RemoveComponent(old_impulse_proxy2);
            //ImpulseTargetProxy proxy2 = imageSlot2.AttachComponent<ImpulseTargetProxy>(true, (Action<ImpulseTargetProxy>)null);
            //proxy2.ImpulseTarget.Target = callback2.Call;
        }
    }
}
