using JetBrains.Annotations;
using PluginFramework.Classes;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET.Player;

namespace ETAPI
{
    public class Player
    {
        private IPlayer player;
        private Inventory inv;

        public Player(IPlayer player)
        {
            this.player = player;
            this.inv = new Inventory(this);
        }
        
        /// <summary>
        /// Gets the player's gameobject.
        /// </summary>
        public GameObject GameObject
        {
            get => this.player.gameObject;
        }

        /// <summary>
        /// Gets or sets the player's dimension.
        /// </summary>
        public Dimension CurrentDimension
        {
            get => (Dimension) this.player.CurrentDimension;

            set => this.player.CurrentDimension = (int) value;
        }
        
        /// <summary>
        /// Sends a message to the player's chat window.
        /// </summary>
        public void SendPlayerChatMessage(string message)
        {
            this.player.SendPlayerChatMessage(message);
        }

        /// <summary>
        /// Kills the player.
        /// </summary>
        public void KillPlayer()
        {
            this.player.KillPlayer();
        }

        /// <summary>
        /// Gets or sets the player's name.
        /// </summary>
        public string PlayerName
        {
            get => this.player.PlayerName;
            set => this.player.PlayerName = value;
        }

        /// <summary>
        /// Gets the player's controller.
        /// </summary>
        public PlayerController PlayerController
        {
            get => this.PlayerController;
        }

        /// <summary>
        /// Gets or sets the player's health.
        /// </summary>
        public float Health
        {
            get => this.PlayerController.healthController.Health;
            set => this.PlayerController.healthController.Health = value;
        }

        /// <summary>
        /// Gets or sets the player's current role.
        /// </summary>
        public Role Role
        {
            get => (Role) this.PlayerController.stats.ClassId;
            set => this.PlayerController.stats.ClassId = (int) value;
        }

        /// <summary>
        /// Gets the player's inventory.
        /// </summary>
        public Inventory Inventory
        {
            get => this.inv;
        }

        /// <summary>
        /// Gets the player's steam id, or null if they don't have one.
        /// </summary>
        [CanBeNull]
        public string SteamID
        {
            get
            {
                var id = ((ulong) this.PlayerController.ConnectionToClient.AuthenticationData).ToString();
                return string.IsNullOrEmpty(id) ? null : id;
            }
        }

        /// <summary>
        /// Gets or sets the player's position.
        /// </summary>
        public Vector3 Position
        {
            get => this.Transform.position;
            set => this.Transform.position = value;
        }
        
        /// <summary>
        /// Gets or sets the player's rotation.
        /// </summary>
        public Quaternion Rotation
        {
            get => this.Transform.rotation;
            set => this.Transform.rotation = value;
        }
        
        /// <summary>
        /// Gets or sets the player's scale.
        /// </summary>
        public Vector3 Scale
        {
            get => this.Transform.localScale;
            set => this.Transform.localScale = value;
        }
        
        /// <summary>
        /// Gets the player's transform.
        /// </summary>
        public Transform Transform
        {
            get => this.GameObject.transform;
        }
    }
}