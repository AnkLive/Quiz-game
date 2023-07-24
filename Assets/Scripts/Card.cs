using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite[] _cardContent;
    [SerializeField] private Sprite _card; 

    private int _cardType = 1;
    private Image _cardImage;

    private void Start() => _cardImage = GetComponent<Image>();

    public void OnClick() 
    {
        if(_cardImage.sprite.Equals(_card)) 
            _cardImage.sprite = _cardContent[_cardType];
        else 
            _cardImage.sprite = _card;
    }
}
