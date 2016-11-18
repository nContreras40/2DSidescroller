using UnityEngine;
using System.Collections;

public class QuickBreak : MonoBehaviour
{

   private float timeToWait = 2.0f;
   private float timer = 0.0f;

   private bool beginBreaking = false;
   private bool hasPerformed = false;
   
   public GameObject[] crystals;

   // Use this for initialization
   void Start()
   {
      allJoints = GameObject.FindObjectsOfType<HingeJoint2D>();
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      if (Input.GetKeyDown(KeyCode.Space) && hasPerformed == false)
      {
         beginBreaking = true;
      }

      if ( beginBreaking )
      {
         breakHinge();
      }
   }

   void breakHinge()
   {
      timer += Time.deltaTime;

      foreach (GameObject crystal in crystals)
      {
         HingeJoint2D[] myJoints = crystal.GetComponentsInChildren<HingeJoint2D>();
         foreach (HingeJoint2D joint in myJoints)
         {
            if (timer >= timeToWait)
            {
               joint.enabled = false;
               beginBreaking = false;
               hasPerformed = true;
            }
            else
            {
               JointMotor2D motor = joint.motor;
               motor.motorSpeed = motor.motorSpeed + 5.0f;

               //Rotation[] childRots = joint.gameObject.GetComponentsInChildren<Rotation>();
               //foreach (Rotation rot in childRots)
               //{
               //   rot.deltaZ = rot.deltaZ - 5.0f;
               //}
               joint.motor = motor;
            }
         }
      }
   }
}
