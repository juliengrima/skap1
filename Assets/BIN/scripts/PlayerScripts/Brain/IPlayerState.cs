public interface IPlayerState
{
    void Enter();
    void Exit();
    void HandleInput();
    void Update();
    void FixedUpdate();
    //Data's methods FSMPlayer fsmPlayer
}
