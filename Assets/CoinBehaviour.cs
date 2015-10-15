using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour 
{
    public float MovementSpeed;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //this.transform.Translate(Vector3.down * MovementSpeed * Time.deltaTime);
        this.transform.Rotate(Vector3.right, 20.0f * Time.deltaTime);
	}

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Destroy(this.transform);
        }
    }
}
