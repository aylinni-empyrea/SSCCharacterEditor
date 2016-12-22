using System;
using TShockAPI;
using TShockAPI.DB;

namespace SSCCharacterEditor.Tools
{
	internal static class Database
	{
		internal static bool TryCommit(string qs)
		{
			try
			{
				using (var reader = TShock.DB.QueryReader(qs))
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				TShock.Log.Error(ex.ToString(), "\n", ex.StackTrace);
				return false;
			}
		}
	}
}