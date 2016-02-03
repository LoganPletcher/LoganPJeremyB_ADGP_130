using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = .05f;
    float Ry = 0;
    bool pressW = false;
    bool pressS = false;
    bool pressA = false;
    bool pressD = false;
    bool Jump = false;
    public float AirTime;
    public float Rspeed;



    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Previous = gameObject.transform.position;

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
        


    }

    void OnGUI()
    {
        
            //Debug.Log("Hello!");
    }

}
