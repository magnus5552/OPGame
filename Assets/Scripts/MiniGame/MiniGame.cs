using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    [SerializeField] 
    public Sprite CardBack;

    [SerializeField] 
    public double FlipTime;
    
    private HashSet<Card> _cards;
    private Card _currentCard;
    // Start is called before the first frame update
    public void Start()
    {
        _currentCard = null;
        var sprites = transform.Cast<Transform>().Select(t => t.gameObject.GetComponent<Image>().sprite).ToList();
        Shuffle(sprites);

        _cards = transform
            .Cast<Transform>()
            .Select((t, i) =>
            {
                t.gameObject.GetComponent<Image>().sprite = sprites[i];
                var card = t.gameObject.AddComponent<Card>();
                card.gameField = this;
                card.BackImage = CardBack;
                card.FlipTime = FlipTime;
                
                return card;
            })
            .ToHashSet();
    }
    
    public static void Shuffle<T>(IList<T> list)
    {
        var rng = new System.Random();
        var n = list.Count;  
        while (n > 1) {  
            n--;  
            var k = rng.Next(n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }

    public void ClickOnCard(Card card)
    {
        if (!_cards.Contains(card))
            return;
        
        if (_currentCard == null)
        {
            _currentCard = card;
            return;
        }

        if (_currentCard.ImageName == card.ImageName && _currentCard != card)
        {
            _currentCard.OnCardMatch();
            card.OnCardMatch();
            
            _cards.Remove(_currentCard);
            _cards.Remove(card);
        }
        else
        {
            _currentCard.OnCardNotMatch();
            card.OnCardNotMatch();
        }

        _currentCard = null;
    }
}
