using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    ScoreCounting scoreCounting;
    PlayerMovement playerMovement;

    float originalSpeed = 0f;
    float speedBoostTimer = 0f;
    bool isSpeedBoosted = false;
    float doublePointsTimer = 0f;
    bool isDoublePointsActive = false;

    void Start()
    {
        scoreCounting = FindFirstObjectByType<ScoreCounting>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        originalSpeed = playerMovement.GetSpeed();
    }

    void Update()
    {
        if (isSpeedBoosted)
        {
            speedBoostTimer -= Time.deltaTime;

            if (speedBoostTimer <= 0f)
            {
                playerMovement.SetSpeed(originalSpeed);
                isSpeedBoosted = false;
            }
        }

        if (isDoublePointsActive)
        {
            doublePointsTimer -= Time.deltaTime;

            if (doublePointsTimer <= 0f)
            {
                scoreCounting.SetMultiplier(1);
                isDoublePointsActive = false;
            }
        }
    }

    public void ActivatePowerUp(PowerUp powerUpData)
    {
        string tipo = powerUpData.GetPowerUpType();
        float duracion = powerUpData.GetTime();
        
        if (tipo.Equals("speed"))
        {
            SpeedUp(duracion);
        }
        else if (tipo.Equals("double"))
        {
            DoublePoint(duracion);
        }
    }

    void SpeedUp(float duracion)
    {
        if (!isSpeedBoosted)
        {
            playerMovement.SetSpeed(originalSpeed * 3);
            isSpeedBoosted = true;
        }
        speedBoostTimer = duracion;
    }

    void DoublePoint(float duracion)
    {
        if (!isDoublePointsActive)
        {
            scoreCounting.SetMultiplier(2);
            isDoublePointsActive = true;
        }
        doublePointsTimer = duracion;
    }
}