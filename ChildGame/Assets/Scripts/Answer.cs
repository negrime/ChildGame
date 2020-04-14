using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    
    private Card _card;



    public void SetCard(Card card)
    {
        _card = card;
        GetComponent<Image>().sprite = _card.Sprite;
    }

    public Card GetCard()
    {
        return _card;
    }
}
