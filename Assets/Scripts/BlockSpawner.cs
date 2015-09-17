using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BlockSpawner : MonoBehaviour 
{
    public enum SpawnFrequency { Slow, Normal, Fast };
    [SerializeField]
    public List<GameObject> TetrisBlocks = new List<GameObject>();
    public List<Vector3> BlockSpawns = new List<Vector3>();
    [SerializeField]
    public SpawnFrequency BlockSpawnFrequency;

    private float timer = 0;
    private float timeInterval;
    private GameObject parent;

	// Use this for initialization
	void Start () 
    {
        parent = GameObject.Find("SpawnedBlocks");

	    switch (BlockSpawnFrequency)
        {
            case SpawnFrequency.Slow:
                {
                    timeInterval = 5.75f;
                    break;
                }
            case SpawnFrequency.Normal:
                {
                    timeInterval = 4f;
                    break;
                }
            case SpawnFrequency.Fast:
                {
                    timeInterval = 3.5f;
                    break;
                }
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            GameObject _object = Instantiate(TetrisBlocks[Random.Range(0, TetrisBlocks.Count)], BlockSpawns[Random.Range(0, 4)], Quaternion.identity) as GameObject;
            _object.transform.SetParent(parent.transform);
            _object = Instantiate(TetrisBlocks[Random.Range(0, TetrisBlocks.Count)], BlockSpawns[Random.Range(0, 4)], Quaternion.identity) as GameObject;
            _object.transform.SetParent(parent.transform);

            // reset timer
            timer = 0;
        }
    }
}
