using UnityEngine;
using System.Collections;

public class Screen : MonoBehaviour
{
    public int PlayerHP = 100;
    public int skill = 0;
    public bool gift = false;
    public bool mission = false;

    public int sec = 0;
    public float timer = 0.0f;

    void OnGUI()
    {
        Font myFont1 = (Font)Resources.Load("PWHappyChristmas") as Font;
        Font myFont2 = (Font)Resources.Load("Christmas Time Personal Use") as Font;
        GUIStyle myStyle1 = new GUIStyle();
        GUIStyle myStyle2 = new GUIStyle();
        GUIStyle myStyle3 = new GUIStyle();
        myStyle1.fontSize = 50;
        myStyle2.fontSize = 35;
        myStyle3.fontSize = 25;
        myStyle1.font = myFont1;
        myStyle2.font = myFont2;
        myStyle3.font = myFont1;
        myStyle1.normal.textColor = Color.white;
        myStyle2.normal.textColor = Color.white;
        myStyle3.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 200, 50), "HP " + PlayerHP.ToString(), myStyle1);

        GUI.Label(new Rect(10, 85, 10, 50), "5", myStyle2);
        GUI.Label(new Rect(40, 100, 100, 50), "Mission", myStyle3);
        GUI.Label(new Rect(150, 85, 10, 50), "5", myStyle2);
        if (gift == false && mission == false)
        {
            GUI.Label(new Rect(180, 100, 100, 50), "Get Gift", myStyle3);
        }
        else if (gift == true && mission == true)
        {
            GUI.Label(new Rect(180, 100, 100, 50), "Go To Sledge", myStyle3);
        }
        else
        {
            GUI.Label(new Rect(180, 100, 100, 50), "Put Gift", myStyle3);
        }

        GUI.Label(new Rect(10, 130, 10, 50), "5", myStyle2);
        GUI.Label(new Rect(40, 145, 100, 50), "Skill", myStyle3);
        GUI.Label(new Rect(110, 130, 10, 50), "5", myStyle2);
        if (skill == 0)
        {
            GUI.Label(new Rect(140, 145, 100, 50), "No Skill", myStyle3);
        }
        if (skill == 1)
        {
            GUI.Label(new Rect(140, 145, 100, 50), "You Have Skill", myStyle3);
        }
        else if (skill == 2)
        {
            GUI.Label(new Rect(140, 145, 100, 50), "You Used Skill", myStyle3);
        }


        GUI.Label(new Rect(720, 10, 100, 50), "Time " + (100 - sec).ToString(), myStyle1);
    }

    void Start()
    {
    }

    void Update()
    {
        if (PlayerHP <= 0)
        {
            PlayerHP = 0;
            Application.LoadLevel("Lose");
        }

        timer += Time.deltaTime;
        sec = (int)timer;

        if (sec >= 100)
        {
            Application.LoadLevel("Lose");
        }
    }
}