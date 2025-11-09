using TMPro;
using UnityEngine;

public class Objects : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameOfProduct;

    private SpriteRenderer sr;
    private Animator animText;

    void Awake()
    {
        animText = GetComponentInChildren<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        sr.enabled = false;
        nameOfProduct.enabled = true;

        animText.SetTrigger("showBrand");

        Destroy(gameObject, 10f);
    }
}