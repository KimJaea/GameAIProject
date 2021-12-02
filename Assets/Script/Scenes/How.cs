using UnityEngine;
using System.Collections;

public class How : MonoBehaviour
{
    private int page;

    private GUIText left;
    private GUIText right;
    private GUIText s;
    private GUIText b;

    void Start()
    {
        page = 1;

        left = GameObject.Find("Left").GetComponent<GUIText>();
        right = GameObject.Find("Right").GetComponent<GUIText>();
        s = GameObject.Find("Show").GetComponent<GUIText>();

        left.material.color = Color.gray;
        right.material.color = Color.white;

        Font myFont = (Font)Resources.Load("Christmas Bell - Personal Use") as Font;

        s.font = myFont;
    }

    void OnGUI()
    {
        switch (page)
        {
            case 1:
                left.material.color = Color.gray;
                s.text = "Move [W, A, S, D]\nUse Skill [E]";
                break;
            case 2:
                left.material.color = Color.white;
                s.text = "Follow the stars on the floor\nCrash with a snowman reduces your health\nThe game is over when your health reaches 0";
                break;
            case 3:
                right.material.color = Color.white;
                s.text = "[Get gift from Father]\nWhen you put gift under tree\nKid will come looking for you";
                break;
            case 4:
                right.material.color = Color.gray;
                s.text = "[Get skill from Mother]\nYou can stop snowman with using skill only once";
                break;
        }

    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.A))
        {
            if (page > 1)
                page--;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (page < 4)
                page++;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Application.LoadLevel("Start");
        }
    }
}
