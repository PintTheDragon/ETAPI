using System.Collections.Generic;
using System.Linq;
using Assets.MirrorEXT;
using Discord;
using JetBrains.Annotations;
using LiteMirror;
using LiteNetLibMirror;
using VirtualBrightPlayz.SCP_ET.Misc;

namespace ETAPI.Features
{
    public static class Server
    {
        private static List<string> nameItems = new List<string>();
        private static string curName = null;
        
        /// <summary>
        /// Gets the server's IP. This can be either an actual IP, or a lobby ID. To check if it is a lobby, use the IsLobby property. If this is null, then an error has most likely occured.
        /// </summary>
        [CanBeNull]
        public static string IP
        {
            get
            {
                string address = null;
                if (CustomNetworkManager.manager.server.transport is LiteNetLibTransport)
                {
                    address = CustomNetworkManager.manager.server.transport.ServerUri().FirstOrDefault()?.Host;
                }
                else
                {
                    address = !(CustomNetworkManager.manager.server.transport is LiteMirrorTransport) ? (CustomNetworkManager.lobby).Id.Value.ToString() : ((LiteMirrorTransport) CustomNetworkManager.manager.server.transport).GetRoomId();
                }

                return address;
            }
        }

        /// <summary>
        /// Gets the server's port. This will be -1 if the server is a lobby.
        /// </summary>
        public static int Port => CustomNetworkManager.manager.server.transport.ServerUri().FirstOrDefault()?.Port ?? -1;

        /// <summary>
        /// Gets or sets the server's name that will appear in the server list. If you want to add tokens to the server name, using AddToName and RemoveFromName methods are recommended.
        /// </summary>
        public static string Name
        {
            get => GameSettings.serverSettings.serverName;
            set => GameSettings.serverSettings.serverName = value;
        }

        /// <summary>
        /// Adds a new item to the end of the server name. This is useful for adding tokens to the name.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public static void AddToName(string item)
        {
            if (string.IsNullOrEmpty(curName)) curName = Name;
            
            nameItems.Add(item);
            Name = curName + string.Join("", nameItems);
        }

        /// <summary>
        /// Removes an item from the server name. This item must first be added with AddToName.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        public static void RemoveFromName(string item)
        {
            if (string.IsNullOrEmpty(curName)) curName = Name;

            nameItems.Remove(item);
            Name = curName + string.Join("", nameItems);
        }

        /// <summary>
        /// Gets if the server is a lobby (through steam or a relay). If false, then IP will be an actual IP.
        /// </summary>
        public static bool IsLobby => !(CustomNetworkManager.manager.server.transport is LiteNetLibTransport);

        /// <summary>
        /// Gets if the server is dedicated.
        /// </summary>
        public static bool IsDedicated => CustomNetworkManager.isDedicated;
    }
}