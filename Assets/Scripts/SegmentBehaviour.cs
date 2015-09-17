using UnityEngine;
using System.Collections;

public class SegmentBehaviour : MonoBehaviour 
{
	public GameObject NewSegmentToSpawn;
	public float MovementSpeed;
	private GameObject parentObject;
	
	// Update is called once per frame
	void Start ()
	{
		parentObject = GameObject.Find("Floor");
	}
	void FixedUpdate () 
	{
		this.transform.Translate (Vector3.back * MovementSpeed * Time.deltaTime);
		if (this.transform.position.z <= -12)
		{
			GameObject childObject;
			childObject = Instantiate(NewSegmentToSpawn, new Vector3(0, 0, 13), Quaternion.identity) as GameObject;
			childObject.transform.SetParent(parentObject.transform);
			
			Destroy(this.gameObject);
		}
	}
}
