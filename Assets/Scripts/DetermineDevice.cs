using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class DetermineDevice : MonoBehaviour
{
    public bool isHololens;

    private void Awake()
    {
        isHololens = !HolographicSettings.IsDisplayOpaque;
    }
}
