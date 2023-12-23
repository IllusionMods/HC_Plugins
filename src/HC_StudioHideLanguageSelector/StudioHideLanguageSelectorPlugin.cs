using BepInEx;
using BepInEx.Unity.IL2CPP;
using Cysharp.Threading.Tasks;
using DigitalCraft;
using HarmonyLib;

namespace StudioHideLanguageSelector
{
    [BepInPlugin(GUID, DisplayName, Version)]
    [BepInProcess("DigitalCraft")]
    public class StudioHideLanguageSelectorPlugin : BasePlugin
    {
        public const string GUID = "HC_StudioHideLanguageSelector";
        public const string DisplayName = "Hide language selection in studio title menu";
        public const string Version = "1.0";

        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(Hooks), GUID);
        }

        private static class Hooks
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(StartScene), "Start")]
            private static void StartScene_Start_Postfix(StartScene __instance, ref UniTask __result)
            {
                __result = __result.ContinueWith((Il2CppSystem.Action)new Action(() => __instance.buttonLanguage.gameObject.SetActive(false)));
            }
        }
    }
}
