using UnityEngine;

public class ShowBrandName : MonoBehaviour
{
    [SerializeField] private float fadeDuration;

    private SpriteRenderer sr;
    private float timer;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sr.color.a > 0f)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(sr.color.a, 0f, timer / fadeDuration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        }
    }
}
