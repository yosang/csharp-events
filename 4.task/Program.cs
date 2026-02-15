namespace Task
{
    public class Diagnostic
    {
        public event EventHandler? TestCompleted;

        // Raises the event
        public void StartTest()
        {
            Console.WriteLine("Starting test");
            OnTestCompleted(EventArgs.Empty);
        }

        // Handles the event
        protected virtual void OnTestCompleted(EventArgs e)
        {
            TestCompleted?.Invoke(this, e);
        }
    }

    public class MyProgram
    {
        public static void Main()
        {
            Diagnostic myTest = new Diagnostic();

            myTest.TestCompleted += diag_EventHandler;

            myTest.StartTest();
        }

        // Event Handler
        // Signature must match the delegate
        // object sender, EventArgs e
        public static void diag_EventHandler(object? sender, EventArgs e)
        {
            Console.WriteLine("Test is complete");
        }
    }
}