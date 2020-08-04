using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
	

	void Start()
	{
	}

	void OnMouseEnter()
	{
		GetComponent<Image>().material.color = Color.red;
	}

	void OnMouseExit()
	{
		GetComponent<Image>().material.color = Color.black;
	}
}
