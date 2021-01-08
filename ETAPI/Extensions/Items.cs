using System.Collections.Generic;

namespace ETAPI.Extensions
{
    public static class Items
    {
        private static Dictionary<string, ItemType> ItemIDs = new Dictionary<string, ItemType>()
        {
            
        };

        public static ItemType fromID(string ID)
        {
            return string.IsNullOrEmpty(ID) ? ItemType.None : ItemIDs.TryGetValue(ID, out var id) ? id : ItemType.None;
        }
    }
}