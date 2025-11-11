using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Mini Game 01")]
    [SerializeField] private GameObject prefabsCard;
    [SerializeField] private Transform gridParent;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Image productImage;
    [SerializeField] private Animator productAnim;
    [SerializeField] private Animator cardGridAnim;

    [Header("Mini Game 02")]
    [SerializeField] private Animator platformGame02Anim;
    [SerializeField] private Animator bowTieAnim;
    [SerializeField] private Animator ribbonAnim;
    [SerializeField] private Animator ribbon01Anim;
    [SerializeField] private GameObject spawnerPosition;


    private Card firstCard;
    private Card secondCard;
    public float quantityOfCard = 0;
    private List<Card> cards = new List<Card>();

    void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        SetupCards();
        productImage.enabled = false;
    }

    private void SetupCards()
    {
        List<Sprite> selectedImages = new List<Sprite>();

        foreach (var i in images)
        {
            selectedImages.Add(i);
        }

        // // add id for image
        // for (int i = 0; i < selectedImages.Count; i++)
        // {
        //     GameObject cardObj = Instantiate(prefabsCard, gridParent);
        //     Card card = cardObj.GetComponent<Card>();
        //     card.Setup(i, selectedImages[i], this);
        // }

        // duplicate selectedImages
        List<Sprite> allSprites = new List<Sprite>(selectedImages);
        allSprites.AddRange(selectedImages);

        // mixing
        for (int i = 0; i < allSprites.Count; i++)
        {
            Sprite temp = allSprites[i];
            int randIndex = Random.Range(0, allSprites.Count);
            allSprites[i] = allSprites[randIndex];
            allSprites[randIndex] = temp;
        }
        
        // add to grid
        // build a map from sprite to its id (index in selectedImages)
        Dictionary<Sprite, int> spriteToId = new Dictionary<Sprite, int>();
        for (int i = 0; i < selectedImages.Count; i++)
        {
            if (!spriteToId.ContainsKey(selectedImages[i]))
                spriteToId[selectedImages[i]] = i;
        }

        // instantiate cards based on shuffled allSprites and assign the original id
        for (int i = 0; i < allSprites.Count; i++)
        {
            GameObject cardObj = Instantiate(prefabsCard, gridParent);
            Card card = cardObj.GetComponent<Card>();
            int id = spriteToId[allSprites[i]];
            card.Setup(id, allSprites[i], this);
            cards.Add(card);
        }

        // // add to grid
        // for (int i = 0; i < allSprites.Count; i++)
        // {
        //     GameObject cardObj = Instantiate(prefabsCard, gridParent);
        //     Card card = cardObj.GetComponent<Card>();
        //     card.Setup(i / 2, allSprites[i], this);
        //     cards.Add(card);
        // }
    }

    public void OnCardRevealed(Card card)
    {
        if (firstCard == null) firstCard = card;
        else
        {
            secondCard = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1f);

        if (firstCard.id == secondCard.id)
        {
            productImage.enabled = true;
            productImage.sprite = firstCard.frontImage.sprite;
            productAnim.SetTrigger("showProduct");

            firstCard.DisableCard();
            secondCard.DisableCard();
        }
        else
        {
            firstCard.Hide();
            secondCard.Hide();
        }
        quantityOfCard = 0;

        firstCard = secondCard = null;

        if (AllCardMatched())
        {
            cardGridAnim.SetTrigger("winGame01");

            // Mini game 02
            platformGame02Anim.SetTrigger("start");
            ribbonAnim.SetTrigger("ribbonStart");
            ribbon01Anim.SetTrigger("ribbon01Start");
            bowTieAnim.SetTrigger("bowTieStart");
            spawnerPosition.SetActive(true);
        }
    }

    private bool AllCardMatched()
    {
        foreach (var card in cards)
        {
            if (card.GetComponent<Button>().interactable) return false;
        }
        return true;
    }
}