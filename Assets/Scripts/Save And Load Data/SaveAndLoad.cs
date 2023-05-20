using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using static StartMenu;
using static BuildTeslaCoil;
public class SaveAndLoad : MonoBehaviour
{
    private GameObject Player;
    private GameObject Coil1;
    private GameObject Coil2;
    private GameObject Coil3;
    private GameObject Coil4;
    private GameObject Camera;
    public static PlayerData PlayersData = new PlayerData(); //adds a variable that allows the adding of data to the PlayerDaya catagory
    public static CoilData CoilsData = new CoilData();
    private bool HasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Coil1 = GameObject.Find("Tesla Coil Base (1)");
        Coil2 = GameObject.Find("Tesla Coil Front Middle (2)");
        Coil3 = GameObject.Find("Tesla Coil Generator (3)");
        Coil4 = GameObject.Find("Tesla Coil Top (4)");
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Continued & !HasRun)
        {
            Load("CoilData");
            Placed1 = CoilsData.Placed1;
            Placed2 = CoilsData.Placed2;
            Placed3 = CoilsData.Placed3;
            Placed4 = CoilsData.Placed4;
            Coil1.transform.position = CoilsData.Location1;
            Coil2.transform.position = CoilsData.Location2;
            Coil3.transform.position = CoilsData.Location3;
            Coil4.transform.position = CoilsData.Location4;
            Load("PlayerData"); //Loads data for the PlayerData catagory if the game is continued
            Player.transform.position = PlayersData.PlayerPosition; //sets the players position to the saved position
            Player.transform.rotation = PlayersData.PlayerRotationHorizontal; //sets the players horizontal rotation to the saved rotation
            Camera.transform.rotation = PlayersData.PlayerRotationVertical; //sets the players vertiacal look rotation to the saved rotation
            HasRun = true;
        }
        if (Running) 
        {
            CoilsData.Placed1 = Placed1;
            CoilsData.Placed2 = Placed2;
            CoilsData.Placed3 = Placed3;
            CoilsData.Placed4 = Placed4;
            CoilsData.Location1 = Coil1.transform.position; //saves the position of the first coil part to a temp variable
            CoilsData.Location2 = Coil2.transform.position; //saves the position of the second coil part to a temp variable
            CoilsData.Location3 = Coil3.transform.position; //saves the position of the third coil part to a temp variable
            CoilsData.Location4 = Coil4.transform.position;
            Save("CoilData");
            PlayersData.PlayerPosition = Player.transform.position; //saves the players position to the PlayerData save cache every update
            PlayersData.PlayerRotationHorizontal = Player.transform.rotation; //saves the players horizontal rotation to the PlayerData save cache every update
            PlayersData.PlayerRotationVertical = Camera.transform.rotation; //saves the players vertical look rotation to the PlayerData save cache every update
            Save("PlayerData"); //Saves the data in the PlayerData cache to the drive
        }
    }
    public void Save(string DataType) //takes a string of the desired cache to save
    {
        if (!File.Exists("Assets\\Data\\" + DataType + ".txt")) //checks if a file for the cache dosn't exists
        {
            File.Create("Assets\\Data\\" + DataType + ".txt"); //creates a file for the cache
        }
        if (DataType == "PlayerData") //checks if the cache wanted to be saved is PlayerData
        {
            string Data = JsonUtility.ToJson(PlayersData, true); //Changes the cache into a json string
            File.WriteAllText("Assets\\Data\\" + DataType + ".txt", Data); //Writes the json string the designated file
        }
        if (DataType == "CoilData") 
        {
            string Data = JsonUtility.ToJson(CoilsData, true); //Changes the cache into a json string
            File.WriteAllText("Assets\\Data\\" + DataType + ".txt", Data); //Writes the json string the designated file
        }
    }
    public void Load(string DataType) //takes a string of the desired cache to load
    {
        if (DataType == "PlayerData") //checks if the cache wanted to be loaded is PlayerData
        {
            PlayerData PlayerData = new PlayerData(); //creates a variable that can access the PlayerData cache
            if (File.Exists("Assets\\Data\\" + DataType + ".txt"))  //Checks if the file for the cache exists
            {
                string Data = File.ReadAllText("Assets\\Data\\" + DataType + ".txt"); //reads the json data in the file
                PlayerData = JsonUtility.FromJson<PlayerData>(Data); //converts the json data to struct data for the PlayerData struct
            }
            PlayersData = PlayerData; //Writes the players data to the PlayerData cache
        }
        if (DataType == "CoilData") //checks if the cache wanted to be loaded is CoilData
        {
            CoilData CoilData = new CoilData(); //creates a variable that can access the CoilData cache
            if (File.Exists("Assets\\Data\\" + DataType + ".txt"))  //Checks if the file for the cache exists
            {
                string Data = File.ReadAllText("Assets\\Data\\" + DataType + ".txt"); //reads the json data in the file
                CoilData = JsonUtility.FromJson<CoilData>(Data); //converts the json data to struct data for the CoilData struct
            }
            CoilsData = CoilData; //Writes the players data to the CoilData cache
        }
    }
    [System.Serializable]
    public struct PlayerData //Creates a cache for all player data
    {
        public Vector3 PlayerPosition; //creates a variable to store the players position
        public Quaternion PlayerRotationHorizontal; //creates a variable to store the players horizontal rotation
        public Quaternion PlayerRotationVertical; //creates a variable to store the players vertical look rotation
    }
    public struct CoilData
    {
        public Vector3 Location1;
        public bool Placed1;
        public Vector3 Location2;
        public bool Placed2;
        public Vector3 Location3;
        public bool Placed3;
        public Vector3 Location4;
        public bool Placed4;
    }
}
