using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour 
{
    void OnSwipeLeft()
    {
        this.transform.Translate(Vector3.left);
    }
    void OnSwipeRight()
    {
        this.transform.Translate(Vector3.right);
    }
    void OnSwipeUp()
    {
        this.transform.Translate(Vector3.up);
    }
    void OnSwipeDown()
    {
        this.transform.Rotate(new Vector3(90, 0, 0));
    }
}
