using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance { get; private set; }
    private GameData gameData;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than 1 DPM in this scene");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("Null data");
            this.gameData = new GameData();
        }    
    }
    public void SaveGame()
    {

    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }
}
