# C# Events
A simple demonstration of the `publisher - subscriber` pattern using C# events.

An event is simply something that happens, a mouse click for example. This event can be broadcasted to any class that subscribes to it.

This is useful for:
- **UI** - Button clicks, key presses etc.
- **Notifications**: Sending alerts when something is done uploading.
- **Decoupling** - One module can signal another.

# How it works
1. Design decisions
    - We have to decide whether to create a custom delegate or use a built-in one like the `System.EventHandler`.
2. Publisher class
    - Declares an event using the delegate we decided on earlier.
    - Declares a method that can invoke the event if it has .subscribers (not null).
3. Subscriber class
    - Declares a method to add when subscribing to an event.
    - This method will fire when an event is raised. 

## In short:
1. Delegates
    - A delegate is simply an object that holds a reference to a method.
    - A delegate can be defined with a specific signature, which whoever uses the delegate must match.
        - In this case, the `Event Handler` of the Subscriber class, must match the delegate signature.
2. Events
    - Events use delegates (custom or built-in)
        - the common preferred built-in to use is `EventHandler`, which takes a `sender` object (often used with `this` to signal who raised the event) and `EventArgs`, often used as (`EventArgs.Empty` to pass an empty object)
    - An event is declared within a class with the `event` keyword and the delegate to use for this event.
    - Multiple subscribers can be subscribed to the same event.
3. Subscribers
    - Nothing fancy about subscribers, they are simply methods within a class added to a `Publisher's` event.
    - To add a subscriber to an event we add them with `+=` or remove them with `-=`.
        - Since delegates can multicast, all subscribers will be invoked once an event is raised.
    - If we intend to use a method as a subscriber, it must the delegate signature used for the `Publisher’s` event. 

# Simple simulation
We will simulate this: 
- A button is pressed
- An event is raised
- Another class reacts.

# Examples
We are providing examples using `custom delegates` and the built-in `EventHandler`.

# Task
We will implement:
- Publisher - Diagnostic (using the built-in `EventHandler`).
    - Event - TestCompleted.
    - StartTest - Raises an event through `OnTestCompleted` passing `EventArgs e` as empty.
    - OnTestCompleted - Protected virtual which takes `EventArgs e` and `Invokes` the delegate with `this` and `e`.
- Subscriber - MyProgram
    - Handles the subscription.
    - EventHandler - Give it any name.

