using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    public Slider fuelSlide;
    public PlayerController player;
    // Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        if(player != null)
        {
            fuelSlide.maxValue = player.fuel;
        }
	}
	
	// Update is called once per frame
	void Update () {
        fuelSlide.value = player.fuel;
	}
}
