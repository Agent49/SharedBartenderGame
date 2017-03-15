using System.Collections.Generic;

public class SaveData {
	
	public List<Highscore> Highscores { get; set; }

	public SaveData() {
		Highscores = new List<Highscore> ();
	}
}

public class Highscore {

	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Money { get; set; }
	public string Date { get; set; }

	public Highscore(int id, string name, decimal money, string date) {
		Id = id;
		Name = name;
		Money = money;
		Date = date;
	}
}