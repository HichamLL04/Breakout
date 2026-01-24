using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Scriptable Objects/PowerUp")]
public class PowerUp : ScriptableObject
{
    [SerializeField] string powerUpType;
    [SerializeField] float time;

    public string GetPowerUpType()
    {
        return powerUpType;
    }

    public float GetTime()
    {
        return time;
    }
}
