using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Battle system:<c>MonoBehaviour</c><br/>
/// Manages a turn-based battle system in a game. This class controls the flow of turns between allies and enemies, tracks game states, and handles unit readiness and completion of turns. It also includes a method to check if all units in a provided list are deceased.
/// </summary>
public class BattleSystem : MonoBehaviour
{
    public enum BattleState
    {
        START,
        ALLIES_TURN,
        ENEMIES_TURN,
        WIN,
        LOST
    }

    [NonSerialized] public BattleState State;
    private List<UnitController> _alliesCanPlay;
    private List<UnitController> _enemiesCanPlay;
    [SerializeField] private List<UnitController> _allies;
    [SerializeField] private List<UnitController> _enemies;

    [ContextMenu("Allies Turn")]
    private void AlliesTurn()
    {
        if (_alliesCanPlay.Count <= 0) return;
        Debug.Log($"{_alliesCanPlay[0].name} run their turn!");
        UnitFinishedTurn(_alliesCanPlay[0]);
    }

    [ContextMenu("Enemies Turn")]
    private void EnemiesTurn()
    {
        if (_enemiesCanPlay.Count <= 0) return;
        Debug.Log($"{_enemiesCanPlay[0].name} run their turn!");
        UnitFinishedTurn(_enemiesCanPlay[0]);
    }

    void Start()
    {
        State = BattleState.START;
        _alliesCanPlay = new();
        _enemiesCanPlay = new();
        StartCoroutine(PostStart());
    }

    private IEnumerator PostStart()
    {
        yield return new WaitForEndOfFrame();
        StartAlliesTurn();
    }

    /// <summary>
    /// Initiates the start of the allies' turn in the battle, sets the game state, and prepares all ally units for their turn.
    /// </summary>
    private void StartAlliesTurn()
    {
        Debug.Log("Allies' turn!");
        State = BattleState.ALLIES_TURN;
        foreach (var unit in _allies)
        {
            SetUnitReadiness(unit);
        }
    }

    /// <summary>
    /// Initiates the start of the enemies' turn in the battle, sets the game state, and prepares all enemy units for their turn.
    /// </summary>
    private void StartEnemiesTurn()
    {
        Debug.Log("Enemies' turn!");
        State = BattleState.ENEMIES_TURN;
        foreach (var unit in _enemies)
        {
            SetUnitReadiness(unit);
        }
    }

    /// <summary>
    /// Sets the readiness of a unit for its turn in the battle. Adds the unit to the list of units that can play based on its faction (ally or enemy).
    /// </summary>
    /// <param name="unit">The unit for which readiness is being set.</param>
    private void SetUnitReadiness(UnitController unit)
    {
        if (!unit.IsUnitCanPlay) return;
        if (unit.IsFoe)
        {
            _enemiesCanPlay.Add(unit);
        }
        else
        {
            _alliesCanPlay.Add(unit);
        }
    }

    /// <summary>
    /// Handles the completion of a unit's turn, including logging the unit's name, managing turn-based gameplay for both allies and foes, and checking for victory conditions.
    /// </summary>
    /// <param name="unit">The unit that has finished its turn.</param>
    private void UnitFinishedTurn(UnitController unit)
    {
        Debug.Log($"{unit.name} finished their turn!");
        if (unit.IsFoe)
        {
            _enemiesCanPlay.Remove(unit);
            if (AreAllUnitsIsDead(_enemies))
            {
                // Do something if all enemies dead. i.e Win pop out
                Debug.Log("Won");
            }

            if (_enemiesCanPlay.Count <= 0)
            {
                StartAlliesTurn();
            }
            else
            {
                Debug.Log(_enemiesCanPlay[0].name);
            }
        }
        else
        {
            _alliesCanPlay.Remove(unit);
            if (AreAllUnitsIsDead(_enemies))
            {
                // Do something if all enemies dead. i.e Win pop out
                Debug.Log("Won");
            }

            if (_alliesCanPlay.Count <= 0)
            {
                StartEnemiesTurn();
            }
            else
            {
                Debug.Log(_alliesCanPlay[0].name);
            }
        }
    }

    /// <summary>
    /// Checks if all units in the provided list are deceased.
    /// </summary>
    /// <param name="units">A list of <see cref="UnitController"/> objects to be checked.</param>
    /// <returns>Returns true if all units are dead; otherwise, returns false.</returns>
    private bool AreAllUnitsIsDead(List<UnitController> units)
    {
        for (int i = units.Count - 1; i >= 0; i--)
        {
            if (!units[i].IsDead)
            {
                return false;
            }
        }
        return true;
    }
}
