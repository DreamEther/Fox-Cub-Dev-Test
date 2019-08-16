using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    bool canOpenPack = true;

    [SerializeField] GameObject[] cards;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform claimPile;
    [SerializeField] AudioClip rewardSound;
    GameObject spawnCard;
    [SerializeField] TextMeshProUGUI newText;
    GameObject openPackGameObject;

   [SerializeField] bool alreadyClicked = false;
    bool playRewardSound = true;
    CardPackAnim cardPack;
    Canvas canvas;
    int i = 0;
    int j = 0;

	// Use this for initialization
	void Start ()
    {
        cardPack = FindObjectOfType<CardPackAnim>();
        canvas = GetComponent<Canvas>();
        openPackGameObject = GameObject.Find("OpenPackText");
        
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void SpawnCards()
    {
        Destroy(cardPack.gameObject, 1);
        newText.text = "Claim Cards";
        if (playRewardSound)
        {
            AudioSource.PlayClipAtPoint(rewardSound, transform.position);
            playRewardSound = false;
         
        }
        if (!alreadyClicked)
        {
            foreach (GameObject card in cards)
            {
                if (i <= cards.Length - 1)
                {
                    if (j <= spawnPoints.Length - 1)
                    {
                        spawnCard = Instantiate(card, spawnPoints[j].transform.position, Quaternion.identity) as GameObject;
                        spawnCard.transform.SetParent(canvas.transform);
                        Animator playCardAnim = spawnCard.GetComponent<Animator>();
                        playCardAnim.Play("CardAnim");

                        i++;
                        j++;
                        
                    }
                }


            }
        }
      
    }

    public void ClaimCards() // I couldn't quite figure out how to place two separate events on one button. So this does nothing atm. I wanted a second click to register a separate 'Claim Cards' event.
    {
        alreadyClicked = true;
        if (alreadyClicked == true)
        {
            spawnCard.transform.position = claimPile.transform.position;
        }
    }

    public void PlayPackAnim()
    {

    }
}
