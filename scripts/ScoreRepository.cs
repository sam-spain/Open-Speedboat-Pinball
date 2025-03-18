using Godot;
using System;
using System.IO;

public class ScoreRepository
{

	public void SaveScore(int score)
	{
		// Save the score to a file
		GD.Print("Score saved: " + score);
		string savePath = "user://SaveData";
		try
		{
			using Godot.FileAccess file = Godot.FileAccess.Open(savePath, Godot.FileAccess.ModeFlags.Write);
			file.StoreLine(score.ToString());
		}
		catch (Exception e)
		{
			GD.PrintErr("Failed to save score: " + e.Message);
		}

	}

	public int LoadScore()
	{
		// Load the score from a file
		string savePath = "user://SaveData";
		try
		{
			using Godot.FileAccess file = Godot.FileAccess.Open(savePath, Godot.FileAccess.ModeFlags.Read);
			string scoreString = file.GetLine();
			return int.Parse(scoreString);
		}
		catch (Exception e)
		{
			GD.PrintErr("Failed to load score: " + e.Message);
			return 0;
		}
	}
}
