using Configuration;

namespace Core
{
    public class Game
    {
        private readonly IMeta meta;
        private readonly GameConfig config;
        private readonly FollowCamera followCamera;
   
        public Game(IMeta meta, GameConfig config, FollowCamera followCamera)
        {
            this.meta = meta;
            this.config = config;
            this.followCamera = followCamera;
        }

        public void Setup()
        {
            //followCamera.SetTarget(playerCar);
        }

        public void Start()
        {
            /*isPlaying = true;

            playerCar.StartMotion();

            */
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            /*if (!isPlaying)
                return;

            for (var i = 0; i < bots.Count; i++)
            {
                bots[i].UpdateSteering();
            }*/
        }

        private void FinishGame(bool win)
        {
            meta.FinishGame();

        }

       
    }
}