using BepInEx;
using Harmony;

namespace InsultOrderDemosaic
{
    [BepInPlugin(Guid, "Demosaic", "1.0")]
    public class Demosaic : BaseUnityPlugin
    {
        private const string Guid = "io.marc0.demosaic";

        public Demosaic()
        {
            Hooks.InstallHooks(Guid);
        }
    }

    internal static class Hooks
    {
        public static void InstallHooks(string guid)
        {
            var harmony = HarmonyInstance.Create(guid);
            harmony.PatchAll(typeof(Hooks));
        }
        
        [HarmonyPrefix, HarmonyPatch(typeof(MozaicSetUp), "Update")]
        public static bool UpdateHook(MozaicSetUp __instance)
        {
            if (__instance.MozaObj != null) __instance.MozaObj.enabled = false;
            return false;
        }
    }
}
