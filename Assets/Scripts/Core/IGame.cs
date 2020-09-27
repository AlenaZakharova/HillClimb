namespace Core
{
    public interface IGame
    {
        int TraversedPath { get; }
        void MoveForward();
        void MoveBackward();
        void ReleasePedal();
    }
}