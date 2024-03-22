using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments (Example: Exit game event)
/// </summary>

[CreateAssetMenu(menuName = "GarammStudio/Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;
    [ContextMenu("Raise Event")]
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
