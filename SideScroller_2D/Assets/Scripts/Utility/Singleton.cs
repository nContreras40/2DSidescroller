//===<Authors>=======================================================
// Singleton.cs provided by Issac Irlas.
// Documentation provided by Nathan Contreras.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//===<Class>=========================================================
// Singleton class used to represent a unique class, in which there
// can and will only be one instance of.
abstract public class Singleton <Type> : MonoBehaviour 
   where Type : MonoBehaviour
{
   // A reference to this singleton object.
   static private Type ourInstance;

   //================================================================
   // isValid is a public state checker for this singleton.  If the
   // desired singleton is not found, will return false.  Should be
   // used before the use of getInstance method in order to prevent
   // the throwing of an exception.
   public static bool isValid
   {
      get { return ourInstance != null; }
   }

   //================================================================
   // getInstance function will fetch the current instance of this 
   // singleton.  Throws an exception if a singleton of this type
   // is not found.
   static public Type getInstance()
   {
      if (ourInstance == null)
      {
         ourInstance = GameObject.FindObjectOfType<Type>();
         if (ourInstance == null)
         {
            throw new System.Exception("Singleton [" + typeof(Type) + "] not in the current scene!");
         }
      }
      return ourInstance;
   }

   //================================================================
   // On Awake, attempt to fetch an instance of this Type singleton.
   // If we retrieve a different instance than this instance, we have
   // a duplicate singleton floating around.  Throw an exception
   // immediately.  Call this Type's Init function if successful.
   void Awake()
   {
      ourInstance = getInstance();
      if ( ourInstance != this )
      {
         throw new System.Exception("Singleton [" + this.gameObject.name + "] conflicts with [" + ourInstance.gameObject.name + "] !");
      }
      else
      {
         Init();
      }
   }

   // replace your awake/start script with this method...
   protected abstract void Init();
}
