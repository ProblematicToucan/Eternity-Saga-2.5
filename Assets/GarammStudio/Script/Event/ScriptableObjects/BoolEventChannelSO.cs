using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have one bool argument.
/// </summary>
[CreateAssetMenu(menuName = "GarammStudio/Events/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    [SerializeField] private bool active;
    public UnityAction<bool> OnEventRaised;
    public void RaiseEvent(bool value)
    {
        OnEventRaised?.Invoke(value);
    }

    [ContextMenu("Hit")]
    private void Hit()
    {
        RaiseEvent(active);
    }
}
