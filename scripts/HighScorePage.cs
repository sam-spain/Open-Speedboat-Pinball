using Godot;
using System;

public partial class HighScorePage : Node
{

	[Export]
	Label highScoreLabel;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreRepository scoreRepository = new ScoreRepository();
		int highScore = scoreRepository.LoadScore();
		highScoreLabel.Text = "High Score: " + highScore;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
