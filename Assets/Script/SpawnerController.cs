using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<Transform> spawnPoints;
    private List<GameObject> frags = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        
        for(int i = 0; i < 5; i++)
        {
            frags.Add(Instantiate(prefab));
            frags[i].transform.position = spawnPoints[random.Next(0, spawnPoints.Count)].position;
            frags[i].transform.Rotate(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
