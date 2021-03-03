using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Name : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        string name;
        int highscore;
        try
        {
            var player = gm.GetActivePlayer();
            name = player.Name;
            highscore = player.HighScore;
        }
        catch
        {
            name = "";
            highscore = 0;
        }

        textComp.text = $"{name} Highscore: {highscore}";
    }
}
