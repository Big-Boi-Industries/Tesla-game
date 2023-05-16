using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using static StartMenu;
public class SaveAndLoad : MonoBehaviour
{
    private GameObject Player;
    private GameObject Camera;
    public static PlayerData PlayersData = new PlayerData(); //adds a variable that allows the adding of data to the PlayerDaya catagory
    private bool HasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Continued & !HasRun)
        {
            Load("PlayerData"); //Loads data for the PlayerData catagory if the game is continued
            Player.transform.position = PlayersData.PlayerPosition; //sets the players position to the saved position
            Player.transform.rotation = PlayersData.PlayerRotationHorizontal; //sets the players horizontal rotation to the saved rotation
            Camera.transform.rotation = PlayersData.PlayerRotationVertical; //sets the players vertiacal look rotation to the saved rotation
            HasRun = true;
        }
        if (Running) 
        {
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
    }
    [System.Serializable]
    public struct PlayerData //Creates a cache for all player data
    {
        public Vector3 PlayerPosition; //creates a variable to store the players position
        public Quaternion PlayerRotationHorizontal; //creates a variable to store the players horizontal rotation
        public Quaternion PlayerRotationVertical; //creates a variable to store the players vertical look rotation
    }
}
