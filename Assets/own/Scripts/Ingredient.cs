using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {
	
	public decimal Volume;
	public decimal Price;
	public Color lColor;

	public Ingredient(decimal volume, decimal price, Color color){
		Volume = volume;
		Price = price;
		lColor = color;
	}
}