using Godot;
using System;

public partial class MainMenuScene : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button startButton = GetNode<Button>("StartButton");
		startButton.Pressed += _OnStartButtonPressed;
	}

	private void _OnStartButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://ground.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


}
