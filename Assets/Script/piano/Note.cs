using UnityEngine;

public class Note : MonoBehaviour
{
    public int lane;
    public NoteType type;

    public void Hit(NoteType inputType)
    {
        if (inputType == type) 
        {
            Debug.Log("Good Hit");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Wrong Type");
        }
    }
}
