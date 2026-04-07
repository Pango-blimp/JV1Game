using UnityEngine;

public class DestroyLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Note note = collision.GetComponent<Note>();
            if (note != null)
            {
                note.Miss();
            }
        }
    }
}
