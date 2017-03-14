using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {

	public int Id;
	public string Name;
	public decimal Money;
	public string Date;

	public Highscore(int id, string name, decimal money, string date) {
		Id = id;
		Name = name;
		Money = money;
		Date = date;
	}
}
