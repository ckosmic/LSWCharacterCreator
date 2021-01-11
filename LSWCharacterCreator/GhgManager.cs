using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSWCharacterCreator
{
	public struct GHGParameters
	{
		public int texCount;
		public long[] texOffsets;
		public int[] texSizes;
		public byte[][] texData;
		public int[] texWidths;
		public int[] texHeights;
	}

	public class GhgManager
	{
		public static void LoadModel(string path, out GHGParameters ghg) {
			using (FileStream fs = File.OpenRead(path)) {
				ghg = new GHGParameters();
				Stack<long> stack = new Stack<long>();
				int NU20 = fs.ReadInt32();
				if (NU20 == 0x3032554e) {

				} else {
					fs.Seek(NU20 + 0x4, SeekOrigin.Begin);
					fs.Seek(0x4, SeekOrigin.Current);
				}

				fs.Seek(0x18, SeekOrigin.Current);
				int offsetGSNH = fs.ReadInt32();
				long absOffsetGSNH = fs.Position + offsetGSNH;

				int numberImages = 0;
				fs.Seek(absOffsetGSNH, SeekOrigin.Begin);
				numberImages = fs.ReadInt32();
				long absOffsetImagesMeta = fs.Position + fs.ReadInt32();

				fs.Seek(absOffsetImagesMeta, SeekOrigin.Begin);
				if (NU20 == 0x3032554e) {

				} else {
					int numberRealImages = 0;
					for (int i = 0; i < numberImages; i++) {
						int tmp = fs.ReadInt32();
						stack.Push(fs.Position);
						fs.Seek(tmp - 4, SeekOrigin.Current);
						int width = fs.ReadInt32();
						int height = fs.ReadInt32();
						if (width != 0 && height != 0)
							numberRealImages++;
						fs.Seek(stack.Pop(), SeekOrigin.Begin);
					}
					fs.Seek(6, SeekOrigin.Begin);
					ghg.texCount = numberRealImages;
					ghg.texOffsets = new long[numberRealImages];
					ghg.texSizes = new int[numberRealImages];
					ghg.texData = new byte[numberRealImages][];
					ghg.texWidths = new int[numberRealImages];
					ghg.texHeights = new int[numberRealImages];
					for (int i = 0; i < numberRealImages; i++) {
						long pos = fs.Position;
						int width = fs.ReadInt32();
						int height = fs.ReadInt32();
						fs.ReadInt32();
						fs.ReadInt32();
						fs.ReadInt32();
						int size = fs.ReadInt32();
						ghg.texOffsets[i] = pos;
						ghg.texSizes[i] = size;
						ghg.texWidths[i] = width;
						ghg.texHeights[i] = height;
						Console.WriteLine("Image " + i + " found at " + pos.ToString("X8") + ": width = " + width + ", height = " + height);
						ghg.texData[i] = new byte[size];
						fs.Read(ghg.texData[i], 0, size);
					}
				}
			}
		}

		public static bool OverwriteTexture(int index, GHGParameters ghg, string ghgPath, string ddsPath) {
			using (FileStream fr = File.OpenRead(ddsPath)) {
				using (FileStream fw = File.OpenWrite(ghgPath)) {
					byte[] array = new byte[ghg.texSizes[index]];
					try {
						fr.Read(array, 0, array.Length);
						try {
							fw.Seek(ghg.texOffsets[index] + 24, SeekOrigin.Begin);
							fw.Write(array, 0, array.Length);
							Console.WriteLine("Successfully overwrote image.");
							return true;
						} catch (Exception e) {
							Console.WriteLine("Failed to write to GHG file.");
							throw e;
						}
					} catch (Exception e) {
						Console.WriteLine("Failed to read DDS file.");
						throw e;
					}
				}
			}
		}

		public static bool OverwriteTextureData(int index, GHGParameters ghg, string ghgPath, byte[] data) {
			using (FileStream fw = File.OpenWrite(ghgPath)) {
				try {
					fw.Seek(ghg.texOffsets[index] + 24, SeekOrigin.Begin);
					fw.Write(data, 0, data.Length);
					Console.WriteLine("Successfully overwrote image.");
					return true;
				} catch (Exception e) {
					Console.WriteLine("Failed to write to GHG file.");
					throw e;
				}
			}
		}
	}
}
