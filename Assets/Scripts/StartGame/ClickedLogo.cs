using UnityEngine;

public class ClickedLogo : MonoBehaviour
{
    public static ClickedLogo instance;
    [SerializeField] private GameObject fade;
    [SerializeField] private Animator animLight;
    [SerializeField] private Animator animSanta;
    [SerializeField] private Animator animLight_01;
    [SerializeField] private GameObject cardGrid;

    private Animator[] anims;

    void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        instance = this;
    }

    void OnMouseDown()
    {
        cardGrid.SetActive(true);
        fade.SetActive(false);
        animLight.SetTrigger("lighting");
        animSanta.SetTrigger("santaMove");
        animLight_01.SetTrigger("lightMove");

        foreach (Animator anim in anims)
        {
            anim.SetTrigger("hideText");
            anim.SetTrigger("clicked");
            anim.SetTrigger("nameMove");
            anim.SetTrigger("");
        }
    }
}
