using UnityEngine;
using System.Collections;

public class ChaseSanta : MonoBehaviour
{
    private float curSpeed;
    private float curRotSpeed;
    private Transform playerTransform;
    private GameObject objPlayer;
    private Vector3 destPos;
    private int count;

    public bool flag = true;

    void Start()
    {
        curSpeed = 5.0f;
        curRotSpeed = 5.0f;
        count = 0;

        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        playerTransform = objPlayer.transform;

        if (!playerTransform)
            print("Player doesn't exist.. Please add one with Tag named 'Player'");
    }

    void Update()
    {
        if (flag)
            return;

        switch (count)
        {
            case 0:
                destPos = new Vector3(6.6f, 3.5f, 27.5f);
                if (Vector3.Distance(destPos, transform.position) < 0.3)
                    count++;
                break;
            case 1:
                destPos = new Vector3(6.6f, 2.0f, 32.5f);
                if (Vector3.Distance(destPos, transform.position) < 0.3)
                    count++;
                break;
            case 2:
                destPos = new Vector3(1.7f, 0.0f, 32.3f);
                if (Vector3.Distance(destPos, transform.position) < 0.3)
                    count++;
                break;
            case 3:
                curSpeed = 3.0f;
                if (Vector3.Distance(playerTransform.position, transform.position) > 3.0)
                {
                    destPos = new Vector3(2.0f, 0.0f, 27.0f);
                    if (Vector3.Distance(destPos, transform.position) < 0.3)
                        count++;
                }
                else
                    count = 5;
                break;
            case 4:
                curSpeed = 3.0f;
                if (Vector3.Distance(playerTransform.position, transform.position) > 3.0)
                {
                    destPos = new Vector3(2.0f, 0.0f, 24.0f);
                    if (Vector3.Distance(destPos, transform.position) < 0.3)
                        count--;
                }
                else
                    count = 5;
                break;
            default:
                curSpeed = 2.0f;
                destPos = playerTransform.position;
                if (Vector3.Distance(destPos, transform.position) > 3.0)
                {
                    count = 3;
                }
                break;
        }

        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * curRotSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }


    void OnTriggerStay(Collider col)
    {
        Screen screen = GameObject.Find("GUI Text").GetComponent<Screen>();

        if (col.tag == "Player")
        {
            screen.PlayerHP -= 100;
        }
    }
}