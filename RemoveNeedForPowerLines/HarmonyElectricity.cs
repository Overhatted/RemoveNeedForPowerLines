using HarmonyLib;
using System;
using UnityEngine;

namespace RemoveNeedForPowerLines
{
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.CheckElectricity))]
    public class CheckElectricityMod
    {
        public static bool Prefix(out bool electricity)
        {
            ElectricityManagerMod.CheckElectricity(out electricity);

            return false;
        }
    }

    //Power Plants
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryDumpElectricity))]
    [HarmonyPatch(new Type[] { typeof(Vector3), typeof(int), typeof(int) })]
    public class TryDumpElectricityVector3Mod
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.DumpElectricity(Math.Min(rate, max));

            return false;
        }
    }

    //Things from Natural Disasters DLC
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryDumpElectricity))]
    [HarmonyPatch(new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) })]
    public class TryDumpElectricityIntMod
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.DumpElectricity(Math.Min(rate, max));

            return false;
        }
    }

    //Buildings
    [HarmonyPatch(typeof(ElectricityManager))]
    [HarmonyPatch(nameof(ElectricityManager.TryFetchElectricity))]
    public class TryFetchElectricityMod
    {
        public static bool Prefix(int rate, int max, ref int __result)
        {
            __result = ElectricityManagerMod.FetchElectricity(Math.Min(rate, max));

            return false;
        }
    }
}
