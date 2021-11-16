using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int playerScore = 0;

    private static ScoreKeeper _sKInstance;
    public static ScoreKeeper ScoreKeeperInstance
    {
        get
        {
            if (_sKInstance == null)
            {
                _sKInstance = Instantiate(Resources.Load<ScoreKeeper>("ScoreKeeper"));
                DontDestroyOnLoad(_sKInstance.gameObject);
            }

            return _sKInstance;
        }
    }

    [SerializeField] private int pointPerEnemyKilled;

    public void PlayerDestroyedEnemy()
    {
        UpdateScore(pointPerEnemyKilled);
    }

    private void UpdateScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        playerScore = Mathf.Clamp(playerScore, 0, int.MaxValue);
    }
}
