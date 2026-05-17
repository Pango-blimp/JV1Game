using UnityEngine;
using UnityEngine.UI;

public class NoteSlot : MonoBehaviour
{
    public bool isFilled = false;
    public Image noteImage;

    public void OnClick()
    {
        if (!isFilled)
        {
            FillNote();
        }
    }

    public void FillNote()
    {
        isFilled = true;
        noteImage.enabled = true;
    }
}