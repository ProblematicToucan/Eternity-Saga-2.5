using UnityEngine;

namespace GarammStudio.SO.Core
{
    public abstract class AbstractUnitSO : ScriptableObject
    {
        [Header("Details(0)")]
        public string UnitName;
        public int Health;
        public int CurrentHealth;
    }
}
