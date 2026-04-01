using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace CannedNet.Client;

[BepInPlugin("lapis.cannednet.client", "CannedNet Client", "1.0.0")]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;

    public override void Load()
    {
        Log = base.Log;
        Log.LogInfo($"I JUST HIT THE JACKPOTTTT!!!!! YUH YUH YUH!");
        
        Harmony.CreateAndPatchAll(typeof(Plugin).Assembly);
    }
}