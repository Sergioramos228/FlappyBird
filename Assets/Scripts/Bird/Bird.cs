using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        ChangeStateMover(false);
    }

    private void ChangeStateMover(bool state)
    {
        _mover.enabled = state;
    }

    public void ResetPlayer()
    {
        _score = 0;
        ChangeStateMover(true);
        _mover.ResetBird();
        ScoreChanged?.Invoke(_score);
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        ChangeStateMover(false);
        GameOver?.Invoke();
    }
}
