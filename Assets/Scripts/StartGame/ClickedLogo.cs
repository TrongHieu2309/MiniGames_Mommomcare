using UnityEngine;

public class ClickedLogo : MonoBehaviour
{
    public static ClickedLogo instance;
    [SerializeField] private Animator animPlatform;
    [SerializeField] private GameObject fade;
    //[SerializeField] private GameObject[] spawnerObj;
    [SerializeField] private Animator animLight;
    [SerializeField] private Animator animSanta;
    [SerializeField] private Animator animLight_01;
    [SerializeField] private GameObject gamePlay;

    private Animator[] anims;

    void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        instance = this;
    }

    void OnMouseDown()
    {
        // foreach (GameObject obj in spawnerObj)
        // {
        //     obj.SetActive(true);
        // }

        gamePlay.SetActive(true);
        fade.SetActive(false);
        Invoke(nameof(Platform), 0.5f);
        animLight.SetTrigger("lighting");
        animSanta.SetTrigger("santaMove");
        animLight_01.SetTrigger("lightMove");

        foreach (Animator anim in anims)
        {
            anim.SetTrigger("hideText");
            anim.SetTrigger("clicked");
            anim.SetTrigger("nameMove");
        }
    }

    private void Platform()
    {
        animPlatform.SetTrigger("platformActive");
    }
}
