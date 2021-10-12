using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private Sprite _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    private int _value = 0;
    private int _side = 0;


    public void Init(bool isOffset) {
        _renderer.sprite = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public void setValue(int val)
    {
        _value = val;
    }

    public void setSide(int side)
    {
        _side = side;
    }

    public int getValue()
    {
        return this._value;
    }

    public int getSide()
    {
        return this._side;
    }
}