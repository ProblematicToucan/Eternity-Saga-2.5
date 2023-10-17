using GarammStudio.SO.Core;
using UnityEngine;

/// <summary>
/// Unit Controller:<c>MonoBehaviour</c><br/>
/// Represents a game unit in the battle, with properties to access the unit's data, faction, and status. Provides information about whether the unit is deceased and can participate in the game.
/// </summary>
public class UnitController : MonoBehaviour
{
    [field: SerializeField] public AbstractUnitSO UnitSO { get; private set; }
    [field: SerializeField] public bool IsFoe { get; private set; }
    public bool IsDead => UnitSO.CurrentHealth <= 0;
    public bool IsUnitCanPlay => !IsDead;
}
