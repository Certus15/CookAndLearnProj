using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    public List<DraggingItems> items;
    public string[] itemsForWin;
    [SerializeField]
    private string currentItemInZone;

    public GameObject winInterface;
    public GameObject loseInterface;

    [SerializeField]
    private float timeToWin;
    [SerializeField]
    private Image timerBar;
    private float timeLeft, timeCurrent;
    private int sceneIndex;
    private int StarCount;

    private void Start()
    {
        timerBar.enabled = true;
        timeLeft = timeToWin;
    }
    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / timeToWin;
        }
        if (timeLeft <= 0)
        {
            loseInterface.SetActive(true);
        }
    }

    private void CheckForWin()
    {
        for (int i = 0; i < itemsForWin.Length; i++)
        {
            if (itemsForWin[i] == currentItemInZone)
            {
                Debug.Log("Вы победили!");
                sceneIndex = SceneManager.GetActiveScene().buildIndex;

                timeCurrent = timeLeft;
                UnlockNewLevel();
                if (timeCurrent / timeToWin >= 0.8)
                    StarCount = 3;
                else if (timeCurrent / timeToWin < 0.8 && timeCurrent / timeToWin >= 0.6)
                    StarCount = 2;
                else if (timeCurrent / timeToWin < 0.6 && timeCurrent / timeToWin >= 0.4)
                    StarCount = 1;
                else if (timeCurrent / timeToWin < 0.4)
                    StarCount = 0;

                PlayerPrefs.SetInt("Stars_" + sceneIndex, StarCount);
                PlayerPrefs.Save();
                winInterface.SetActive(true);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentItemInZone += item.itemName;
            items.Add(item);
            CheckForWin();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentItemInZone = currentItemInZone.Replace(item.itemName, "");
            items.Remove(item);
            CheckForWin();
        }
    }

    private void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
