using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        if (GameManagerSave.instance != null && GameManagerSave.instance.hasSavedPosition)
        {
            transform.position = GameManagerSave.instance.GetPlayerPosition();
        }
    }
}
