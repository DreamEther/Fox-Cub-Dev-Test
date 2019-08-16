using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    bool canOpenPack = true;
    [SerializeField] GameObject[] cards;
    [SerializeField] Transform[] spawnPoints;
    CardPackAnim cardPack;
    Canvas canvas;
    int i = 0;
    int j = 0;

	// Use this for initialization
	void Start ()
    {
        cardPack = FindObjectOfType<CardPackAnim>();
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnCards()
    {
        if (canOpenPack == true)
        {
            foreach (GameObject card in cards)
            {
                if (i <= cards.Length - 1)
                {
                    if (j <= spawnPoints.Length - 1)
                    {
                        var spawnCard = Instantiate(card, spawnPoints[j].transform.position, Quaternion.identity) as GameObject;
                        spawnCard.transform.SetParent(canvas.transform);
                        var playCardAnim = spawnCard.GetComponent<Animator>();
                        playCardAnim.Play("newCard");

                        i++;
                        j++;
                    }
                }
                
            }
        }
    }

    public void PlayPackAnim()
    {

    }
}
