using Godot;
using System;

public partial class EndGameScoreScene : Control
{

	private LineEdit nameInput;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Button saveButton = GetNode<Button>("SaveButton");
		saveButton.Pressed += OnSaveButtonPressed;
		Label endScoreLabel = GetNode<Label>("EndScoreLabel");
		endScoreLabel.Text = "Your score: " + CurrentPlayerScoreSingleton.Instance.CurrentScore;
	}

	private void OnSaveButtonPressed()
	{
		GD.Print("Save button pressed");
		ScoreRepository scoreRepository = new ScoreRepository();
		string playerName = GetNode<LineEdit>("PlayerNameEntry").Text;
		int playerScore = CurrentPlayerScoreSingleton.Instance.CurrentScore;
		PlayerScore playerScoreObj = new PlayerScore(playerScore, playerName);
		scoreRepository.SaveScore(playerScoreObj);
		GD.Print("Score saved: " + playerScoreObj.ToString());
		GD.Print("Loading main menu scene");
		GetTree().ChangeSceneToFile("res://scenes/Main_Menu_Scene.tscn");
	}
}
