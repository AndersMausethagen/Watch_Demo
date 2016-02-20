using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplodedView : MonoBehaviour
{
    private Vector3[] startpos;//The starting position for children
    private Quaternion[] startrot; //The starting rotation for all children
    public int components; //The number of children the gameobject has
    bool spread = false; //if the components are scattered or not. False on startup
    public float spaceX; //The space between the children on the X-axis
    public float spaceZ = 0; //The space between the children on the Z-axis
    public Text buttonText; //The text on the button for changing view


	// Use this for initialization
	void Start ()
    {
        components = transform.childCount; //get the number of children
        startpos = new Vector3[components]; //set the array to the size of components
        startrot = new Quaternion[components]; //set the array to the size of components


        for (int i = 0; i < components; i++)
        {
            GameObject child = transform.GetChild(i).gameObject; //reference to the child objects
            startpos[i] = child.transform.position; //Store the starting position of the child
            startrot[i] = child.transform.rotation; //store the starting rotation of the child


        }

        buttonText = GameObject.Find("ChangeView").GetComponent<Text>(); //Find the button to change the viewmode
        buttonText.text = "Explosive view";  //Change to text


    }

    // Update is called once per frame
    void Update ()
    {
	
	}
    //Function for assembling/spreading the components
    void explodeView() //spaceX is the spacing between the components on the X-Axis
    {
        if (spread)//if the bool is set to true
        {
            for (int i = 0; i < components; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;//reference to the child objects

                child.transform.position = new Vector3(spaceX * i, 0, 0); //spread the components out on the X-Axis
            }
            buttonText.text = "Assembled view"; //change the text
        }
        if (!spread) //if the bol is set to false
        {
            for (int i = 0; i < components; i++)
            {
                GameObject child = transform.GetChild(i).gameObject; //reference to the child objects
                child.transform.position = startpos[i]; //revert to starting position
                child.transform.rotation = startrot[i]; //revert to starting rotation
            }
            buttonText.text = "Explosive view"; //change the text
        }
    }

    //Function for assembling/spreading the components. Version 2. 
    void explodeView2() 
    {

        if (spread)//if the bool is set to true
        {

            for (int i = 0, y = 0; y <= components; y++)
            {
                for (int x = 0; x <= y; x++, i++)
                {
                    GameObject child = transform.GetChild(i).gameObject;
                    child.transform.position = new Vector3(spaceX * x, 0, spaceZ * y);
                }
                buttonText.text = "Assembled view"; //change the text
            }


        }
        if (!spread) //if the bol is set to false
        {
            for (int i = 0; i < components; i++)
            {
                GameObject child = transform.GetChild(i).gameObject; //reference to the child objects
                child.transform.position = startpos[i]; //revert to starting position
                child.transform.rotation = startrot[i]; //revert to starting rotation
            }
            buttonText.text = "Explosive view"; //change the text

        }
    }

    public void changeView() //function for attaching to UI button
    {
        
        spread = !spread;//Change the bool
        explodeView2(); //start the function

    }
}
