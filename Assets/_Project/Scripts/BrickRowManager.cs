using UnityEngine;
using UnityEngine.UI;

public class BrickRowManager : MonoBehaviour
{
    // Tiene que haber 11 blockes
    [SerializeField] GameObject[] bricks;
    void Start()
    {
        InstanceBricks();
        Invoke("DisableLayoutGroup", 0.5f);
    }

    void DisableLayoutGroup()
    {
        var layoutGroup = GetComponent<HorizontalLayoutGroup>();
        if (layoutGroup != null)
        {
            layoutGroup.enabled = false;
            Debug.Log($"Layout deshabilitado en {gameObject.name}");
        }
    }

    void InstanceBricks()
    {
        for (int i = 0; i <= 10; i++)
        {
            Instantiate(bricks[RandomInt()], transform);
        }
    }

    int RandomInt()
    {
        int index = Random.Range(0, 100);

        if (index <= 49)
        {
            return 0;
        }
        else if (index <= 74)
        {
            return 1;
        }
        else if (index <= 87)
        {
            return 2;
        }
        else if (index <= 94)
        {
            return 3;
        }
        else if (index <= 98)
        {
            return 4;
        }
        else if (index <= 99)
        {
            return 1;
        }
        return 0;
    }
}