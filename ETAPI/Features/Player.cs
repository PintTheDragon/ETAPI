using System.Collections.Generic;
using System.Collections.ObjectModel;
using ETAPI.Enums;
using JetBrains.Annotations;
using PluginFramework.Classes;
using UnityEngine;
using VirtualBrightPlayz.SCP_ET.Player;

namespace ETAPI.Features
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
        /// Gets all of the players in the server.
        /// </summary>
        public static ReadOnlyCollection<Player> List
        {
            get
            {
                var players = new List<Player>();
                
                foreach (var player in Object.FindObjectsOfType<PlayerController>())
                {
                    players.Add(new Player(player.stats));
                }
                
                return players.AsReadOnly();
            }
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
        /// Kick a player from the server.
        /// </summary>
        /// <param name="message">The message to be sent to the player.</param>
        public void Kick(string message = "You have been kicked from the server!")
        {
            this.PlayerController.Disconnect(message);
        }

        /// <summary>
        /// Gets or sets the player's name.
        /// </summary>
        public string PlayerName => this.PlayerController.NetworkplayerName;

        /// <summary>
        /// Gets or sets the player's group.
        /// </summary>
        public string PlayerGroup => this.PlayerController.NetworkplayerGroup;

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
        public float Health => this.PlayerController.healthController.NetworkHealth;

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
                var id = this.PlayerController.ConnectionToClient.AuthenticationData.ToString();
                return string.IsNullOrEmpty(id) ? null : id;
            }
        }

        /// <summary>
        /// Gets the player's IP address.
        /// </summary>
        public string IP
        {
            get => this.PlayerController.ConnectionToClient.Address.ToString().Replace("[::ffff:", string.Empty).Replace("]", string.Empty).Split(':')[0];
        }
        
        /// <summary>
        /// Gets the player's transform.
        /// </summary>
        public Transform Transform
        {
            get => this.GameObject.transform;
        }

        /// <summary>
        /// Gets or sets the player's position.
        /// </summary>
        public Vector3 Position => this.Transform.position;

        /// <summary>
        /// Gets or sets the player's rotation.
        /// </summary>
        public Quaternion Rotation => this.Transform.rotation;

        /// <summary>
        /// Gets or sets the player's scale.
        /// </summary>
        public Vector3 Scale => this.Transform.localScale;

        /// <summary>
        /// Gets or sets if the player is in god mode.
        /// </summary>
        public bool GodMode => this.PlayerController.Network_godMode;

        /// <summary>
        /// Gets or sets the player's walk speed.
        /// </summary>
        public float WalkSpeed => this.PlayerController.NetworkwalkSpeed;
        
        /// <summary>
        /// Gets or sets the player's sprint speed.
        /// </summary>
        public float SprintSpeed => this.PlayerController.NetworksprintSpeed;
        
        /// <summary>
        /// Gets or sets the player's crouch speed.
        /// </summary>
        public float CrouchSpeed => this.PlayerController.NetworkcrouchSpeed;

        /// <summary>
        /// Gets or sets the player's jump height.
        /// </summary>
        public float JumpHeight => this.PlayerController.NetworkjumpHeight;
        
        /// <summary>
        /// Gets or sets whether or not the player is noclipping.
        /// </summary>
        public bool Noclip => this.PlayerController.NetworkisFly;
        
        /// <summary>
        /// Gets or sets whether or not the player can be targeted.
        /// </summary>
        public bool NoTarget => this.PlayerController.NetworknoTarget;
        
        public override bool Equals(object obj)
        {
            return obj != null && obj is Player && ((Player) obj).GameObject.Equals(this.GameObject);
        }

        public static bool operator ==(Player obj1, object obj2)
        {
            return obj1?.Equals(obj2) ?? false;
        }

        public static bool operator !=(Player obj1, object obj2)
        {
            return !(obj1 == obj2);
        }
    }
}