using System;
using System.Reflection;
using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Realtime;

namespace CannedNet.Client.Patches;

[HarmonyPatch]
public class Photon_AppSettings_Patch
{
    private static bool Prepare()
    {
        var type = Type.GetType("PUNNetworkManager");
        if (type == null)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType("PUNNetworkManager");
                if (type != null) break;
            }
        }

        if (type == null)
        {
            Plugin.Log.LogError("Could not find PUNNetworkManager type");
            return false;
        }

        var method = type.GetMethod("FJOLIPKKIBE", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        if (method == null)
        {
            Plugin.Log.LogError("Could not find FJOLIPKKIBE method");
            return false;
        }

        return true;
    }

    private static MethodBase TargetMethod()
    {
        var type = Type.GetType("PUNNetworkManager");
        if (type == null)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType("PUNNetworkManager");
                if (type != null) break;
            }
        }

        return type?.GetMethod("FJOLIPKKIBE", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
    }

    private static void Postfix(ref AppSettings __result)
    {
        Plugin.Log.LogInfo("okay im patching now");
        __result = new()
        {
            AppVersion = __result?.AppVersion,
            AppIdRealtime = "c74d22b7-6665-41cf-9ce8-fc70b625caa6",
            AppIdVoice = "f7adbf03-edae-4a7d-bb4b-9e06de75bd96",
            AppIdChat = "4538ca46-903b-48d9-bf33-247ea468a29d",
            FixedRegion = "us",
            UseNameServer = true,
            Protocol = ConnectionProtocol.Udp,
        };
    }
}
