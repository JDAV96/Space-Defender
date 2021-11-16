using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    private static HUD _HUDInstance;
    public static HUD HUDInstance
    {
        get
        {
            if (_HUDInstance == null)
            {
                _HUDInstance = Instantiate(Resources.Load<HUD>("HUD Canvas"));
                DontDestroyOnLoad(_HUDInstance.gameObject);
            }

            return _HUDInstance;
        }
    }

    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;

    public void SetHealthSlider(float newValue)
    {
        healthSlider.value = newValue;
    }

    public void SetScoreText(int newScore)
    {
        scoreText.text = newScore.ToString("000000000");
    }
}
