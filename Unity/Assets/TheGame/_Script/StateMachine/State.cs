// Base class for the states
public abstract class State
{
    // A reference for the player
    protected Player player;

    // Abstract method, child classes are forced to implement it
    public abstract void Tick();

    // Virtual methods, child classes are not obligated to implement them
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    // Constructor of the base class
    public State(Player p)
    {
        this.player = p;
    }
}
