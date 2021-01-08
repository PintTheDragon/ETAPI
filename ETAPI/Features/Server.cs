using Assets.MirrorEXT;
using Discord;
using LiteMirror;
using LiteNetLibMirror;

namespace ETAPI.Features
{
    public static class Server
    {
        /// <summary>
        /// Gets the server's IP. This can be either an actual IP, or a lobby ID. To check if it is a lobby, use the IsLobby property.
        /// </summary>
        public static string IP
        {
            get
            {
                var address = "";
                if (CustomNetworkManager.manager.server.transport is LiteNetLibTransport)
                {
                    address = CustomNetworkManager.manager.currentServerAddress;
                }
                else
                {
                    address = !(CustomNetworkManager.manager.server.transport is LiteMirrorTransport) ? (CustomNetworkManager.lobby).Id.Value.ToString() : ((LiteMirrorTransport) CustomNetworkManager.manager.server.transport).GetRoomId();
                }

                return address;
            }
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