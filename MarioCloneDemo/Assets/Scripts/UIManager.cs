using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI pointsText;

    private int currentPoints = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreasePoints(int points)
    {
        currentPoints += points;
        pointsText.text = "x" + currentPoints;
    }
}
