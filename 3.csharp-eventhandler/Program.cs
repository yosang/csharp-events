using System;

namespace Events
{
    public class Button
    {
        // The EventHandler is a built-in delegate, we can use it directly
        // A method that handles this delegate must have:
        // Sender - who raised the event
        // EventArgs e - Extra data (arguments)
        // Adding a null-conditional removes the warning, because an EventHandler starts as null until someone subscribes
        public event EventHandler? OnClick;

        public void Click()
        {
            Console.WriteLine("Button was clicked");

            // This refers to the current instance reference that raised this event
            // We pass this, and EventArgs.Empty which represents empty data, but not null
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Screen
    {
        // The signature is the same as the delegate - important
        // sender can be null, so we add a null-conditional
        public void ShowMessage(object? sender, EventArgs e)
        {
            Console.WriteLine("Screen received the click event");

            // Notice that the sender is the Button
            Console.WriteLine($"The instance that raised this event was {sender?.GetType().Name}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Button btn = new Button();
            Screen scr = new Screen();

            // We subscribe
            btn.OnClick += scr.ShowMessage;

            btn.Click();
        }
    }
}