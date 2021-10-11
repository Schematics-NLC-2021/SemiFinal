/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_InputWindow : MonoBehaviour {

    [SerializeField] GridManager gridManager;
    private void Start()
    {
        transform.Find("showLBBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
                UI_Leaderboard.Show_Static(() => {
                UI_Blocker.Hide_Static();
            });
        };
     }

}
