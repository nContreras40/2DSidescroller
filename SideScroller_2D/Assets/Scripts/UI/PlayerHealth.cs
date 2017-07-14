using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

//=============================================================================
// PlayerHealth class is a manager class that will accomplish the following:
//  - Track the player's health
//  - Communicate with the UI to update the health visual for the player
//  - Translate between scenes to continue tracking player health
//      - DontDestroyOnLoad should be found somewhere on the top-parent object.
public class PlayerHealth : Singleton<PlayerHealth>
{
   // The maximum heart containers a player may have.
   private readonly int maxHearts = 10;

   // The total health value a full heart may represent.
   private readonly int healthPerHeart = 3;
   
   // The number of heart containers the player will start a new game with.
   private readonly int startingContainers = 3;
   
   // The current total health of the player.
   private int currentHealth = 0;
   
   // The current total heart containers of the player.
   private int currentContainers = 0;

   // An array collection of the maximum hearts displayed.
   public GameObject[] allHearts;

   //================================================================
   // Use this for initialization
   protected override void Init()
   {
      addContainers(this.startingContainers);
      this.currentHealth = this.currentContainers * healthPerHeart;
   }

   //================================================================
   // Called every frame...
   private void Update()
   {
      if ( Input.GetKeyDown(KeyCode.Plus) )
      {
         this.currentHealth++;
      }
      else if ( Input.GetKeyDown(KeyCode.Minus) )
      {
         this.currentHealth--;
      }
      displayHealth();
   }

   //================================================================
   // Display the current health of the player on the UI canvas.
   private void displayHealth()
   {
      int ix = 0;
      int heartIndex =( (int)( Math.Ceiling( (float)this.currentHealth / (float)this.healthPerHeart + 1 ) ) );
      int healthIndex = (this.currentHealth % this.healthPerHeart);
      if (healthIndex == 0) //0 should represent a full heart.  Full heart is 3rd state.
      {
         healthIndex = 3;
      }

      foreach (GameObject go in allHearts)
      {
         Hearts theHeart = go.GetComponent<Hearts>();
         if (ix < heartIndex)  // Health containers should be full
         {
            theHeart.changeState(this.healthPerHeart);
         }  
         if (ix == heartIndex) // This health container should be the only non-full heart
         {
            theHeart.changeState(healthIndex);
         }
         else                  // All remaining containers should be empty.
         {
            theHeart.changeState(0);
         }
      }
   }

   //================================================================
   // Adds a defined amount of heart containers to the player's 
   // current total.  The player may not have more heart containers
   // than the total value within this.maxHearts
   public void addContainers(int amount)
   {
      if (currentContainers >= maxHearts-1)
         return;

      for (int ix = 0; ix < amount; ix++)
      {
         allHearts[currentContainers].SetActive(true);
         currentContainers++;
      }

      // Play the pulsing animation for each heart container
      /*
      foreach (GameObject go in allHearts)
      {
         go.GetComponent<Animator>().Play("FullHeart", -1, 0f);
      }
      */

      Debug.Log(currentContainers);
   }

   //================================================================
   // removes a defined amount of heart containers
   public void removeContainers(int amount)
   {
      if (currentContainers <= 0)
         return;

      for (int ix = 0; ix < amount; ix++)
      {
         currentContainers--;
         allHearts[currentContainers].SetActive(false);
      }

      Debug.Log(currentContainers);
   }

   //================================================================
   // public mutator for the player's health.  Prevents adding more 
   // hearts than the player can contain.
   public void modifyHealth(int amount)
   {
      this.currentHealth += amount;
      int pHealth = this.healthPerHeart * this.currentContainers;

      if (this.currentHealth > pHealth)
      {
         this.currentHealth = pHealth;
      }
   }
}

