using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//===================================================================
// Each heart is aware of it's health value.
public class Hearts : MonoBehaviour {

   private int maxValue = 3;
   private int minValue = 0;
   private int myValue = 0;
   private int prevValue = -1;

   void Update()
   {
      if (myValue == prevValue)
         return;

      this.GetComponent<Image>().sprite = HeartImages.getInstance().getState(myValue);
      Animator theAnim = this.GetComponent<Animator>();

      switch(myValue)
      {
         case 0:  // empty hearts
            theAnim.SetInteger("heartState", 0);
            break;
         case 1:  // 1/3rd heart
            theAnim.SetInteger("heartState", 1);
            break;
         case 2:  // 2/3rd heart
            theAnim.SetInteger("heartState", 2);
            break;
         case 3:  // full heart
            theAnim.SetInteger("heartState", 3);
            break;
         default:
            throw new System.Exception("Hearts.CS [" + this.gameObject.name + "] FATAL ERROR: DEFAULT CASE REACHED");
      }

      this.prevValue = this.myValue;
   }

	public void changeState(int nState)
   {
      if ( nState > maxValue || nState < minValue )
      {
         throw new System.Exception("Hearts.cs changeState() was passed an invalid parameter.");
      }

      this.myValue = nState;
   }
}
