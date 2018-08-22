using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject entityPrefab;
	public float delay;
	Delay delayScript;
	void OnEnable()
	{
		if(delayScript == null)
			delayScript = new Delay(delay);
		delayScript.Start(delay);
	}	
	void Update () 
	{
		if(delayScript.Check())
		{
			GameObject entity = ObjectPoolManager.GetObjectPool(entityPrefab).PopItem();
			entity.transform.position = gameObject.transform.position;
			delayScript.Start(delay);
		}
	}
}
