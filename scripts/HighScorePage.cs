using Godot;
using System;
using System.Collections.Generic;

public partial class HighScorePage : Node
{

	[Export]
	Label highScoreLabel;

	[Export]
	LineEdit nameInput;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		Button backButton = GetNode<Button>("Back Button");
		backButton.Pressed += _OnBackButtonPressed;
		Button clearScoresButton = GetNode<Button>("Clear Scores Button");
		clearScoresButton.Pressed += clearScoreButtonPressed;
		displayHighScores();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void clearScoreButtonPressed() {
		GD.Print("Clear scores button pressed");
		// Clear the scores from the file
		ScoreRepository scoreRepository = new ScoreRepository();
		scoreRepository.ClearScores();
		displayHighScores();
	}

	private void _OnBackButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Main_Menu_Scene.tscn");
	}

	private void displayHighScores()
	{
		GD.Print("Displaying high scores");
		// Load the scores from the file
		ScoreRepository scoreRepository = new ScoreRepository();
		List<PlayerScore> playerScores = scoreRepository.LoadScores();
		// Display the scores in the label
		string scoreText = "";
		foreach (PlayerScore playerScore in playerScores)
		{
			GD.Print("Player: " + playerScore.Name + ", Score: " + playerScore.Score);
			scoreText += playerScore.ToString() + "\n";
		}
		// Set the text of the label to the scores
		highScoreLabel.Text = scoreText;
	}

	private void OnSaveButtonPressed()
	{
		GD.Print("Save button pressed");
		ScoreRepository scoreRepository = new ScoreRepository();
		int highScore = 12;
		GD.Print("High score: " + highScore);
		GD.Print("Name input: " + nameInput.Text);
		scoreRepository.SaveScore(new PlayerScore(highScore, nameInput.Text));
		displayHighScores();
	}
}
