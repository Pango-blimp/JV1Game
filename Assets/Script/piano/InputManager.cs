using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform[] lanes;

    public TapLineDetector tapLine;


    public KeyCode[] laneKeys = { KeyCode.A, KeyCode.S, KeyCode.F, KeyCode.G };

    private void Update()
    {
        for (int i = 0; i < laneKeys.Length; i++)
        {
            if (Input.GetKeyDown(laneKeys[i]))
            {
                NoteType type = GetInputType();
                CheckHit(i, type);

            }
        }
    }

    NoteType GetInputType()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
            return NoteType.Minor;

        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            return NoteType.Major;

        return NoteType.Neutral;
    }

    void CheckHit(int lane, NoteType type)
    {

        Note bestNote = null;
        float bestDistance = Mathf.Infinity;

        foreach (var note in tapLine.notesInRange)
        {
            if (note.lane == lane)
            {
                float dist = Mathf.Abs(note.transform.position.y - tapLine.transform.position.y);

                if (dist < bestDistance)
                {
                    bestDistance = dist;
                    bestNote = note;
                }
            }
        }
        if (bestNote != null)
        {
            bestNote.Hit(type);
        }
        else
        {
            Debug.Log("Miss");
        }
            
    }

    Vector2 GetLanePosition(int lane)
    {
        return lanes[lane].position;
    }
}
