using BepInEx;
using UnityEngine;

namespace NoClipBananaOS
{
    [BepInPlugin(Constants.GUID, Constants.NAME, Constants.VERS)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool IsEnabled;
        public static bool NoClipOn;

        private void Update()
        {
            if (Plugin.IsEnabled && NetworkSystem.Instance.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED"))
            {
                if (ControllerInputPoller.instance.leftControllerSecondaryButton && !NoClipOn)
                {
                    MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    for (int i = 0; i < array.Length; i++)
                        array[i].enabled = false;

                    NoClipOn = true;
                }

                if (!ControllerInputPoller.instance.leftControllerSecondaryButton && NoClipOn)
                {
                    MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    for (int i = 0; i < array.Length; i++)
                        array[i].enabled = true;

                    NoClipOn = false;
                }
            }
        }
    }

    internal class Constants
    {
        public const string 
            GUID = "com.Estatic.NoClip",
            NAME = "NoClip",
            VERS = "1.1.0";
    }
}