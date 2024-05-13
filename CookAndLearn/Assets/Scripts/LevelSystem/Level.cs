using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private int levelStarInfo, unlockedLevel;
    [SerializeField]
    private int level;
    public Image starImage;
    public Image lockerImage;
    public Sprite[] starSprites;

    private void Start()
    {
        levelStarInfo = PlayerPrefs.GetInt("Stars_" + level);
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if(level-1 < unlockedLevel)
        {
            lockerImage.gameObject.SetActive(false);
        }
        starImage.sprite = starSprites[levelStarInfo];

    }
}
