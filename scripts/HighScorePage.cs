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
		Button backButton = GetNode<Button>("Back Button");
		backButton.Pressed += _OnBackButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _OnBackButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Main_Menu_Scene.tscn");
	}
}
