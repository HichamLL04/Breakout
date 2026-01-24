using UnityEngine;
using UnityEngine.UI;

public class BrickRowManager : MonoBehaviour
{
    [SerializeField] GameObject[] bricks;

    private static int totalBricks = 0;

    void Start()
    {
        InstanceBricks();
        Invoke("DisableLayoutGroup", 0.5f);
    }

    public void DisableLayoutGroup()
    {
        var layoutGroup = GetComponent<HorizontalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.enabled = false;
        }
    }

    public void EnableLayoutGroup()
    {
        var layoutGroup = GetComponent<HorizontalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.enabled = true;
        }
    }

    public void InstanceBricks()
    {
        for (int i = 0; i < 11; i++)
        {
            Instantiate(bricks[RandomInt()], transform);
            totalBricks++;
        }
    }

    public static void OnBrickDestroyed()
    {
        totalBricks--;
        if (totalBricks <= 0)
        {
            RegenerateAll();
        }
    }

    static void RegenerateAll()
    {
        BrickRowManager[] allRows = FindObjectsByType<BrickRowManager>(FindObjectsSortMode.None);

        foreach (var row in allRows)
        {
            row.EnableLayoutGroup();
            row.InstanceBricks();
            row.Invoke("DisableLayoutGroup", 0.5f);
        }
    }

    int RandomInt()
    {
        int index = Random.Range(0, 100);

        if (index <= 49) return 0;
        else if (index <= 74) return 1;
        else if (index <= 87) return 2;
        else if (index <= 94) return 3;
        else if (index <= 98) return 4;
        else return 5;
    }
}