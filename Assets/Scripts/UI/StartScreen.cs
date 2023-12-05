using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction StartButtonClick;

    protected override void OnButtonClick()
    {
        StartButtonClick?.Invoke();
    }
}
