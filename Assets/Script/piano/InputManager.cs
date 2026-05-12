using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform[] lanes;

    public TapLineDetector tapLine;

    public float hitWindow = 0.3f;
    public float punishWindow = 0.6f;

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
        /*if (bestNote != null)
        {
            bestNote.Hit(type);
        }
        else
        {
            GameManager.instance.WrongInput();
        }*/

        /*if (bestNote != null)
        {
            float delta = bestNote.transform.position.y - tapLine.transform.position.y;

            //  note dans la zone de hit
            if (delta >= 0 && delta < 0.5f)
            {
                bestNote.Hit(type);
                return;
            }

            // note proche mais ratée ==> pénalité
            if (delta < 0.7f)
            {
                GameManager.instance.WrongInput();
                return;
            }
        }*/

        if (bestNote != null)
        {
            /*float delta = bestNote.transform.position.y - tapLine.transform.position.y;
            float absDelta = Mathf.Abs(delta);

            
            if (absDelta < hitWindow)
            {
                bestNote.Hit(type);
                return;
            }

            
            if (absDelta > punishWindow)
            {
                GameManager.instance.WrongInput();
                return;
            }*/

            float delta = bestNote.transform.position.y - tapLine.transform.position.y;
            float absDelta = Mathf.Abs(delta);

            if (absDelta < hitWindow)
            {
                bestNote.Hit(type);
            }
            else if (absDelta < punishWindow)
            {
                GameManager.instance.WrongInput();
            }
        }

    }

    Vector2 GetLanePosition(int lane)
    {
        return lanes[lane].position;
    }
}
