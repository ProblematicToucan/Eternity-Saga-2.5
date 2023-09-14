using UnityEngine;
public enum BattleState
{
    Sart,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}

public class BattleSystem : MonoBehaviour
{
    public BattleState State;
    void Start()
    {
        State = BattleState.Sart;
    }
}
