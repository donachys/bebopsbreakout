public class GlobalBoolReaction : Reaction
{
	public string toSet = "";
	public bool setTo = false;

    protected override void ImmediateReaction ()
    {
		GameData.GlobalBools [toSet] = setTo;
    }
}
