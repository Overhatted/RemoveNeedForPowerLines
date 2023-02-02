using CitiesHarmony.API;
using HarmonyLib;
using ICities;
using System;
using System.IO;
using UnityEngine;

namespace RemoveNeedForPowerLines
{
    public class RemoveNeedForPowerLines : IUserMod
    {
        public string Name
        {
            get
            {
                return "Remove Need For Power Lines";
            }
        }

        public string Description
        {
            get
            {
                return "Removes need to place power lines (you still have to produce the electricity)";
            }
        }
    }

    public static class Helper
    {
        public static void PrintError(string Message)
        {
#if DEBUG
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
        "\\RNFPL.txt", Message + Environment.NewLine);
#else
            Debug.Log("[Remove Need For Power Lines] " + Message);
#endif
        }
    }

    public static class Patcher
    {
        private const string HarmonyId = "Overhatted.RemoveNeedForPowerLines";
        private static bool patched = false;

        public static void PatchAll()
        {
            if (patched) return;

            patched = true;
            var harmony = new Harmony(HarmonyId);
            harmony.PatchAll(typeof(Patcher).Assembly);
        }

        public static void UnpatchAll()
        {
            if (!patched) return;

            var harmony = new Harmony(HarmonyId);
            harmony.UnpatchAll(HarmonyId);
            patched = false;
        }
    }

    public class Loader : ILoadingExtension
    {
        public void OnCreated(ILoading loading)
        {
#if DEBUG
            Helper.PrintError("");
#endif

            if (HarmonyHelper.IsHarmonyInstalled) Patcher.PatchAll();
        }

        public void OnReleased()
        {
            if (HarmonyHelper.IsHarmonyInstalled) Patcher.UnpatchAll();
        }

        public void OnLevelLoaded(LoadMode mode)
        {
            ElectricityManagerMod.Init();
        }

        public void OnLevelUnloading()
        {

        }
    }
}