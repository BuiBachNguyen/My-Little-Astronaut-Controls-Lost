using UnityEngine;
public interface IState
{
    void Enter();
    void Execute();
    void Exit();

}

public interface ISelfChange
{
    void SelfChange(IState state);
}