using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_Test : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    private void Start()
    {
        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = () => {
            UI_Blocker.Show_Static();

            UI_Input.Show_Static("X", 0, () => {
                // Clicked Cancel
                UI_Blocker.Hide_Static();
            }, (int X) => {
                // Clicked Ok
                UI_Input.Show_Static("Y", 0, () => {
                    // Cancel
                    UI_Blocker.Hide_Static();
                }, (int Y) => {
                    // Ok
                    //UI_Blocker.Hide_Static();
                    UI_Input.Show_Static("Val", 0, () => {
                        // Cancel
                        UI_Blocker.Hide_Static();
                    }, (int Val) => {
                        // Ok
                       // UI_Blocker.Hide_Static();
                        UI_Input.Show_Static("Side", 0, () => {
                            // Cancel
                            UI_Blocker.Hide_Static();
                        }, (int side) => {
                            // Ok
                            UI_Blocker.Hide_Static();
                            gridManager.ChangeBoard(X,Y,Val,side);
                        });
                    });
                });
            });
        };
    }
}
