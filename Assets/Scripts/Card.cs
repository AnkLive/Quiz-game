using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite[] _cardContent;
    [SerializeField] private Sprite _card; 

    public int CardType { get; set; }
    
    private Image _cardImage;

    private void Start() => _cardImage = GetComponent<Image>();

    public void OnClick() 
    {
        if(_cardImage.sprite.Equals(_card)) 
            _cardImage.sprite = _cardContent[CardType];
        else 
            _cardImage.sprite = _card;
    }

    public void SetDefaultImage() => _cardImage.sprite = _card;
}
