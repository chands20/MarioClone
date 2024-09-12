using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI pointsText;

    private int currentPoints = 0;
    public int currentHealth;

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
        currentHealth = 5;
    }

    public void Update()
    {
        if ((currentPoints == 25) || currentHealth == 0)
        {

            SceneManager.LoadScene(0);
            currentPoints = 0;

        }
        pointsText.text = "x" + currentPoints + " Player Health: " + currentHealth;
    }

    public void IncreasePoints(int points)
    {
        currentPoints += points;
        pointsText.text = "x" + currentPoints + " Player Health: " + currentHealth;
    }
}
