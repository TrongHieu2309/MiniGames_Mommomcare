using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int id;
    [SerializeField] private Image frontImage;
    [SerializeField] private Image backImage;
    private bool isRevealed = false;
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
        if (GameManager.instance.quantityOfCard < 2)
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