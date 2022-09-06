
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampIconsMinimap : MonoBehaviour
{

	public Transform MinimapCam;
	public float MinimapSize;
	Vector3 TempV3;

	void Update()
	{
		TempV3 = transform.parent.transform.position;
		TempV3.y = transform.position.y;
		transform.position = TempV3;
	}

	void LateUpdate()
	{
		Vector3 centerPosition = MinimapCam.transform.localPosition;
		centerPosition.y -= 0.5f;
		float Distance = Vector3.Distance(transform.position, centerPosition);
		if (Distance > MinimapSize)
		{
			// Gameobject - Minimap
			Vector3 fromOriginToObject = transform.position - centerPosition;

			// Multiply by MinimapSize and Divide by Distance
			fromOriginToObject *= MinimapSize / Distance;

			// Minimap + above calculation
			transform.position = centerPosition + fromOriginToObject;
		}
	}
}