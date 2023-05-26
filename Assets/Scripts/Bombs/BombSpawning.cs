using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawning : MonoBehaviour
{
    //8 Locations
    private GameObject Bomb;
    private Vector3[] Locations = { new Vector3(-33.5f, 14, 14), new Vector3(-35.5f, 14, 21), new Vector3(-32, 14, 26.5f), new Vector3(-28, 14, 26.5f), new Vector3(-24, 14, 26.5f), new Vector3(-24, 14, 22.5f), new Vector3(-24, 14, 18.5f), new Vector3(-27.75f, 14, 14.75f) };
    private int SpawnChance = 100; // 1 in every SpwanChance possibility of a bomb of spwaning
    private bool Spawned;
    private int Spawn;
    // Start is called before the first frame update
    void Start()
    {
        Bomb = GameObject.Find("Bomb");
    }

    // Update is called once per frame
    void Update()
    {
        Spawn = Random.Range(0, SpawnChance-1);
        Debug.Log(Spawn);
        if (Spawn == 0) 
        {
            Spawn = Random.Range(0, 7);
            Instantiate(Bomb,Locations[Spawn],new Quaternion(0,0,0,0));
        }
    }
}
