using Model;
using UnityEngine;

namespace Common
{
    public static class Prefs
    {
        private const string PlayerDataKey = "PlayerData";

        public static Player LoadPlayer()
        {
            string json = PlayerPrefs.GetString(PlayerDataKey, string.Empty);
            return json == string.Empty ? null : JsonUtility.FromJson<Player>(json);
        }

        public static void SavePlayer(Player player)
        {
            PlayerPrefs.SetString(PlayerDataKey, JsonUtility.ToJson(player));
        }
    }
}