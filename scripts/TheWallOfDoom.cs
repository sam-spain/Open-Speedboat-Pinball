using Godot;
using System;


public partial class TheWallOfDoom : Node3D
{

	[Export]
	public Node3D playerNode;

	public override void _Ready()
	{
	}

	public void chickenHitWall(int score) {
		Player playerScript = playerNode as Player;
		if(playerScript != null) {
			playerScript.AddScore(score);
			GD.Print("Wall of doom add score");
		}
	}
}
