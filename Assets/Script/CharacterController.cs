using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    private Animation anim;

    private float curSpeed, targetSpeed, rotSpeed;
    private float maxForwardSpeed = 3.0f;
    private float maxBackwardSpeed = -3.0f;

    public GameObject skillParticlePrefab;


    void Start()
    {
        rotSpeed = 90.0f;
        anim = gameObject.GetComponent<Animation>();
        anim.Play("Idle");
    }

    void OnEndGame()
    {
        this.enabled = false;
    }

    void Update()
    {
        UpdateControl();
        UpdateSkill();
    }

    void UpdateControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetSpeed = maxForwardSpeed;
            anim.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetSpeed = maxBackwardSpeed;
            anim.Play("Walk");
        }
        else
        {
            targetSpeed = 0;
            anim.Play("Idle");
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotSpeed * Time.deltaTime, 0.0f);
            anim.Play("Walk");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0.0f);
            anim.Play("Walk");
        }
        curSpeed = Mathf.Lerp(curSpeed, targetSpeed, 7.0f * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }

    void OnTriggerEnter(Collider col)
    {
        Screen screen = GameObject.Find("GUI Text").GetComponent<Screen>();

        if (col.tag == "Snowman")
        {
            int randomDamage = Random.Range(30, 51);
            screen.PlayerHP -= randomDamage;
        }
        else if (col.tag == "Father")
        {
            Debug.Log("GetGift");
            screen.gift = true;
        }
        else if (col.tag == "Mother")
        {
            if (screen.skill == 2)
                return;
            Debug.Log("GetSkill");
            screen.skill = 1;
        }
        else if (col.tag == "Finish")
        {
            if (screen.mission)
            {
                StartCoroutine(winner());
                Application.LoadLevel("Win");
            }
        }
        else if (col.tag == "Tree")
        {
            if (screen.gift == true)
            {
                screen.mission = true;
                var kiddie = GameObject.FindGameObjectWithTag("Kid");
                kiddie.GetComponent<ChaseSanta>().flag = false;

            }
            else
            {
                screen.mission = false;
            }
        }
    }

    void UpdateSkill()
    {
        Screen screen = GameObject.Find("GUI Text").GetComponent<Screen>();

        if (screen.skill == 1)
        {
            if (Input.GetKey(KeyCode.E))
            {
                var mon1 = GameObject.FindGameObjectsWithTag("Snowman");
                for (int i = 0; i < mon1.Length; i++)
                {
                    mon1[i].GetComponent<VehicleFollowing>().flag = true;
                    StartCoroutine(waiting(mon1[i]));
                    GameObject instance = Instantiate(skillParticlePrefab, mon1[i].transform.position, mon1[i].transform.rotation) as GameObject;
                    Destroy(instance, 2.0f);
                }
                screen.skill = 2;
            }
        }
    }

    IEnumerator winner()
    {
        GUI.Label(new Rect(150, 150, 150, 20), "Win");
        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator waiting(GameObject mon1)
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3.0f);
        mon1.GetComponent<VehicleFollowing>().flag = false;
    }
}