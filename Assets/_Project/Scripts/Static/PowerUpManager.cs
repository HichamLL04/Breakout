using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    ScoreCounting scoreCounting;
    PlayerMovement playerMovement;
    [SerializeField] GameObject ballPrefab;

    float originalSpeed = 0f;
    float speedBoostTimer = 0f;
    bool isSpeedBoosted = false;
    float doublePointsTimer = 0f;
    bool isDoublePointsActive = false;
    bool isBigSizeActive = false;
    float bigSizeTimer = 0f;

    Vector3 originalVector;

    void Start()
    {
        scoreCounting = FindFirstObjectByType<ScoreCounting>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        originalSpeed = playerMovement.GetSpeed();
        originalVector = playerMovement.GetTransform();
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

        if (isBigSizeActive)
        {
            bigSizeTimer -= Time.deltaTime;

            if (bigSizeTimer <= 0f)
            {
                playerMovement.SetTransform(originalVector);
                isBigSizeActive = false;
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
        else if (tipo.Equals("size"))
        {
            BigSize(duracion);
        }
        else if (tipo.Equals("multiBall"))
        {
            DuplicateBall();
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

    void BigSize(float duracion)
    {
        if (!isBigSizeActive)
        {
            playerMovement.SetTransform(originalVector + new Vector3(50f, 0f, 0f));
            isBigSizeActive = true;
        }
        bigSizeTimer = duracion;
    }

    void DuplicateBall()
    {
        GameObject pala = GameObject.FindGameObjectWithTag("Player");
        Vector3 newPos = pala.transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), 2f, 0f);

        GameManager gm = FindFirstObjectByType<GameManager>();
        Instantiate(ballPrefab, newPos, Quaternion.identity, gm.GetContainer());
    }
}