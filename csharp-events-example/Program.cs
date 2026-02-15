using System;

namespace Events
{
    public delegate void CustomDelegate();
    public class Button
    {
        public event CustomDelegate OnClick;

        public void Click()
        {
            Console.WriteLine("Button was clicked");

            OnClick?.Invoke();
        }
    }
    public class Screen
    {
        public void ShowMessage()
        {
            Console.WriteLine("The click event was received");
        }
    }
    public class Program
    {
        public static void Main()
        {
            Button btn = new Button();
            Screen scr = new Screen();

            btn.OnClick += scr.ShowMessage;

            btn.Click();
        }
    }


}