using UnityEngine;

public class GameManagerSave : MonoBehaviour
{
    public static GameManagerSave instance;

    [Header("Player Data")]
    public Vector3 playerPosition;
    public bool hasSavedPosition = false;

    [Header("Progression")]
    public bool introDialogueDone = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPosition(Vector3 pos)
    {
        playerPosition = pos;
        hasSavedPosition = true;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }
}
