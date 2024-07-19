using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace GarammStudio.Core
{
    public class InputHandlerSO : ScriptableObject, InputControls.IAdventureActions
    {
        public UnityAction MoveEvent = delegate { };
        public UnityAction InspectEvent = delegate { };
        private InputControls controls;

        private void OnEnable()
        {
            if (controls == null)
            {
                controls = new InputControls();
                controls.Adventure.SetCallbacks(this);
            }
            EnableAdventureInput();
        }

        private void OnDisable()
        {
            DisableAdventureInput();
        }

        private void EnableAdventureInput()
        {
            controls.Adventure.Enable();
        }

        private void DisableAdventureInput()
        {
            controls.Adventure.Disable();
        }

        public void OnInspect(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
