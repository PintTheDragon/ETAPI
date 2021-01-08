using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;

namespace ETAPI.Features
{
    public class Inventory
    {
        private VirtualBrightPlayz.SCP_ET.Items.ItemSystem.Inventory baseInv;
        
        internal Inventory(Player player)
        {
            this.baseInv = player.PlayerController.stats.inv;
        }

        /// <summary>
        /// Gets or sets the item the player is currently holding.
        /// </summary>
        [CanBeNull]
        public Item CurrentItem
        {
            get => this.baseInv.current != null ? new Item(this.baseInv.current) : null;
            set
            {
                if(value == null) this.baseInv.RemoveItem(this.baseInv.CurItem);
                else this.baseInv.Items[this.baseInv.CurItem] = value.itemBase;
            }
        }
        
        /// <summary>
        /// Gets or sets the item the player is currently wearing.
        /// </summary>
        [CanBeNull]
        public Item CurrentWornItem
        {
            get => this.baseInv.currentWorn != null ? new Item(this.baseInv.currentWorn) : null;
            set
            {
                if(value == null) this.baseInv.RemoveItem(this.baseInv.CurWornItem);
                else this.baseInv.Items[this.baseInv.CurWornItem] = value.itemBase;
            }
        }

        /// <summary>
        /// Gets the items in the player's inventory.
        /// </summary>
        public ReadOnlyCollection<Item> Items
        {
            get
            {
                var list = new List<Item>();

                foreach (var item in this.baseInv.Items)
                {
                    list.Add(new Item(item));
                }

                return list.AsReadOnly();
            }
        }

        /// <summary>
        /// Sets the player's item by index, or removes it if item is null.
        /// </summary>
        /// <param name="index">The index in the inventory of the item.</param>
        /// <param name="item">The item to be added to the inventory.</param>
        public void SetItem(int index, [CanBeNull] Item item)
        {
            if(item == null) this.baseInv.RemoveItem(index);
            else this.baseInv.Items[index] = item.itemBase;
        }
    }
}