using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static GlobalVariables;

public class RandomSpawnLocations : MonoBehaviour
{
    private GameObject Coil1;
    private GameObject Coil2;
    private GameObject Coil3;
    private GameObject Coil4;
    public static Vector3[] Locations = { new Vector3(-35.25f, 10, 16.5f), new Vector3(-33.75f, 10, 16.5f), new Vector3(-31.75f, 10, 16.5f), new Vector3(-28.5f, 10, 19.25f), new Vector3(-26.5f, 10, 19.25f), new Vector3(-26.5f, 10, 17.75f), new Vector3(-26.5f, 10, 21f), new Vector3(-27.5f, 10, 21f), new Vector3(-35f, 10, 26.75f) };
    private int Number;
    public static int[] Location = { 1, 2, 3, 4 };
    // Start is called before the first frame update
    void Start()
    {
        Coil1 = GameObject.Find("Tesla Coil Base (1)");
        Coil2 = GameObject.Find("Tesla Coil Front Middle (2)");
        Coil3 = GameObject.Find("Tesla Coil Generator (3)");
        Coil4 = GameObject.Find("Tesla Coil Top (4)");
        if (newGame)
        {
                for (int i = 0; i < 4; i++)
            {
                Number = UnityEngine.Random.Range(1, 9);
                if (!Location.Contains(Number)) { Location[i] = Number; }
                else { i = i - 1; }
            }
            Coil1.transform.position = Locations[Location[0]];
            Coil2.transform.position = Locations[Location[1]];
            Coil3.transform.position = Locations[Location[2]];
            Coil4.transform.position = Locations[Location[3]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void respawn(GameObject Piece) 
    {
        if (Piece.name.Contains("1")) { Piece.transform.position = Locations[Location[0]]; }
        if (Piece.name.Contains("2")) { Piece.transform.position = Locations[Location[1]]; }
        if (Piece.name.Contains("3")) { Piece.transform.position = Locations[Location[2]]; }
        if (Piece.name.Contains("4")) { Piece.transform.position = Locations[Location[3]]; }
    }
}
