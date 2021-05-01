using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class PrecisionMeasurement : MonoBehaviour, IMixedRealityPointerHandler
{
    [SerializeField] private Transform center;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        foreach (var source in Microsoft.MixedReality.Toolkit.CoreServices.InputSystem.DetectedInputSources)
        {
            // Ignore anything that is not a hand because we want articulated hands
            if (source.SourceType == InputSourceType.Hand)
            {
                // find the pointers of the hand
                foreach (IMixedRealityPointer p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {
                        // Ignore near pointers, we only want the rays
                        continue;
                    }
                    // if the pointer actually gives a result: do something with it
                    if (p.Result != null){
                        float distance = Vector3.Distance(p.Result.Details.Point, center.position);
                        Debug.Log("Distance: " + distance);
                    }

                }
            }
        }
    }
}
