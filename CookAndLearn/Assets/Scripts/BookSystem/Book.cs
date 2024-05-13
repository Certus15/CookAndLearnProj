using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    [SerializeField]
    private Page[] pages;
    [SerializeField]
    private Page emptyPage;

    private int currentPageIndex = 0, unlockedLevel;

    public Button prevButton, nextButton;

    public TextMeshProUGUI pageNumberText;

    private void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);
        ShowPage(currentPageIndex);
        prevButton.interactable = false;
        nextButton.interactable = true;

    }

    private void ShowPage(int pageIndex)
    {
        foreach (Page page in pages)
        {
            page.gameObject.SetActive(false);
        }
        pageNumberText.text = "Page " + (pageIndex+1).ToString() + " " + pages[pageIndex].pageName;
        if(pageIndex < unlockedLevel-1)
        {
            pages[pageIndex].gameObject.SetActive(true);
        } else
        {
            emptyPage.gameObject.SetActive(true);
        }


    }

    public void NextPage()
    {
        if (currentPageIndex < pages.Length-1)
        {
            prevButton.interactable = true;
            currentPageIndex++;
            ShowPage(currentPageIndex);
            if (currentPageIndex == pages.Length-1)
            {
                nextButton.interactable = false;
            }
        }
    }

    public void PreviousPage()
    {
        if(currentPageIndex != 0)
        {
            nextButton.interactable = true;
            currentPageIndex--;
            ShowPage(currentPageIndex);
            if (currentPageIndex == 0)
            {
                prevButton.interactable = false;
            }
        }
    }
}
