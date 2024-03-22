using UnityEngine;

namespace GarammStudio.Core
{
    public abstract class AbstractUnitSO : ScriptableObject
    {
        [Header("Details(0)")]
        public string UnitName;
        public int Health;
        public int CurrentHealth;
    }
}
