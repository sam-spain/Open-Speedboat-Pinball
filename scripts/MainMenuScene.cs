using Godot;
using System;

public partial class MainMenuScene : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button startButton = GetNode<Button>("StartButton");
		startButton.Pressed += _OnStartButtonPressed;
		Button highScoresButton = GetNode<Button>("High Scores Scene Button");
		highScoresButton.Pressed += _OnHighScoresButtonPressed;
	}

	private void _OnStartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://ground.tscn");
	}

	private void _OnHighScoresButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/ScoreScene.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


}
