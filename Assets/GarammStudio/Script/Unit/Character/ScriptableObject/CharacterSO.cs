using GarammStudio.SO.Core;
using UnityEngine;

public enum CharacterType
{
    Player,
    Ally,
    Enemy
}

[CreateAssetMenu(fileName = "New Character", menuName = "GarammStudio/Unit/Character")]
public class CharacterSO : AbstractUnitSO
{
    [Header("Details(1)")]
    public CharacterType CharacterType;
    public int Level;
    public int Damage;
}
