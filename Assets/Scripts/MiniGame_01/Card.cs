using UnityEngine;
using UnityEngine.UI;

// Mini game 01
public class Card : MonoBehaviour
{
    public int id;
    [SerializeField] public Image frontImage;
    [SerializeField] private Image backImage;
    public bool isRevealed = false;
    private GameManager gameManager;

    public void Setup(int id, Sprite frontSprite, GameManager gameManager)
    {
        this.id = id;
        frontImage.sprite = frontSprite;
        this.gameManager = gameManager;
    }

    public void OnCardClicked()
    {
        if (isRevealed) return;
        if (GameManager.instance.quantityOfCard < 2 && Product.instance.isDisable == false)
        {
            Reveal();
            gameManager.OnCardRevealed(this);
        }
        else if (GameManager.instance.quantityOfCard == 2) isRevealed = false;
    }

    // Reveal = Show
    public void Reveal()
    {
        frontImage.gameObject.SetActive(true);
        backImage.gameObject.SetActive(false);
        GameManager.instance.quantityOfCard++;
        isRevealed = true;
    }

    public void Hide()
    {
        frontImage.gameObject.SetActive(false);
        backImage.gameObject.SetActive(true);
        isRevealed = false;
    }

    public void DisableCard()
    {
        GetComponent<Button>().interactable = false;
    }
}