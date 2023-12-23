using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using HC;
using HC.Scene;

namespace HideLanguageSelector
{
    [BepInPlugin(GUID, DisplayName, Version)]
    [BepInProcess("HoneyCome")]
    [BepInProcess("HoneyComeccp")]
    [BepInIncompatibility("HideLanguageSelector")]
    public class HideLanguageSelectorPlugin : BasePlugin
    {
        public const string GUID = "HC_HideLanguageSelector";
        public const string DisplayName = "Hide language selection in title menu";
        public const string Version = "1.1";

        public override void Load()
        {
            Harmony.CreateAndPatchAll(typeof(Hooks), GUID);
        }

        public static class Hooks
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(TitleButton), "Start")]
            private static void TitleMenu_Start(TitleButton __instance)
            {
                if (__instance.Event == TitleScene.Events.Language)
                    __instance.gameObject.SetActive(false);
            }
        }
    }
}
