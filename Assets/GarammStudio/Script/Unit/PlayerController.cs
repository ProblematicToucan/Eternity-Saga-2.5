using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GarammStudio.Unit
{
    public class PlayerController : UnitController
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private NavMeshAgent _agent;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    _agent.SetDestination(hit.point);
                }
            }
        }
    }
}
