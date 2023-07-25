using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite[] _cardContent;
    [SerializeField] private Sprite _card;

    private GameplayState _gamePlayState;

    public int CardType { get; set; }
    
    private Image _cardImage;

    private void Start() 
    {
        _cardImage = GetComponent<Image>();
        _gamePlayState = FindObjectOfType<GameplayState>();
    }

    public void OnClick() 
    {
        if(_cardImage.sprite.Equals(_card)) 
        {
            _cardImage.sprite = _cardContent[CardType];
            _gamePlayState.Guess(this);
        }
    }

    public void SetDefaultImage() => _cardImage.sprite = _card;
}
