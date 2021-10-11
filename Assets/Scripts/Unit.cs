using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]private SpriteRenderer unitRender;
    [SerializeField] private Color Team1
        , Team2
        , Team3
        , Team4
        , Team5
        , Team6
        , Team7
        , Team8
        , Team9
        , Team10;
    [SerializeField] private Sprite Unit0,Unit1,Unit2,Unit3,Unit4;

    public void setSprite(int level)
    {
        switch (level)
        {
            case 1:
                unitRender.sprite = Unit1;
                break;
            case 2:
                unitRender.sprite = Unit2;
                break;
            case 3:
                unitRender.sprite = Unit3;
                break;
            case 4:
                unitRender.sprite = Unit4;
                break;
            case 0:
                unitRender.sprite = Unit0;
                break;
            default:
                break;
        }

    }

    public void setColor(int side)
    {
        switch (side)
        {
            case 1:
                unitRender.color = Team1;
                break;
            case 2:
                unitRender.color = Team2;
                break;
            case 3:
                unitRender.color = Team3;
                break;
            case 4:
                unitRender.color = Team4;
                break;
            case 5:
                unitRender.color = Team5;
                break;
            case 6:
                unitRender.color = Team6;
                break;
            case 7:
                unitRender.color = Team7;
                break;
            case 8:
                unitRender.color = Team8;
                break;
            case 9:
                unitRender.color = Team9;
                break;
            case 10:
                unitRender.color = Team10;
                break;
            default:
                break;
        }
    }

}
