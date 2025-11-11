using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    public static Product instance;
    [SerializeField] private Image productImage;
    public bool isDisable = false;

    void Awake()
    {
        instance = this;
        isDisable = false;
    }

    public void DisableProduct()
    {
        productImage.enabled = false;
    }

    public void DisableAll()
    {
        isDisable = true;
    }
    public void EnableAll()
    {
        isDisable = false;
    }
}