using UnityEngine;

public class MapManager : MonoBehaviour
{

    public enum GameState
    {
        Loading,
        Playing,
        GameOver
    }

    public MapGenerator mapGenerator;

    public static GameState state;

    public static GameSettings gameSettings { get; set;}

    public static MapManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            UnityEngine.Object.Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameSettings == null) 
        {
            gameSettings = new GameSettings(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getSeed()
    {
        return gameSettings.seed;
    }

}
