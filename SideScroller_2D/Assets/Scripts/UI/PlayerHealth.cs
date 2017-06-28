using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 3;
    public int healthPerHeart = 3;
    public int currentHealth = 0;

    public GameObject[] allHearts;

    private int currentHeartIndex = 0;

    // Use this for initialization
    private void Awake()
    {
        currentHealth = startingHealth;
        addContainers(this.startingHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            addContainers(1);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            removeContainers(1);
        }
    }

    // Adds a defined amount of heart containers
    public void addContainers(int amount)
    {
        if (currentHeartIndex >= 9)
            return;

        for (int ix = 0; ix < amount; ix++)
        {
            allHearts[currentHeartIndex].SetActive(true);
            currentHeartIndex++;
        }

        foreach(GameObject go in allHearts)
        {
            go.GetComponent<Animator>().Play("FullHeart", -1, 0f);
        }

        Debug.Log(currentHeartIndex);
    }

    // removes a defined amount of heart containers
    public void removeContainers(int amount)
    {
        if (currentHeartIndex <= 0)
            return;

        for (int ix = 0; ix < amount; ix++)
        {
            currentHeartIndex--;
            allHearts[currentHeartIndex].SetActive(false);
        }

        Debug.Log(currentHeartIndex);
    }

    public void modifyHealth(int amount)
    {
        for (int ix = 0; ix < amount; ix++)
        {
        }
    }
}

