using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// To use a generic UnityEvent type you must override the generic type.
/// </summary>
[Serializable]
public class IntEvent : UnityEvent<int>
{

}

/// <summary>
/// A flexible handler for int events in the form of a MonoBehaviour. Responses can be connected directly from the Unity Inspector.
/// </summary>
public class IntEventListener : MonoBehaviour
{
    [SerializeField] private IntEventChannelSO _chanel = default;
    public IntEvent OnEventRaised;

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

    private void Respond(int value)
    {
        OnEventRaised?.Invoke(value);
    }
}
