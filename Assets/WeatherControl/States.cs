public class States
{
    public enum WEATHERTYPES
    {
        SUNNY, RAINY, SNOWY, NIGTH, DAY
    }
    public enum EVENT
    {
        ENTER,UPDATE,EXIT
    }
    public WEATHERTYPES name;
    protected EVENT stage;
    protected States nextState;

    public States() {
        stage=EVENT.ENTER;

    }
    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }
    public States Procces()
    {
        if(stage==EVENT.ENTER) { Enter(); }
        if(stage==EVENT.UPDATE ) { Update(); }
        if(stage==EVENT.EXIT) {  Exit(); return nextState; }
        else { return this; }
    }
}
