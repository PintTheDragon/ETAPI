using UnityEngine;
using VirtualBrightPlayz.SCP_ET;
using VirtualBrightPlayz.SCP_ET.Misc;

namespace ETAPI.Features
{
    public static class Round
    {
        /// <summary>
        /// Get's if the round is ended. If set to true, the round will end.
        /// </summary>
        public static bool Ended
        {
            get => Object.FindObjectOfType<RoundEnd>()?.roundEnded ?? true;
            set
            {
                if (value)
                {
                    Object.FindObjectOfType<RoundEnd>()?.EndRound("ROUNDENDFORCE", GameSettings.serverSettings.roundEndTime);
                }
            }
        }

        /// <summary>
        /// Ends the round.
        /// </summary>
        /// <param name="time">The amount of time to end. If set to -1, then the round will end based on the server's settings.</param>
        public static void EndRound(int time = -1)
        {
            Object.FindObjectOfType<RoundEnd>()?.EndRound("ROUNDENDFORCE", time == -1 ? GameSettings.serverSettings.roundEndTime : time);
        }
    }
}