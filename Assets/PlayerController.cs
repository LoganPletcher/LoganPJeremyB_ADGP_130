using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

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
    private Vector3 targetAngles;
    public float smooth = 1f;
    float start;
    float dest = 0.0f;
    float SDegr = 450;

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Previous = gameObject.transform.position;
        float SRy = sword.transform.rotation.y;

        if (Input.GetKeyDown("w"))
            pressW = true;
        if (Input.GetKeyUp("w"))
            pressW = false;
        if (pressW == true)
            gameObject.transform.position = new Vector3
                (Previous.x + ((transform.forward.x * speed) * Time.deltaTime),
                Previous.y, Previous.z + +((transform.forward.z * speed) * Time.deltaTime));
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

        if((EInteract == true) && (pressE == true))
        {
            //print("Interaction");
            if(Interactive.tag == "Door1A")
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

        if((swing == false) && Input.GetMouseButtonDown(0))
        {
            swing = true;
        }

        //print(sword.transform.rotation.y);
        start = sword.transform.eulerAngles.y;

        if(swing == true)
        {
            //dest = start + SDegr * (180.0f / 3.14159265359f);
            //sword.transform.Rotate(0, Time.deltaTime * 30, 0, Space.Self);
            //targetAngles = sword.transform.eulerAngles + 180f * Vector3.up;
            //sword.transform.Rotate(0, SRy - 0.1f, 0);
            if(!((transform.eulerAngles.y - 360) >= -5) && (transform.eulerAngles.y <= 5))
                sword.transform.position = new Vector3(Previous.x, .75f, Previous.z + .27f);
            sword.transform.eulerAngles = new Vector3(0, SDegr + transform.eulerAngles.y, 0);
            SDegr -= 5;
            
        }
        print(transform.eulerAngles.y);
        //sword.transform.eulerAngles = Vector3.Lerp
           // (sword.transform.eulerAngles, targetAngles, smooth * Time.deltaTime);

        if (SDegr <= 270)
        {
            swing = false;
            SDegr = 450;
        }

        if(swing == false)
            sword.transform.position = new Vector3(Previous.x, -1, Previous.z + .26f);

    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Door1A") || (other.tag == "Door1B")
            || (other.tag == "Door2.1A") || (other.tag == "Door2.1A")
            || (other.tag == "Door2.2A") || (other.tag == "Door2.2B"))
        {

            InteractTEXT.text = "Press 'E' to interact";
            Interactive = other;
            EInteract = true;
        }
        //Destroy(other.gameObject);
    }
    /// <summary>
    /// 
    /// </summary>
    void OnTriggerExit()
    {
        InteractTEXT.text = "";
        Interactive = null;
        EInteract = false;
    }

}
