using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StartMenu;

public class BombSpawning : MonoBehaviour
{
    //8 Locations
    private GameObject Bomb;
    private Vector3[] Locations = { new Vector3(-33.5f, 14, 14), new Vector3(-35.5f, 14, 21), new Vector3(-32, 14, 26.5f), new Vector3(-35.5f, 14, 21), new Vector3(-28, 14, 26.5f), new Vector3(-24, 14, 26.5f), new Vector3(-35.5f, 14, 21), new Vector3(-24, 14, 22.5f), new Vector3(-24, 14, 18.5f), new Vector3(-35.5f, 14, 21), new Vector3(-27.75f, 14, 14.75f) };
    public int SpawnChance = 200; // 1 in every SpwanChance possibility of a bomb of spwaning
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
        if (Running)
        {
            Spawn = Random.Range(1, SpawnChance);
            if (Spawn == 1)
            {
                Spawn = Random.Range(0, 10);
                Instantiate(Bomb, Locations[Spawn], new Quaternion(0, 0.7071f, 0, 0.7071f));
            }
        }
    }
}
