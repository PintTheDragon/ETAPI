using System.Collections.Generic;

namespace ETAPI.Extensions
{
    public static class Items
    {
        private static Dictionary<string, ItemType> ItemIDs = new Dictionary<string, ItemType>()
        {
            {"", ItemType.None},
            {"Ammo", ItemType.Ammo},
            {"AnomGasmask", ItemType.AnomGasmask},
            {"Badge", ItemType.Badge},
            {"Battery", ItemType.Battery},
            {"BVGoggles", ItemType.BVGoggles},
            {"ItemDocument", ItemType.Document},
            {"Eyedrops", ItemType.Eyedrops},
            {"Flashlight", ItemType.Flashlight},
            {"Gasmask", ItemType.Gasmask},
            {"IVGoggles", ItemType.IVGoggles},
            {"Janitor1", ItemType.Janitor1},
            {"Keycard0", ItemType.Keycard0},
            {"Keycard1", ItemType.Keycard1},
            {"Keycard2", ItemType.Keycard2},
            {"Keycard3", ItemType.Keycard3},
            {"Keycard4", ItemType.Keycard4},
            {"Keycard5", ItemType.Keycard5},
            {"Medkit", ItemType.Medkit},
            {"NVGoggles", ItemType.NVGoggles},
            {"P90", ItemType.P90},
            {"Radio", ItemType.Radio},
            {"SCP714", ItemType.SCP714},
            {"SCP035", ItemType.SCP035},
            {"SCP1025", ItemType.SCP1025},
            {"SCP1499", ItemType.SCP1499},
            {"SNav", ItemType.SNav}
        };

        public static ItemType fromID(string ID)
        {
            return string.IsNullOrEmpty(ID) ? ItemType.None : ItemIDs.TryGetValue(ID, out var id) ? id : ItemType.None;
        }
    }
}