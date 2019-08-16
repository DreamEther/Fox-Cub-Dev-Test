using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverBounce : MonoBehaviour, IPointerEnterHandler
{

    private Animator buttonAnim;
    private Animator cardPackAnim;
    CardPackAnim cardPackObject;

	// Use this for initialization
	void Start ()
    {    
        buttonAnim = GetComponent<Animator>();
        cardPackObject = FindObjectOfType<CardPackAnim>();
        cardPackAnim = cardPackObject.GetComponent<Animator>();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonAnim.Play("Bounce");
        buttonAnim.SetBool("IsHovering", true);
        cardPackAnim.Play("BreakOpen");
    }

   public void OnPointerExit(PointerEventData eventData)
    {
        buttonAnim.SetBool("IsHovering", false);
        buttonAnim.Play("Idle");
    }

}
