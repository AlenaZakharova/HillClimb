using Model;

namespace Core
{
    public interface IMeta
    {
        Player Player { get; }
        void StartGame();
        void FinishGame();
        void GoToMenu();
    }
}