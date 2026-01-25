using TMPro;
using UnityEngine;

public class ScoreCounting : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    int score = 0;
    int multiplier = 1;

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(string tag)
    {
        switch (tag)
        {
            case "Grey":
                score += 5*multiplier;
                break;
            case "Green":
                score += 10*multiplier;
                break;
            case "Yellow":
                score += 15*multiplier;
                break;
            case "Orange":
                score += 20*multiplier;
                break;
            case "Red":
                score += 25*multiplier;
                break;
            case "Purple":
                score += 30*multiplier;
                break;
        }
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        textMeshProUGUI.text = score.ToString().PadLeft(7, '0');
    }

    public int GetScore()
    {
        return score;
    }
    
    public int GetMultiplier()
    {
        return multiplier;
    }

    public void SetMultiplier(int newMultiplier)
    {
        multiplier = newMultiplier;
    }
}
