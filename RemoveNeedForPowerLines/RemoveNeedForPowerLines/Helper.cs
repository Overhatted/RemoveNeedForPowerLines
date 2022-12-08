using Harmony;
using ICities;
using System;
using System.IO;
using System.Reflection;
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

    public class Loader : ILoadingExtension
    {
        public void OnCreated(ILoading loading)
        {
#if DEBUG
            Helper.PrintError("");
#endif

            var harmony = HarmonyInstance.Create("com.overhatted.removeneedforpowerlines");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void OnReleased()
        {

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