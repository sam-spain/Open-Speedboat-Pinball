using Godot;
using System;
using System.Collections.Generic;
using System.IO;

public class ScoreRepository
{

	public void SaveScore(PlayerScore playerScore) {
		// Save score as new line in file
		GD.Print("Score saved: " + playerScore.Score);
		string savePath = "user://SaveData";
		try
		{
			using Godot.FileAccess file = Godot.FileAccess.Open(savePath, Godot.FileAccess.ModeFlags.ReadWrite);
			{
				// Seek to the end of the file to append
				file.SeekEnd();
				file.StoreLine(playerScore.ToCSV());
			}
		}
		catch (Exception e)
		{
			GD.PrintErr("Failed to save score: " + e.Message);
		}
	}

	public List<PlayerScore> LoadScores()
	{
		GD.Print("Loading scores...");
		List<string> scores = new List<string>();
		string savePath = "user://SaveData";
		try
		{
			using Godot.FileAccess file = Godot.FileAccess.Open(savePath, Godot.FileAccess.ModeFlags.Read);
			while (!file.EofReached())
			{
				GD.Print("Reading line...");
				scores.Add(file.GetLine());
			}
		}
		catch (Exception e)
		{
			GD.PrintErr("Failed to load scores: " + e.Message);
		}
		
		List<PlayerScore> playerScores = new List<PlayerScore>();
		foreach (string score in scores)
		{
			string[] parts = score.Split(',');
			if (parts.Length == 2)
			{
				string name = parts[0].Trim();
				int value = int.Parse(parts[1].Trim());
				playerScores.Add(new PlayerScore(value, name));
			}
		}
		// Sort the scores in descending order
		playerScores.Sort((x, y) => y.Score.CompareTo(x.Score));
		// Limit to top 10 scores
		if (playerScores.Count > 10)
		{
			playerScores = playerScores.GetRange(0, 10);
		}
		return playerScores;
	}
}
