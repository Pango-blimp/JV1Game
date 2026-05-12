
using UnityEngine;

public class Note : MonoBehaviour
{
    public int lane;
    public NoteType type;

    public AudioClip hitSound;

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

            GameManager.instance.GoodHit();

            AudioManager.instance.PlaySound(hitSound);

            Destroy(gameObject, 0.05f);
        }
        else
        {
            GameManager.instance.WrongInput();
        }
    }

    public void Miss()
    {
        if (isHit) return;

        GameManager.instance.Miss();

        Destroy(gameObject);
    }

    
}
