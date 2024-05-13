using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CookingZone : MonoBehaviour
{
    public List<DraggingItems> items;
    public string[] recipes;
    public DraggingItems[] recipeResult;
    [SerializeField] 
    private string currentRecipeString;

    public float timeToCook;
    public Image timerBar;
    private float timeleft;

    public AudioSource myFX;
    public AudioClip[] voiceLines;

    public MiniGame miniGame;

    public TaskManager taskManager;

    private void Update()
    {
        if(timeleft > 0)
        {
            timeleft -= Time.deltaTime;
            timerBar.fillAmount = 1 - (timeleft / timeToCook);
        }
        if (miniGame.playerSucceeded)
        {
            StartCoroutine(CheckForRecipe(timeToCook));
            timerBar.enabled = true;
            timeleft = timeToCook;
            miniGame.playerSucceeded = false;
            myFX.PlayOneShot(voiceLines[1]);
            myFX.PlayOneShot(voiceLines[4]);
        }
    }
    public void Cooking()
    {
        if (recipes.Contains(currentRecipeString)) 
        {
            if (taskManager.tasks[taskManager.currentTaskIndex].recipeToCook == currentRecipeString)
            {
                myFX.PlayOneShot(voiceLines[0]);
                miniGame.gameObject.SetActive(true);
                for (int i = items.Count; i > 0; i--)
                {
                    items[i - 1].isDraggable = false;
                }
            }
            else
            {
                myFX.PlayOneShot(voiceLines[3]);
            }
        }
        else
            myFX.PlayOneShot(voiceLines[2]);
    }

    private IEnumerator CheckForRecipe(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < recipes.Length; i++)
        {
            if (recipes[i] == currentRecipeString)
            {
                Debug.Log("Готово!");
                taskManager.CompleteTask(currentRecipeString);
                for (int j = items.Count; j > 0; j--)
                {
                    Destroy(items[j-1].gameObject);
                }
                items.Clear();
                currentRecipeString = "";
                timerBar.enabled = false;
                myFX.Stop();

                GameObject cookedItem = Instantiate(recipeResult[i].gameObject, transform.position, Quaternion.identity);
                cookedItem.transform.position += new Vector3(1, 1, 0);
                cookedItem.transform.position -= new Vector3(1, 1, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {  
            currentRecipeString += item.itemName; 
            items.Add(item);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentRecipeString = currentRecipeString.Replace(item.itemName, "");
            items.Remove(item);
        }
    }

}
