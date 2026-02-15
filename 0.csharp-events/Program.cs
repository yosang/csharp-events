using System;

namespace Events
{
    // We first create a delegate
    public delegate void CustomDelegate();

    // Publisher class, connect the delegate and creates an event
    public class Button
    {
        // Then we declare an event with the event keyword and the delegate
        public event CustomDelegate OnClick;

        public void Click()
        {
            Console.WriteLine("Button was clicked");

            // If the event is not null, we invoke it
            Console.WriteLine(OnClick is null); // for debugging

            // if (OnClick is not null) OnClick();

            // Invoke executes a delegate, its equivalent to the standard () used above
            // The useful use case of it is that it allows us to do a null-conditional check before using Invoke(), which prevents crashing in cases of null
            // Invoke will only happen if its not null
            OnClick?.Invoke();

        }
    }

    // Subscriber class
    public class Screen
    {
        // This method will be added to the event delegate
        public void ShowMessage()
        {
            Console.WriteLine("Screen received the click event");
        }
    }

    public class Program
    {
        static void Main()
        {
            // We create a button and a screen instances
            Button btn = new Button();
            Screen scr = new Screen();

            // We add ShowMessage to the OnClick event
            // The subscriber operator += here is important
            // An event can have many subscribers, so we are only allowed to use +=, we cannot replace existing subscribers with =
            btn.OnClick += scr.ShowMessage;

            // When 
            btn.Click();
        }
    }
}