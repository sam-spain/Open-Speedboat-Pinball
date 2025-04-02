using Godot;
using System;

public class PlayerScore
{
	public int Score { get; set; }
	public string Name { get; set; }

	public PlayerScore(int score, string name)
	{
		Score = score;
		Name = name;
	}

	public override string ToString()
	{
		return $"{Name}: {Score}";
	}

	public string ToCSV()
	{
		return $"{Name},{Score}";
	}
}
