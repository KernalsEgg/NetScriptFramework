﻿using Eggstensions;



namespace ScrambledBugs.Fixes
{
	static internal class TrainingMenuText
	{
		static public System.Boolean Fix()
		{
			if (!ScrambledBugs.Patterns.Fixes.TrainingMenuText.GetPermanentActorValue)
			{
				return false;
			}
			
			Memory.SafeWrite<System.Byte>(ScrambledBugs.Offsets.Fixes.TrainingMenuText.GetPermanentActorValue, new System.Byte?[3] { null, null, 0x18 });

			return true;
		}
	}
}
