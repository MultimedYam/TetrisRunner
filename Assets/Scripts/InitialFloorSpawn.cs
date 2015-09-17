using UnityEngine;
using System.Collections;

public class InitialFloorSpawn : MonoBehaviour {

	public GameObject objectToLoad;

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i <= 25; i++)
		{
			GameObject childObject;
			childObject = Instantiate(objectToLoad, new Vector3(0, 0, -10 + i), Quaternion.identity) as GameObject;
			childObject.transform.SetParent(this.transform);
		}
	}
}
