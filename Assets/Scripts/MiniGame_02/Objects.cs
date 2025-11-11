using TMPro;
using UnityEngine;

public class Objects : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sr;
    // private Animator animText;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        anim.SetTrigger("object");
        Destroy(gameObject, 2f);
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyObj"))
        {
            Destroy(gameObject);
        }
    }
}