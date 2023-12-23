using BepInEx;
using BepInEx.Unity.IL2CPP;
using Cysharp.Threading.Tasks;
using DigitalCraft;
using HarmonyLib;

namespace StudioTitleSkip
{
    [BepInPlugin(GUID, DisplayName, Version)]
    [BepInProcess("DigitalCraft")]
    public class StudioTitleSkipPlugin : BasePlugin
    {
        public const string GUID = "HC_StudioTitleSkip";
        public const string DisplayName = "Skip title screen in studio";
        public const string Version = "1.0";

        private static Harmony? _hi;

        public override void Load()
        {
            var enabled = Config.Bind("General", "Skip title screen", true, "Automatically load into studio mode on game start.\nYou can still go to the title screen by clicking `System > Back to Title` in the top left menu.").Value;

            if (enabled)
                _hi = Harmony.CreateAndPatchAll(typeof(Hooks), GUID);
        }

        private static class Hooks
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(StartScene), "Start")]
            private static void StartScene_Start_Postfix(StartScene __instance, ref UniTask __result)
            {
                __result = __result.ContinueWith((Il2CppSystem.Action)new Action(() =>
                {
                    // todo: Ideally we'd just load right into the right scene in a false prefix to skip the fade in/out
                    __instance.buttonStart.onClick.Invoke();

                    // Hide all title screen buttons so that it looks like a splash screen
                    foreach (var button in __instance.gameObject.GetComponentsInChildren<UnityEngine.UI.Button>())
                        button.gameObject.SetActive(false);

                    // Only skip the title screen once at game start, so that user can still access it if they want from `System > Back to Title`
                    _hi?.UnpatchSelf();
                }));
            }
        }
    }
}
