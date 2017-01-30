using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour {

	GameObject CrosshairActive;
	GameObject CrosshairInactive;
	Text Money;
	TextMesh MoneyTill;
	Text Talk;
	Text Inventory;

	private string moneyText;
	private string talkText;
	private string inventoryText;
	private int moneyPay;

	// Use this for initialization
	void Start () {
		CrosshairActive = GameObject.Find ("Crosshair active");
		CrosshairInactive = GameObject.Find ("Crosshair inactive");
		Money = GameObject.Find ("Money Text").GetComponent<Text>();
		MoneyTill = GameObject.Find ("Money Text Kasse").GetComponent<TextMesh>();
		Talk = GameObject.Find ("Talk Text").GetComponent<Text>();
		Inventory = GameObject.Find ("Inventory Text").GetComponent<Text>();

		moneyText = "0 $";
		talkText = Talk.text = "";
		inventoryText = Inventory.text = "";

		moneyPay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// ReceiveMoney (1);

	
	}

	/*
	 * Change Crosshair active/inactive
	 */
	void ToggleCrosshair() {
		if(CrosshairActive.activeSelf) {
			CrosshairActive.SetActive (false);
			CrosshairInactive.SetActive (true);
		} else {
			CrosshairActive.SetActive (true);
			CrosshairInactive.SetActive (false);
		}
	}

	/*
	 * Change Crosshair to active
	 */
	public void ActivateCrosshair() {
		CrosshairActive.SetActive (true);
		CrosshairInactive.SetActive (false);		
	}

	/*
	 * Change Crosshair to inactive
	 */
	public void DeactivateCrosshair() {
		CrosshairActive.SetActive (false);
		CrosshairInactive.SetActive (true);		
	}

	public void ReceiveMoney(int cash) {
		moneyPay += cash;
		moneyText = moneyPay + " $";
		Money.text = moneyText;
		MoneyTill.text = moneyText;
	}

	public void ReceiveChat(string chat) {
		talkText = chat;
		Talk.text += talkText;
	}

	public void ReceiveItem(string item) {
		inventoryText = item;
		Inventory.text = inventoryText;
	}
}
