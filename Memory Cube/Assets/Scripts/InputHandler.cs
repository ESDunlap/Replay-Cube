using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying = false;
    private bool _isRecording = true;
    private PlayerMovement _playerController;
    private Command _button;

    private void OnEnable()
    {
        EventBus.Subscribe(EventBusTypes.REPLAY, Replay);
        _isReplaying = false;
        _isRecording = true;
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerMovement>();

        _button = new Moving(_playerController);
        _invoker.Record();
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(EventBusTypes.REPLAY, Replay);
    }

    /*void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerMovement>();

        _button = new Moving(_playerController);
        _invoker.Record();
    }*/

    void FixedUpdate()
    {

        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKey(KeyCode.A))
                _invoker.ExecuteCommand(_button, "a");

            if (Input.GetKey(KeyCode.D))
                _invoker.ExecuteCommand(_button, "d");
        }
    }

    void Replay()
    {
        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }

    /*void OnGUI()
    {
        GUILayout.Space(100);
        if (GUILayout.Button("Start Recording"))
        {
            _bikeController.ResetPosition();
            _isReplaying = false;
            _isRecording = true;
            _invoker.Record();
        }

        if (GUILayout.Button("Stop Recording"))
        {
            _bikeController.ResetPosition();
            _isRecording = false;
        }

        if (!_isRecording)
        {
            if (GUILayout.Button("Start Replay"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
                _isReplaying = true;
                _invoker.Replay();
            }
        }
    }*/
}
