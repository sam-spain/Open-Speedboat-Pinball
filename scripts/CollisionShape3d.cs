using Godot;
using System;

public partial class CollisionShape3d : Area3D
{

	[Export]
	public Node3D playerNode;

	[Export]
	public int hello = 0;
	
	public override void _Ready()
	{
		AreaEntered += OnBodyEntered;
		
	}


	private void OnBodyEntered(Node3D body)
	{
		GD.Print("I am a box and " + body.Name + "was mean to me");
		

		Player playerScript = playerNode as Player;
		if(playerScript != null) {
			playerScript.AddScore(10);
			GD.Print("Wall of doom add score");
		}


		body.QueueFree();
		// Something hit me
	}
}
