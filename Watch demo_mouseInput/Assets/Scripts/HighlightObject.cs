using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighlightObject : MonoBehaviour
{

    public float value; //The strength of the line around the highlighted object
    public Color outlineColor; //What color the outline has
    public LayerMask whatToHit; //what can be highlighted
    public Text UIdescription; //The description text on the Canvas
    public Text description; //The text attached to this object
    bool selected = false; //if this object is selected or not




    // Use this for initialization
    void Start ()
    {
        UIdescription = GameObject.Find("Description").GetComponent<Text>();//reference to the text on the canvas
        description = this.GetComponent<Text>();//Reference to the text attached to this object

    }

    // Update is called once per frame
    void Update()
    {
        //if this object is selected and is the current camera target
        if (selected && CameraBehaviour.target == this.gameObject.transform)
        {
            //change the outline of the object to value
            this.GetComponent<Renderer>().material.SetFloat("_Outline", value); //to "turn off" the outline, set val to 0 
        }
        else
        {
            //hide the outline
            this.GetComponent<Renderer>().material.SetFloat("_Outline", 0); //to "turn off" the outline, set val to 0 
        }



    }


    void OnMouseDown()//when we press the left mouse button over an object
    {
        CameraBehaviour.target = this.gameObject.transform; //Change the cameras focus target to the object clicked
        //Change the cameras position to be of the target, with a slight offset
        Camera.main.transform.position = new Vector3(CameraBehaviour.target.position.x, CameraBehaviour.target.position.y+30,CameraBehaviour.target.position.z-10);
        UIdescription.text = description.text; //update the UI text
        selected = true; //make this selected



    }


}
