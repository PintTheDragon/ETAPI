using ETAPI.Enums;
using ETAPI.Extensions;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET.Items.ItemSystem;

namespace ETAPI.Features
{
    public class Item
    {
        public override int GetHashCode()
        {
            return (item != null ? item.GetHashCode() : 0);
        }

        private ItemBase item;

        public Item(ItemBase item)
        {
            this.item = item;
        }

        /// <summary>
        /// Gets the item's gameobject.
        /// </summary>
        public GameObject GameObject
        {
            get => this.item.gameObject;
            set {}
        }

        /// <summary>
        /// Gets the item's ID.
        /// </summary>
        public ItemType ID
        {
            get => Items.fromID(this.item.ItemId);
            set {}
        }

        /// <summary>
        /// Gets the item's typename, which is the name of the item's class.
        /// </summary>
        public string TypeName
        {
            get => this.item.TypeName;
            set {}
        }

        /// <summary>
        /// Gets whether or not the item is wearable.
        /// </summary>
        public bool IsWorn
        {
            get => this.item.IsWornItem;
            set {}
        }

        public ItemBase itemBase
        {
            get => this.item;
            set {}
        }

        public override string ToString()
        {
            return ((int) this.ID).ToString();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Item && ((Item) obj).GameObject.Equals(this.GameObject);
        }

        public static bool operator ==(Item obj1, object obj2)
        {
            return obj1?.Equals(obj2) ?? false;
        }

        public static bool operator !=(Item obj1, object obj2)
        {
            return !(obj1 == obj2);
        }
    }
}