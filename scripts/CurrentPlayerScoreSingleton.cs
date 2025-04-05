using Godot;
using System;

public class CurrentPlayerScoreSingleton
{
	// Stores the current player score using the singleton pattern
	private static CurrentPlayerScoreSingleton instance;
	public static CurrentPlayerScoreSingleton Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new CurrentPlayerScoreSingleton();
			}
			return instance;
		}
	}
	public int CurrentScore { get; set; } = 0;
}
