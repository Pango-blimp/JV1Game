using System.Collections.Generic;
using UnityEngine;

public class TapLineDetector : MonoBehaviour
{
    public List<Note> notesInRange = new List<Note>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Note note = collision.GetComponent<Note>();
            if (note != null)
                notesInRange.Add(note);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Note note = collision.GetComponent<Note>();
            if (note != null)
                notesInRange.Remove(note);
        }
    }
}
