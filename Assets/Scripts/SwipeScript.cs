using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour 
{
    private Vector3 destinationPos;
    void Start()
    {
        destinationPos = this.transform.position;
    }
    void OnSwipeLeft()
    {
        destinationPos = new Vector3(this.transform.position.x - 1, this.transform.position.y, -9);
    }
    void OnSwipeRight()
    {
        destinationPos = new Vector3(this.transform.position.x + 1, this.transform.position.y, -9);
    }
    void OnSwipeUp()
    {
        destinationPos = new Vector3(this.transform.position.x, this.transform.position.y+1, -9);
    }
    void OnSwipeDown()
    {
        print("Initiate ducking");
    }

    void Update()
    {
        //float distCovered = (Time.time - startTime) * speed;
        //float fracJourney = distCovered / journeyLength;
        //transform.position = Vector3.Lerp(startTransform.position, endTransform.position, fracJourney);
        if (this.transform.position != destinationPos)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPos, 5.0f * Time.deltaTime);
        }
        if (this.transform.position.y == 2)
        {
            destinationPos = new Vector3(this.transform.position.x, this.transform.position.y - 1, -9);
        }
    }

    //Vector3 MoveLane(int pos)
    //{
    //    //endTransform.position = new Vector3(startTransform.position.x + pos, startTransform.position.y, startTransform.position.z);
    //    //journeyLength = Vector3.Distance(startTransform.position, endTransform.position);
    //    return new Vector3(pos, 0, 0);
    // }
}
