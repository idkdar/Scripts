/*
name: Vampire REP
description: This script will farm Vampire reputation to rank 10.
tags: vampire, rank, rep, reputation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;
public class VampireREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public Core13LoC LOC = new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        DoRep();

        Core.SetOptions(false);
    }

    public void DoRep()
    {
        LOC.Wolfwing();
        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);
        Farm.VampireREP();

    }
}
