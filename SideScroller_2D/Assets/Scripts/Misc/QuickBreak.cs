using UnityEngine;
using System.Collections;

public class QuickBreak : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (bunnys.Sum( bunny => { return (bunny.gameObject.activeSelf) ? (1) : (0); } ) < 4)
            HingeJoint2D[] allJoints = GameObject.FindObjectsOfType<HingeJoint2D>();

            foreach (HingeJoint2D joint in allJoints)
            {
                joint.enabled = false;
            }
        }
    }
}
