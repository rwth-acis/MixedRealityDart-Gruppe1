using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;

public class PrecisionMeasurement : MonoBehaviour, IMixedRealityPointerHandler
{
	[SerializeField] Transform center;
	[SerializeField] GameObject PrefabArrow;

	bool wasShoot = false;

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
		// go over every input source
		foreach (var source in CoreServices.InputSystem.DetectedInputSources)
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
					if (p.Result != null)
					{
						if(!wasShoot)
                        {
							wasShoot = true;
							Vector3 endPos = p.Result.Details.Point;
							float distance = Vector3.Distance(endPos, center.position);
							Debug.Log(distance);
							Instantiate(PrefabArrow, endPos, Quaternion.Euler(-90,0,0), p.Result.Details.Object.transform);
                        }
					}

				}
			}
		}
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


}
