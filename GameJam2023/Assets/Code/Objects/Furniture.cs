using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Furniture : MonoBehaviour
{
    public int scoreValue;
    public TextMeshProUGUI  scoreBoard;
    public float damageDelay = 2f;

    void Start()
    {
        scoreBoard = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        UpdateScoreText(CalculateTotalScore());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText(CalculateTotalScore());
        if (scoreValue<= 0)
        {
            Destroy(gameObject);
        }
    }
	
	void OnDestroy()
	{
		GameplayController.UpdateArtObjects();
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && GameplayController.CanDestroyFurniture)
        {
            scoreValue -= 1;
        }
    }
	

    int CalculateTotalScore()
    {
        Furniture[] furnitureObjects = GameObject.FindObjectsOfType<Furniture>();
        int totalScore = 0;
		if(furnitureObjects.Length!=0){
			foreach (Furniture furniture in furnitureObjects)
			{
				totalScore += furniture.scoreValue;
			}
		}

        return totalScore;
    }

    void UpdateScoreText(int score)
    {
        scoreBoard.text = "Score: " + score.ToString();
    }
}
