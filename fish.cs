using Godot;
using System;

public partial class fish: RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animSprite2D.Play();
		string[] mobTypes = animSprite2D.SpriteFrames.GetAnimationNames();
		animSprite2D.Animation = mobTypes[GD.Randi() % mobTypes.Length];
	}
	
	public void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}	
	
	public void _on_input_event(Node viewport, InputEvent @event, long shape_idx)
	{
		//GD.Print("I am an event!");
		//GD.Print(@event.AsText());		
		QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
