using Godot;
using System;

public partial class main : Node
{
	[Export]
	public PackedScene FishScene;
	
	public int Score;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 NewGame();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void GameOver()
	{
	}

	public void NewGame()
	{
		Score = 0;
		GetNode<Timer>("StartTimer").Start();
		GetNode<Timer>("FishTimer").Start();
	}
	
	public void OnFishTimerTimeout()
	{
		// Note: Normally it is best to use explicit types rather than the `var`
		// keyword. However, var is acceptable to use here because the types are
		// obviously Fish and PathFollow2D, since they appear later on the line.

		// Create a new instance of the Fish scene.
		var fish = FishScene.Instantiate<fish>();

		// Choose a random location on Path2D.
		var fishSpawnLocation = GetNode<PathFollow2D>("FishPath/FishSpawnLocation");
		fishSpawnLocation.ProgressRatio = GD.Randf();

		// Set the fish's direction perpendicular to the path direction.
		float direction = fishSpawnLocation.Rotation + Mathf.Pi / 2;

		// Set the fish's position to a random location.
		fish.Position = fishSpawnLocation.Position;

		// Add some randomness to the direction.
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		fish.Rotation = direction;

		// Choose the velocity.
		var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
		fish.LinearVelocity = velocity.Rotated(direction);

		// Spawn the fish by adding it to the Main scene.
		AddChild(fish);
	}
}
