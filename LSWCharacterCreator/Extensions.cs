using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSWCharacterCreator
{
	public static class Extensions
	{
		public static string GetStringProperty(this List<string> list, string key) {
			int index = list.IndexOf(key);
			if (index >= 0)
				return list[list.IndexOf(key) + 1];
			else
				return null;
		}

		public static string[] GetStringProperties(this List<string> list, string key) {
			int minIndex = list.IndexOf(key);
			if (minIndex != -1) {
				List<string> output = new List<string>();
				while (minIndex != -1) {
					output.Add(list[minIndex + 1]);
					minIndex = list.IndexOf(key, minIndex);
				}
				return output.ToArray();
			} else {
				return null;
			}
		}

		public static bool GetBoolProperty(this List<string> list, string key) {
			int index = list.IndexOf(key);
			if (index >= 0)
				return (list[list.IndexOf(key) + 1] == "_lswccTrue");
			else
				return false;
		}

		public static void SetStringProperty(this List<string> list, string key, string value) {
			int index = list.IndexOf(key);
			if(index >= 0)
				list[index + 1] = value;
		}

		public static void SetBoolProperty(this List<string> list, string key, bool value) {
			int index = list.IndexOf(key);
			if (index >= 0)
				list[index + 1] = value ? "_lswccTrue" : "_lswccFalse";
		}

		public static int ReadInt32(this FileStream fs) {
			byte[] array = new byte[4];
			fs.Read(array, 0, 4);
			return BitConverter.ToInt32(array, 0);
		}

		public static short ReadInt16(this FileStream fs) {
			byte[] array = new byte[2];
			fs.Read(array, 0, 2);
			return BitConverter.ToInt16(array, 0);
		}
	}
}
