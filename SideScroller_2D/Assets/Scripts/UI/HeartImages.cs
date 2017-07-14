using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartImages : Singleton<HeartImages> {

   public Sprite[] heartState;
   public Animation[] anims;

	// Use this for initialization
	protected override void Init () {
		
	}
	
	public Sprite getState(int state)
   {
      return this.heartState[state];
   }

   public Sprite[] getArray()
   {
      return this.heartState;
   }

   public Animation getAnim(int anim)
   {
      return this.anims[anim];
   }
}
