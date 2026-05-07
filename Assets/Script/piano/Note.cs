
using UnityEngine;

public class Note : MonoBehaviour
{
    public int lane;
    public NoteType type;

    private bool isHit = false;

    private Rigidbody2D rb;

    public float SpeedCoeff = 1.0f;
    public float Speed;

    void Start()
    {
        rb.linearVelocity = new Vector2(0,rb.linearVelocity.y-Speed);
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Hit(NoteType inputType)
    {
        if (isHit) return;

        if (inputType == type) 
        {
            isHit = true;
            Debug.Log("Good Hit");
            GetComponent<SpriteRenderer>().color = Color.green;
            Destroy(gameObject, 0.05f);
        }
        else
        {
            Debug.Log("Wrong Type");
        }
    }

    public void Miss()
    {
        if (isHit) return;

        Debug.Log("MISS");

        Destroy(gameObject);
    }

    
}
