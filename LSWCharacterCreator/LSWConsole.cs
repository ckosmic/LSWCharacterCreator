using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSWCharacterCreator
{
	public static class LSWConsole
	{
		private static List<LSWCCLog> errors;

		private static void l_AddError(int id, string message, LSWCCLogType type) {
			LSWCCLog existing = errors.FirstOrDefault(err => err.id == id);
			if (existing == null) {
				LSWCCLog error = new LSWCCLog();
				error.type = type;
				error.id = id;
				error.message = message;
				errors.Add(error);
			}
		}

		public static void Initialize() {
			errors = new List<LSWCCLog>();
		}

		public static void LogError(int id, string message) {
			l_AddError(id, message, LSWCCLogType.Error);
		}

		public static void LogWarning(int id, string message) {
			l_AddError(id, message, LSWCCLogType.Warning);
		}

		public static void LogDebug(int id, string message) {
			l_AddError(id, message, LSWCCLogType.Debug);
		}

		public static void ClearAllLogs() {
			errors.Clear();
		}

		public static List<LSWCCLog> GetAllLogs() {
			return errors;
		}

		public static int GetErrorCount() {
			int count = 0;
			for (int i = 0; i < errors.Count; i++) {
				if (errors[i].type == LSWCCLogType.Error) {
					count++;
				}
			}
			return count;
		}

		public static void RemoveLogsById(int id) {
			for (int i = 0; i < errors.Count; i++) {
				if (errors[i].id == id) {
					errors.RemoveAt(i);
					i--;
				}
			}
		}

	}

	public enum LSWCCLogType { 
		Debug,
		Warning,
		Error
	}

	public class LSWCCLog {
		public int id;
		public LSWCCLogType type;
		public string message;
	}
}
