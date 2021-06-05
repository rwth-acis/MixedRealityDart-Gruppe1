using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] SolverHandler solver;

    public void ToggleSnapping()
    {
        Debug.Log("Toggle");
        solver.enabled = !solver.enabled;
    }
}
