using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.transform.Rotate(Vector3.right, 50.0f * Time.deltaTime);
	}

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Destroy(this.transform);
        }
    }
}
