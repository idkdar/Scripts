//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using Skua.Core.Interfaces;

public class Tavern
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        StoryLine();

        Core.SetOptions(false);
    }

    public void StoryLine()
    {
        if (Core.isCompletedBefore(323))
            return;

        Story.PreLoad(this);

        //Seven Sisters 319
        Story.MapItemQuest(319, "tavern", 56, 7);

        //Warm and Furry 320
        Story.KillQuest(320, "pines", "Pine Grizzly");

        //Shell Shock 321
        Story.KillQuest(321, "pines", "Red Shell Turtle");

        //Bear Facts 322
        Story.KillQuest(322, "pines", "Twistedtooth");

        //The Spittoon Saloon 324
        Story.KillQuest(324, "pines", "Red Shell Turtle");

	    //Bear it all! 325
        Story.KillQuest(325, "pines", "Pine Grizzly");

	    //Leather Feathers 326
        Story.KillQuest(326, "pines", "Leatherwing");

	    //Follow your Nose! 327
        Story.KillQuest(327, "pines", "Leatherwing");

        //Give Snowbeard His Gold
        if (!Story.QuestProgression(323))
        {
            if (!Core.CheckInventory("Snowbeard's Gold"))
            {
                Core.EnsureAccept(327);
                Core.HuntMonster("pines", "Pine Troll");
                Core.EnsureComplete(327);
                Bot.Wait.ForPickup("Snowbeard's Gold");
            }
            Story.ChainQuest(323);
        }

    }
}