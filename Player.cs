using Godot;
using static Godot.GD;

public partial class Player : CharacterBody3D
{
	// How fast the player moves in meters per second.
	[Export]
	public int Speed { get; set; } = 100;
	// The downward acceleration when in the air, in meters per second squared.
	[Export]
	public int FallAcceleration { get; set; } = 150;
	
	[Export]
	public int JumpImpulse { get; set; } = 80;

	[Export]
	public Node3D targetNode1;

	[Export]
	public Node3D targetNode2;

	[Export]
	public Node3D targetNode3;

	[Export]
	public Label healthLabel;

	[Export]
	public Label scoreLabel;

	[Export]
	public int startingHealth = 100;

	private int currentHealth;

	private int currentScore;

	private int currentTargetNode = 1;

	private Vector3 _targetVelocity = Vector3.Zero;

	public override void _Ready()
	{
		currentHealth = startingHealth;
		healthLabel.Text = "Health: " + currentHealth;
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthLabel.Text = "Health: " + currentHealth;
		if (currentHealth <= 0)
		{
			CurrentPlayerScoreSingleton.Instance.CurrentScore = currentScore;
			GetTree().ChangeSceneToFile("res://scenes/End_Game_Score_Scene.tscn");
		}
	}

	public void AddScore(int score)
	{
		Print("Player add score");
		currentScore += score;
		scoreLabel.Text = "Score: " + currentScore;
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = Vector3.Zero;

		if (Input.IsActionJustPressed("move_up"))
		{
			Print("Pressed Up");
			if(currentTargetNode == 0 || currentTargetNode == 1) {
				currentTargetNode++;
			}
			Print("Current Target Node: " + currentTargetNode);
		}
		if (Input.IsActionJustPressed("move_down"))
		{
			Print("Pressed Down");
			if(currentTargetNode == 1 || currentTargetNode == 2) {
				currentTargetNode--;
			}
			Print("Current Target Node: " + currentTargetNode);
		}


		if(currentTargetNode == 0) {
			// Move towards targetNode1
			direction = GlobalPosition.DirectionTo(targetNode1.Position);
		} else if(currentTargetNode == 1) {
			direction = GlobalPosition.DirectionTo(targetNode2.Position);
		}
		else if(currentTargetNode == 2) {
			direction = GlobalPosition.DirectionTo(targetNode3.Position);
		}



		if (IsOnFloor() && Input.IsActionJustPressed("jump"))
		{
			_targetVelocity.Y = JumpImpulse;
		}

		if (direction != Vector3.Zero)
		{
			direction = direction.Normalized();
			//GetNode<Node3D>("Pivot").Basis = Basis.LookingAt(direction);
		}
		
		// Ground velocity
		_targetVelocity.X = direction.X * Speed;
		_targetVelocity.Z = direction.Z * Speed;

		// Vertical velocity
		if (!IsOnFloor()) // If in the air, fall towards the floor. Literally gravity
		{
			//Print("Falling");
			_targetVelocity.Y -= FallAcceleration * (float)delta;
		} else {
			//Print("On Floor");
		}

		// Moving the character
		Velocity = _targetVelocity;
		MoveAndSlide();
		//KinematicCollision3D collision = MoveAndCollide(_targetVelocity * (float)delta);
		//if (collision != null)
		//{
		//	Print("Player collided with ", collision.GetCollider());
		//}
	}
}
