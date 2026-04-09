using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToScene : MonoBehaviour
{
    public string sceneToLoad; 
    public KeyCode keyToPress = KeyCode.Escape; 

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}