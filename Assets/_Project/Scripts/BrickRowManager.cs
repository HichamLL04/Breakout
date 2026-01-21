using UnityEngine;
using UnityEngine.UI;

public class BrickRowManager : MonoBehaviour
{
    void Start()
    {
        Invoke("DisableLayoutGroup", 0.1f);
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
}