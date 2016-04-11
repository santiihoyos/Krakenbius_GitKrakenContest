using System;

namespace models{

[Serializable]
public class Player {

	public int id;
	public string nick;
	public int score;

	public Player (string _nick, int _score)
	{
		this.nick = _nick;
		this.score = _score;
	}
}
}
