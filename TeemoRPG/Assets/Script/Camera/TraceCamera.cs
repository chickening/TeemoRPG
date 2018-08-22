using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceCamera : MonoBehaviour {

	// Use this for initialization'
	[Range(0,10)]
	public float cameraSpeed;
	Transform targetTransform;
	Transform mainCameraTransform;
	void OnEnable()
	{
		if(targetTransform == null)
			targetTransform = transform;
		if(mainCameraTransform == null)
			mainCameraTransform = Camera.main.transform;
	} 
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 newCameraPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, mainCameraTransform.position.z);
		newCameraPosition = Vector3.Lerp(mainCameraTransform.position, newCameraPosition, cameraSpeed * Time.deltaTime);
		mainCameraTransform.position = newCameraPosition;
	}
	void UpdateUI()
	{
		if(UIManager.instance != null)
		{

		}
	}
}
