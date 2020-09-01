using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{

    public GameObject doorAppears;
    public GameObject doorDisappears;
    public GameObject doorOpen;

    public bool doorIsOpen;
    public bool playerIsAtDoor;

  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
        if (doorIsOpen == true) //After the player presses the switch, the door is appears and it is still closed
        {
            doorAppears.SetActive(true);
        } 

        if (doorIsOpen == false) //If this bool is false, the door will not appear
        {
            doorAppears.SetActive(false);
        }
    }

    private void FixedUpdate() //When player is at the door press F then the door will open!
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsAtDoor == true)
        {
            doorOpen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp") //When player presses the switch, the coroutine for the door start allowing the player to get to the door undertimed limit. 
        {
            doorIsOpen = true;
            Destroy(collision.gameObject);
            StartCoroutine("OpenTheDoor");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerIsAtDoor") //If player is at the door then the bool is set true allowing the player to press F.
        {
            playerIsAtDoor = true;
            StopCoroutine("OpenTheDoor");
        }
    }

    IEnumerator OpenTheDoor() //Once the switch is pressed, it sets off a coroutine which gives the play 5 seconds to open the door.
    {
        yield return new WaitForSeconds(5f);
        doorIsOpen = false;
        print("the door is closed");
    }
}
