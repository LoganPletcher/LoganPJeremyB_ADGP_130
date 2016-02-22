using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject sword;

    public float speed = .05f;
    float Ry = 0;
    bool pressW = false;
    bool pressS = false;
    bool pressA = false;
    bool pressD = false;
    bool Jump = false;
    public float AirTime;
    public float Rspeed;

    public Text InteractTEXT;

    bool pressE = false;
    bool EInteract = false;
    Collider Interactive;

    bool swing = false;
    float SDegr = 450;

    public float health = 100;
    public bool Alive = true;

    
    public Pause pause;
    public Text uihp;
    public Text uispeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uihp.text = ("HP: ") + health.ToString();
        uispeed.text = ("Speed: ") + speed.ToString();
        if (pause.PauseOn == false)
        {
            Vector3 Previous = gameObject.transform.position;

            if (Input.GetKeyDown("w"))
                pressW = true;
            if (Input.GetKeyUp("w"))
                pressW = false;
            if (pressW == true)
                gameObject.transform.position = new Vector3
                    (Previous.x + ((transform.forward.x * speed) * Time.deltaTime),
                    Previous.y, Previous.z + ((transform.forward.z * speed) * Time.deltaTime));
            Previous = gameObject.transform.position;
            if (Input.GetKeyDown("s"))
                pressS = true;
            if (Input.GetKeyUp("s"))
                pressS = false;
            if (pressS == true)
                gameObject.transform.position = new Vector3
                    (Previous.x - ((transform.forward.x * speed) * Time.deltaTime),
                    Previous.y, Previous.z - ((transform.forward.z * speed) * Time.deltaTime));
            Previous = gameObject.transform.position;
            if (Input.GetKeyDown("a"))
                pressA = true;
            if (Input.GetKeyUp("a"))
                pressA = false;
            if (pressA == true)
                gameObject.transform.position = new Vector3
                    (Previous.x - ((transform.right.x * speed) * Time.deltaTime),
                    Previous.y, Previous.z - ((transform.right.z * speed) * Time.deltaTime));
            Previous = gameObject.transform.position;
            if (Input.GetKeyDown("d"))
                pressD = true;
            if (Input.GetKeyUp("d"))
                pressD = false;
            if (pressD == true)
                gameObject.transform.position = new Vector3
                    (Previous.x + ((transform.right.x * speed) * Time.deltaTime),
                Previous.y, Previous.z + ((transform.right.z * speed) * Time.deltaTime));
            Previous = gameObject.transform.position;
            //print("W key was pressed");

            if (Input.GetKeyDown("space"))
                Jump = true;
            if (Jump == true)
            {
                AirTime += .05f;
                gameObject.transform.position = new Vector3
                    (Previous.x, (Previous.y + (speed * Time.deltaTime)), Previous.z);
            }
            if (AirTime >= 1.0f)
            {
                Jump = false;
                AirTime = 0.0f;
            }

            Ry = Rspeed * 0.25f * Input.GetAxis("Mouse X") * Time.deltaTime;

            transform.Rotate(0, Ry, 0);

            if (Input.GetKeyDown("e"))
                pressE = true;
            if (Input.GetKeyUp("e"))
                pressE = false;

            if ((EInteract == true) && (pressE == true))
            {
                //print("Interaction");
                if (Interactive.tag == "Door1A")
                {
                    gameObject.transform.position = new Vector3(-10, Previous.y, 15.125f);
                }
                if (Interactive.tag == "Door1B")
                {
                    gameObject.transform.position = new Vector3(10, Previous.y, 15.125f);
                }
                if ((Interactive.tag == "Door2.1A") || (Interactive.tag == "Door2.1B")
                    || (Interactive.tag == "Door2.2A") || (Interactive.tag == "Door2.2B"))
                {
                    gameObject.transform.position = new Vector3(0, Previous.y, 35.125f);
                }
            }

            if ((swing == false) && Input.GetMouseButtonDown(0))
            {
                swing = true;
            }

            Vector3 SPrev = sword.transform.position;

            if (swing == true)
            {
                if ((transform.eulerAngles.y >= 5) && (transform.eulerAngles.y <= 15))
                    sword.transform.position = new Vector3
                        (Previous.x + -0.0176f, .75f, Previous.z + .265f);
                else
                    sword.transform.position = new Vector3
                        (SPrev.x, .75f, SPrev.z);
                sword.transform.eulerAngles = new Vector3(0, SDegr + transform.eulerAngles.y, 0);
                SDegr -= 5;
                SPrev = sword.transform.position;
            }

            if (SDegr <= 270)
            {
                swing = false;
                SDegr = 450;
                sword.transform.position = new Vector3
                    (SPrev.x, -2, SPrev.z);
            }
            //print(Previous.z);
            if (health <= 0)
                Alive = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Door1A") || (other.tag == "Door1B")
        || (other.tag == "Door2.1A") || (other.tag == "Door2.1A")
        || (other.tag == "Door2.2A") || (other.tag == "Door2.2B"))
        {

            if (!InteractTEXT.transform.gameObject.activeSelf)
                InteractTEXT.transform.gameObject.SetActive(true);
            InteractTEXT.text = "Press 'E' to interact";
            Interactive = other;
            EInteract = true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    void OnTriggerExit()
    {
        InteractTEXT.transform.gameObject.SetActive(false);
        InteractTEXT.text = "";
        Interactive = null;
        EInteract = false;
    }

}
