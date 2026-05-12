using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform[] lanes;

    public TapLineDetector tapLine;

    public float punishY = 5f;

    public KeyCode[] laneKeys = { KeyCode.Q, KeyCode.S, KeyCode.M, KeyCode.Alpha5 };

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
        if (Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.Space))
            return NoteType.Minor;

        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.LeftAlt))
            return NoteType.Major;

        return NoteType.Neutral;
    }

    /*void CheckHit(int lane, NoteType type)
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
            float noteY = bestNote.transform.position.y;
            if (Mathf.Abs(noteY - tapLine.transform.position.y) < 1f)
            {
                bestNote.Hit(type);
                return;
            }
            if (noteY <= punishY)
            {
                GameManager.instance.WrongInput();
                return;
            }
        }


    }*/

    Note GetNextNoteInLane(int lane)
    {
        Note closest = null;

        foreach (var note in Note.activeNotes)
        {
            if (note.lane != lane) continue;

            if (closest == null || note.transform.position.y < closest.transform.position.y)
            {
                closest = note;
            }
        }

        return closest;
    }

    void CheckHit(int lane, NoteType type)
    {
        var notes = tapLine.notesInRange;

        Note noteToHit = null;

        //  chercher une note dans la bonne lane
        foreach (var note in notes)
        {
            if (note.lane == lane)
            {
                noteToHit = note;
                break;
            }
        }

        //  HIT si une note est dans la TapLine
        if (noteToHit != null)
        {
            noteToHit.Hit(type);
            return;
        }

        //  sinon  gérer le spam intelligemment
        HandleSpam(lane);
    }

    void HandleSpam(int lane)
    {
        Note nextNote = GetNextNoteInLane(lane);

        if (nextNote == null)
            return; // aucune note  spam autorisé

        float noteY = nextNote.transform.position.y;

        if (noteY <= punishY)
        {
            GameManager.instance.WrongInput();
        }
    }
    Vector2 GetLanePosition(int lane)
    {
        return lanes[lane].position;
    }
}
