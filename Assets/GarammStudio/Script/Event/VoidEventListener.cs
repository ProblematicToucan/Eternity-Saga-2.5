using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A flexible handler for void events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _chanel = default;
    public UnityEvent OnEventRaised;

    private void OnEnable()
    {
        if (_chanel != null)
        {
            _chanel.OnEventRaised += Respond;
        }
    }

    private void OnDisable()
    {
        if (_chanel != null)
        {
            _chanel.OnEventRaised -= Respond;
        }
    }

    private void Respond()
    {
        OnEventRaised?.Invoke();
    }
}
