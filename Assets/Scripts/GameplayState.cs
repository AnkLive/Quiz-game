using UnityEngine;
using UnityEngine.UI;

public class GameplayState : MonoBehaviour
{
    [SerializeField] private Card[] _cards;
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _score = 0;

    private Card _firstCard, _secondCard;

    private int[] _cardTypes = { 0, 0, 1, 1, 2, 2, 3, 3 };

    
    private void Start() 
    {
        SetScoreText(_score);
        ShuffleCards();
        
    }

    private void ShuffleCards()
    {
        System.Random random = new  System.Random();

        for (int i = _cardTypes.Length - 1; i >= 1; i--)
        {
            int j = random.Next(i + 1);

            int temp = _cardTypes[j];
            _cardTypes[j] = _cardTypes[i];
            _cardTypes[i] = temp;
        }
        SetCardTypes();
    }

    private void SetCardTypes()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            _cards[i].CardType = _cardTypes[i];
        }
    }

    private void SetScoreText(int score) => _scoreText.text = $"—чет: {score}";

    private void MatchCheck() 
    {
        SetScoreText(_firstCard.CardType == _secondCard.CardType ? ++_score : --_score);
        if(_firstCard.CardType == _secondCard.CardType)
        {
            ResetCards();
        }
    }

    private void ResetCards() 
    {
        _firstCard = null;
        _secondCard = null;
    }
    
    public void OnRestardClicked() 
    {
        foreach (var card in _cards)
        {
            card.SetDefaultImage();
        }
        ShuffleCards();
    }

    public void Guess(Card card)
    {
        if(_firstCard == null)
        {
            _firstCard = card;
        }
        else if(_secondCard == null) 
        {
            _secondCard = card;
            MatchCheck();
        }
        else
        {
            _firstCard.SetDefaultImage();
            _secondCard.SetDefaultImage();

            ResetCards();
            Guess(card);
        }
    }
}
