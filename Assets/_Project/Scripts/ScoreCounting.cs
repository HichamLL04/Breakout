using TMPro;
using UnityEngine;

public class ScoreCounting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(string tag)
    {
        switch (tag)
        {
            case "Grey":
                score += 5;
                break;
            case "Green":
                score += 10;
                break;
            case "Yellow":
                score += 15;
                break;
            case "Orange":
                score += 20;
                break;
            case "Red":
                score += 25;
                break;
            case "Purple":
                score += 30;
                break;
        }
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        textMeshProUGUI.text = score.ToString().PadLeft(7, '0');
    }
}
