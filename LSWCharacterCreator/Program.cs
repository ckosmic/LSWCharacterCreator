using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSWCharacterCreator
{
	public struct Paths {
		public string PATH_CHAR;
		public string PATH_STUFF;
		public string PATH_AUDIO;
		public string PATH_CHARACTER_TXT;
		public string PATH_CHARACTER;
	}

	static class Program
	{

		public static Form1 mainForm;

		public static Paths paths;

		public static List<string> character;
		public static string formalName;
		public static string realName;
		public static string ghgFile;
		public static string ghgLrFile;
		public static string animations;
		public static List<string> sounds;
		public static string iconName;
		public static int nameId;

		public static bool dirty = false;

		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (Properties.Settings.Default.UpgradeRequired) {
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.UpgradeRequired = false;
				Properties.Settings.Default.Save();
			}

			mainForm = new Form1();
			LSWConsole.Initialize();
			Application.Run(mainForm);
		}

		public static void Initialize() {
			ghgFile = "undefined";
			ghgLrFile = "undefined";
			// Sorry to anyone who has to see this
			sounds = new List<string>();
			sounds.Add("sfx_sabre");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_chatter");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_footstep");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_grunt");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_hurt");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_die");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_shoot");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc0");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc1");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc2");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc3");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc4");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc5");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc6");
			sounds.Add("_lswccUnassigned");
			sounds.Add("sfx_misc7");
			sounds.Add("_lswccUnassigned");

			InitializePaths();
		}

		public static void InitializePaths() {
			paths.PATH_CHAR = Path.Combine(Properties.Settings.Default.lswDir, "CHARS");
			paths.PATH_STUFF = Path.Combine(Properties.Settings.Default.lswDir, "STUFF");
			paths.PATH_AUDIO = Path.Combine(Properties.Settings.Default.lswDir, "AUDIO");
		}

		public static string GetIconName(string name) {
			string newName = name.ToLower();
			if (name.Length > 27) {
				newName = name.Substring(0, 27);
			} else {
				for (int i = 0; i < 27 - name.Length; i++) {
					newName += "_";
				}
			}
			return newName + "_icon";
		}

		public static void CreateNewCharacter(string name) {
			realName = GetRealName(name);
			string newCharPath = Path.Combine(paths.PATH_CHAR, realName);
			Directory.CreateDirectory(newCharPath);

			// Add character to CHARS file
			using (StreamWriter sw = new StreamWriter(paths.PATH_CHAR + @"\CHARS.TXT", true)) {
				sw.WriteLine("\nchar_start");
				sw.WriteLine("\tdir \"" + realName + "\"");
				sw.WriteLine("\tfile \"" + realName + "\"");
				sw.WriteLine("char_end");
			}
			// Add chaarcter to COLLECTION file
			using (StreamWriter sw = new StreamWriter(paths.PATH_CHAR + @"\COLLECTION.TXT", true)) {
				sw.WriteLine("\ncollect \"" + realName + "\" buy_in_shop 0");
			}
			// Add character's formal name to language files
			nameId = -1;
			using (StreamReader sr = new StreamReader(paths.PATH_STUFF + @"\TEXT\ENGLISH.TXT")) {
				string line;
				List<string> takenNumbers = new List<string>();
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0 && line[0] != ';') {
						string number = line.Split(' ')[0];
						takenNumbers.Add(number);
					}
				}
				
				for (int i = 20; i < 2000; i++) {
					if (!takenNumbers.Contains(i.ToString())) {
						nameId = i;
						break;
					}
				}
			}
			if (nameId > -1) {
				using (StreamWriter sw = new StreamWriter(paths.PATH_STUFF + @"\TEXT\ENGLISH.TXT", true)) {
					sw.WriteLine("\n" + nameId.ToString() + " \"" + name + "\"");
				}
			}
			// Create character icon
			string iconName = GetIconName(realName);
			string iconPath = paths.PATH_STUFF + @"\ICONS\" + iconName.ToUpper() + "_PC.GSC";
			File.WriteAllBytes(iconPath, Properties.Resources.BLANKOOOOOOOOOOOOOOOO_LSWCC_ICON_PC);
			using (FileStream s = File.Open(iconPath, FileMode.Open, FileAccess.ReadWrite)) {
				s.Seek(0x157f0, SeekOrigin.Begin);
				string resourceString = iconName + "1\0" + iconName + "\0default_string\0c";
				s.Write(Encoding.ASCII.GetBytes(resourceString), 0, resourceString.Length);
			}

			// Create character TXT file and assign its name ID
			File.WriteAllText(newCharPath + @"\" + realName + ".TXT", "name_id=" + nameId.ToString() + "\r\nicon=\"" + iconName + "\"\r\n" + Properties.Resources.DefaultCharacter);

			LoadCharacterFull(newCharPath + @"\" + realName + ".TXT");

			mainForm.PopulateInformation();
		}

		public static List<string> LoadCharacter(string path) {
			List<string> ch = new List<string>();

			using (StringReader sr = new StringReader(Properties.Resources.AllProperties)) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0) {
						ch.Add(line.Split('|')[0]);
						ch.Add("");
					}
				}
			}

			using (StreamReader sr = new StreamReader(paths.PATH_CHARACTER_TXT)) {
				string line;
				bool isAnimation = false;
				int miscSounds = 0;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0) {
						string[] parts = line.Split('=');
						if (parts[0] == "anim_start") isAnimation = true;
						if (isAnimation) {
							animations += line + "\r\n";
						} else {
							if (parts[0].Substring(0, 4) == "sfx_") {
								string sfxWithoutQuotes = parts[1].Substring(1, parts[1].Length - 2);
								if (parts[0] == "sfx_misc") {
									sounds.SetStringProperty(parts[0] + miscSounds, sfxWithoutQuotes);
									miscSounds++;
								} else {
									sounds.SetStringProperty(parts[0], sfxWithoutQuotes);
								}
							} else {
								if (parts.Length == 2) {
									ch.SetStringProperty(parts[0], parts[1]);
								} else if (parts.Length == 1) {
									ch.SetBoolProperty(parts[0], true);
								}
							}
						}
						if (parts[0] == "anim_end") {
							isAnimation = false;
							animations += "\r\n";
						} else if (parts[0] == "name_id") {
							nameId = int.Parse(parts[1]);
						} else if (parts[0] == "icon") {
							iconName = parts[1].Substring(1, parts[1].Length - 2);
						}
					}
				}
			}

			return ch;
		}

		public static void LoadCharacterFull(string charTxtPath) {
			realName = Path.GetFileNameWithoutExtension(charTxtPath);
			paths.PATH_CHARACTER_TXT = charTxtPath;
			paths.PATH_CHARACTER = Path.GetDirectoryName(charTxtPath);

			character = LoadCharacter(paths.PATH_CHARACTER);

			formalName = GetFormalNameById(nameId);

			ghgFile = paths.PATH_CHARACTER + @"\" + realName + "_PC.GHG";
			ghgLrFile = paths.PATH_CHARACTER + @"\" + realName + "_LR_PC.GHG";
		}

		public static string GetFormalNameById(int id) {
			string name = "";
			using (StreamReader sr = new StreamReader(paths.PATH_STUFF + @"\TEXT\ENGLISH.TXT")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0 && line[0] != ';') {
						string[] parts = line.Split(' ');
						if (parts[0] == id.ToString()) {
							string namePart = string.Join(" ", parts, 1, parts.Length - 1);
							name = namePart.Substring(1, namePart.Length - 2);
						}
					}
				}
			}
			return name;
		}

		public static void SetFormalNameById(int id, string newName) {
			string output = "";
			using (StreamReader sr = new StreamReader(paths.PATH_STUFF + @"\TEXT\ENGLISH.TXT")) {
				string line;
				while ((line = sr.ReadLine()) != null) {
					if (line.Length > 0 && line[0] != ';') {
						string[] parts = line.Split(' ');
						if (parts[0] == id.ToString()) {
							line = id.ToString() + " \"" + newName + "\"";
						}
					}
					output += line + "\r\n";
				}
			}
			if (output.Length > 0) {
				File.WriteAllText(paths.PATH_STUFF + @"\TEXT\ENGLISH.TXT", output);
			}
		}

		public static string GenerateCharacterFile(List<string> ch, string an) {
			// Gather strings that have an extra blank line under it for organization purposes
			List<string> whitespaceStrings = new List<string>();
			using (StringReader sr = new StringReader(Properties.Resources.AllProperties)) {
				string oldLine = "";
				string line = "";
				while ((line = sr.ReadLine()) != null) {
					if (line.Length == 0) {
						whitespaceStrings.Add(oldLine.Split('|')[0]);
					}
					oldLine = line;
				}
			}

			string output = "";
			bool placedWhitespace = false;
			for (int i = 0; i < ch.Count - 1; i += 2) {
				if (ch[i + 1].Length > 0 && ch[i + 1] != "_lswccFalse") {
					output += ch[i];
					if(ch[i + 1] != "_lswccTrue")
						output += "=" + ch[i + 1];
					output += "\r\n";
					placedWhitespace = false;
					// Add sound effects after the variant line
					if (ch[i] == "variant") {
						output += "\r\n";
						for (int j = 0; j < sounds.Count - 1; j += 2) {
							if (sounds[j + 1].Length > 0 && sounds[j + 1] != "_lswccUnassigned") {
								output += (sounds[j].Contains("sfx_misc") ? "sfx_misc" : sounds[j]);
								output += "=\"" + sounds[j + 1] + "\"";
								output += "\r\n";
							}
						}
					}
				}
				if (whitespaceStrings.Contains(ch[i]) && !placedWhitespace) {
					output += "\r\n";
					placedWhitespace = true;
				}
			}
			output += "\r\n" + an;
			return output;
		}

		public static string GetRealName(string input) {
			input = input.ToUpper();
			input = input.Replace(" ", "");
			return input;
		}

		public static string GetLrPcName(string name) {
			string dir = Path.GetDirectoryName(name);
			string oldName = Path.GetFileName(name);
			oldName = oldName.Replace("PC.GHG", "LR_PC.GHG");
			return Path.Combine(dir, oldName);
		}

		public static string GetBsaName(string name) {
			string dir = Path.GetDirectoryName(name);
			string oldName = Path.GetFileName(name);
			oldName = oldName.Replace(".AN3", ".BSA");
			return Path.Combine(dir, oldName);
		}

		public static void AssignGhgFile(string from, string to) {
			if(File.Exists(from))
				File.Copy(from, to, true);
			if(File.Exists(GetLrPcName(from)))
				File.Copy(GetLrPcName(from), GetLrPcName(to), true);
		}

		public static void CopyAnimation(string fromDir, string animName, string to) {
			string animPathInCharDir = fromDir + @"\" + animName + ".AN3";
			Console.WriteLine(animPathInCharDir);
			string animPathInCommon = paths.PATH_CHAR + @"\COMMONANIMS\" + animName + ".AN3";
			if (File.Exists(animPathInCharDir)) {
				File.Copy(animPathInCharDir, to, true);
				string bsaPathInCharDir = GetBsaName(animPathInCharDir);
				if (File.Exists(bsaPathInCharDir)) {
					File.Copy(bsaPathInCharDir, GetBsaName(to), true);
				}
			} else if(File.Exists(animPathInCommon)) {
				Console.WriteLine(animName + " only exists in commonanims; skipping copy.");
			}
		}

		public static void SetDirty(bool value) {
			dirty = value;
			mainForm.Text = "LSW Character Creator - " + formalName + (value ? "*" : "");
			CheckForErrors();
		}

		public static void SaveCharacterFile(string to) {
			string output = GenerateCharacterFile(character, animations);
			File.WriteAllText(to, output);
		}

		public static void SaveCharacter() {
			SaveCharacterFile(paths.PATH_CHARACTER_TXT);
			SetDirty(false);
		}

		public static void CheckForErrors() {
			LSWConsole.ClearAllLogs();
			if (string.IsNullOrWhiteSpace(animations)) {
				LSWConsole.LogError(0, "Character contains no animations.");
			}
			if (formalName != null && formalName.Length == 0) {
				LSWConsole.LogError(1, "Character's formal name is invalid.");
			}
			if (!File.Exists(ghgFile)) {
				LSWConsole.LogError(2, "Could not locate GHG file: " + ghgFile);
			}
			if (!File.Exists(ghgLrFile)) {
				LSWConsole.LogError(3, "Could not locate LR GHG file: " + ghgLrFile);
			}
			mainForm.button8.Text = "Errors: " + LSWConsole.GetErrorCount();
		}
	}
}
