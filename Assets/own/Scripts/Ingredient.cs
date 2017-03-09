using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {
	
	public decimal Amount;
	public decimal Price;
	public Color lColor;

	public Ingredient(decimal amount, decimal price, Color color){
		Amount = amount;
		Price = price;
		lColor = color;
	}
}