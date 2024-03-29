﻿using System.Text;

namespace MusicSchoolAsp.Helpers
{
	public static class StringUtils
	{
		private static string DuplicateTicksForSql(this string s)
		{
			return s.Replace("'", "''");
		}

		/// <summary>
		/// Takes a List collection of string and returns a delimited string.  Note that it's easy to create a huge list that won't turn into a huge string because
		/// the string needs contiguous memory.
		/// </summary>
		/// <param name="list">The input List collection of string objects</param>
		/// <param name="qualifier">
		/// The default delimiter. Using a colon in case the List of string are file names,
		/// since it is an illegal file name character on Windows machines and therefore should not be in the file name anywhere.
		/// </param>
		/// <param name="insertSpaces">Whether to insert a space after each separator</param>
		/// <returns>A delimited string</returns>
		/// <remarks>This was implemented pre-linq</remarks>
		public static string ToDelimitedString(this List<string> list, string delimiter = ":", bool insertSpaces = false, string qualifier = "", bool duplicateTicksForSQL = false)
		{
			var result = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				string initialStr = duplicateTicksForSQL ? list[i].DuplicateTicksForSql() : list[i];
				result.Append((qualifier == string.Empty) ? initialStr : string.Format("{1}{0}{1}", initialStr, qualifier));
				if (i < list.Count - 1)
				{
					result.Append(delimiter);
					if (insertSpaces)
					{
						result.Append(' ');
					}
				}
			}
			return result.ToString();
		}
	}
}
