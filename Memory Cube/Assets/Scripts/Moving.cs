using UnityEngine;

public class Moving : Command
{
    private PlayerMovement _controller;

    public Moving(PlayerMovement controller)
    {
        _controller = controller;
    }

    public override void Execute(string input)
    {
        _controller.Move(input);
    }
}
