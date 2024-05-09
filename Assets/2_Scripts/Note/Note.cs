using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer srdr;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;
    private bool isApple;

    public void Activate(bool _isApple)
    {
        this.isApple = _isApple;
        this.srdr.sprite = _isApple == true? appleSprite : blueberrySprite;     
    }

    public void OnInput(bool _isSelected)
    {
        if (_isSelected == true)
        {
            bool _isCorrect = this.isApple == true;
            GameManager.Instance.OnScore(_isCorrect);
        }            
                      
        this.Deactivate();
    }

    public void Deactivate()    
    {
        GameObject.Destroy(this.gameObject);
    }

}
