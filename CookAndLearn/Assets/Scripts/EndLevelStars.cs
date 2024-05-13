using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelStars : MonoBehaviour
{
    int levelInfo;
    public Image starImage;
    public Sprite[] starSprites;

    private void Start()
    {
        levelInfo = PlayerPrefs.GetInt("Stars_" + SceneManager.GetActiveScene().buildIndex);
        Debug.Log(levelInfo);
        starImage.sprite = starSprites[levelInfo];
    }
}
