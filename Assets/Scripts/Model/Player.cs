using Common;

namespace Model
{
    public class Player
    {
       public static Player Load()
        {
            Player player = Prefs.LoadPlayer();
            if (player == null)
            {
                player = new Player
                {
                };
                player.Save();
            }

            return player;
        }

        public void Save()
        {
            Prefs.SavePlayer(this);
        }
    }
}