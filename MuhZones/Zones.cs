using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Nanook.QueenBee.Parser;
using DDS;
using System.IO;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;
using Bit = System.BitConverter;
using System.Drawing.Imaging;
//using System.Drawing.Imaging;

public class Zones : IDisposable
{
	public static uint Eswap(uint value)
	{
		return ((value & 0xFF) << 24) |
				((value & 0xFF00) << 8) |
				((value & 0xFF0000) >> 8) |
				((value & 0xFF000000) >> 24);
	}
	public static int Eswap(int value)
	{
		return unchecked((int)
				(((uint)(value & 0xFF) << 24) |
				((uint)(value & 0xFF00) << 8) |
				((uint)(value & 0xFF0000) >> 8) |
				((uint)(value & 0xFF000000) >> 24)));
	}
	public static ushort Eswap(ushort value)
	{
		return (ushort)(((value & 0xFF) << 8) |
			((value & 0xFF00) >> 8));
	}

	PakFormat pf;
	PakEditor pe;
	public List<RawImg> images;
	public List<Font> fonts;
	public GFX gfx;
	public Scene scn;
	// mightve overwrote sprite_missing from FastGH3, oops lol
	public static RawImg nullimage = new RawImg(Image.FromFile("sprite_missing.png"));

	// i still dont know how this dispose thing works
	// but memory was getting freed, so
	public void Dispose()
	{
		foreach (RawImg i in images)
			i.Dispose();
	}

	public Zones(string fname, bool noTexRequired = false)
	{
		string pak = fname.Replace(".pab", ".pak");
		string pab = fname.Replace(".pak", ".pab");
		pf = new PakFormat(pak, pab/*whatever*/, Program.folder+"dbg.pak.xen", PakFormatType.PC);
		pe = new PakEditor(pf, false);

		images = new List<RawImg>();
		fonts = new List<Font>();

		byte[] tex = null, scn = null;
		foreach (PakHeaderItem f in pe.Headers.Values)
		{
			Program.loadtext("Reading " + Program.keyWithDebug(f.FullFilenameQbKey) + "\r");
			switch (f.FileType.Crc)
			{
				// cringe C# "constant value expected" STFU I DO WHAT I WANT
				case 0xDAD5E950: // .img
					{
						RawImg i = new RawImg(pe.ExtractFileToBytes(f.Filename));
						i.Name = Program.keyWithDebug(f.FullFilenameQbKey);
						images.Add(i);
						break;
					}
				case 0x8BFA5E8E: // .tex
					{
						if (f.FullFilenameQbKey == 0x406D171F)
							tex = pe.ExtractFileToBytes(f.Filename);
						break;
					}
				case 0x2C3B5ADC: // .scn
					{
						if (f.FullFilenameQbKey == 0xE7AC134D)
							scn = pe.ExtractFileToBytes(f.Filename);
						break;
					}
				case 0x7E1ABC70: // .fnt
					{
						Font ff = new Font(pe.ExtractFileToBytes(f.Filename));
						ff.Name = Program.keyWithDebug(f.FullFilenameQbKey);
						fonts.Add(ff);
						break;
					}
			}
		}
		if (!noTexRequired)
		{
			if (tex == null || scn == null)
				throw new ArgumentNullException("Failed to get required global_gfx files.");
			Console.WriteLine("\nLoading SCN");
			this.scn = new Scene(scn);
			Console.WriteLine("Loading TEX");
			gfx = new GFX(tex);
			Console.WriteLine("Done loading zone");
		}
	}
	public RawImg GetImage(QbKey name)
	{
		for (int i = 0; i < images.Count; i++)
		{
			if (images[i].Name.Crc == name.Crc)
			{
				if (images[i].Name.HasText)
					if (images[i].Name.Text != images[i].Name.Text)
						// for overlap, whenever that will happen with textures
						// and on FastGH3 (nervous expression)
						continue;
				return images[i];
			}
		}
		return nullimage;
	}
	public Font GetFont(QbKey name)
	{
		for (int i = 0; i < fonts.Count; i++)
		{
			if (fonts[i].Name.Crc == name.Crc)
			{
				if (fonts[i].Name.HasText)
					if (fonts[i].Name.Text != fonts[i].Name.Text)
						continue;
				return fonts[i];
			}
		}
		//throw new Exception("That font cannot be found.");
		return null;
	}

	[DefaultProperty("Name")]
	public class RawImg : IDisposable
	{
		private const int _magic = 0x0A281100;
		public void Dispose()
		{
			Image.Dispose();
			rawimg = null;
		}
		private struct Head
		{
			public uint magic;
			public uint key; // null on .imgs, named on .tex
			public ushort w_scale, h_scale; // one of these scales the texture
			public ushort unk0; // 00 01
			public ushort w_clip, h_clip; // and one crops it by the looks of it
			public ushort unk1; // 00 01
			// these flags probably dont do anything on PC
			// they appear interchangeably on certain textures
			// but still consistent with DXT1 textures on some
			// with the 04 01 and 08 05
			public byte mipmaps, bpp, compression, unk2;
			public uint unk3;
			public uint off_start, size;
			// i dont remember
			// if these did anything either
			// but just be consistent anyway,
			// like with imggen
			public uint unk4;
		}
		private Head head;
		public ushort widthScale
		{
			get { return head.w_scale; }
			set { head.w_scale = value; }
		}
		public ushort widthClip
		{
			get { return head.w_clip; }
			set { head.w_clip = value; }
		}
		public ushort heightScale
		{
			get { return head.h_scale; }
			set { head.h_scale = value; }
		}
		public ushort heightClip
		{
			get { return head.h_clip; }
			set { head.h_clip = value; }
		}
		private byte[] rawimg;
		private uint magic
		{
			get { return Eswap(Bit.ToUInt32(rawimg, 0)); }
		}
		private bool isDDS
		{
			get { return magic == 0x44445320; }
		}
		[DisplayName("Type"), Category("Data")]
		public string ext
		{
			get
			{
				if (isDDS)
					return "dds";
				else
				{
					if ((magic & 0xFFFF0000) == 0x424d0000)
						return "bmp"; // because why
					switch (magic)
					{
						case 0x89504e47:
							return "png";
						case 0xffd8ffe0:
							return "jpg";
						default:
							return "";
					}
				}
			}
		}
		[Category("Data"), ReadOnly(true)]
		public Image Image
		{
			get
			{
				if (isDDS)
					return DDSImage.Load(rawimg).Images[0];
				return Image.FromStream(new MemoryStream(rawimg), true);
			}
			set
			{
				setHead();
				head.w_scale = (ushort)value.Width;
				head.h_scale = (ushort)value.Height;
				head.w_clip = (ushort)value.Width;
				head.h_clip = (ushort)value.Height;
				//ImageFormat fmt = img.RawFormat;
				try
				{
					value.Save(new MemoryStream(rawimg), value.RawFormat);
				}
				catch
				{
					// why
					value.Save(new MemoryStream(rawimg), ImageFormat.Png);
				}
				head.size = (uint)rawimg.Length;
			}
		}
		public QbKey Name
		{
			get { return Program.keyWithDebug(head.key); }
			set { head.key = value.Crc; }
		}
		[Category("Data"), DisplayName("Name")]
		public string NameStr
		{
			get {
				return Program.GetDebugName(head.key);
			}
			set {
				if (System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9a-fA-F]{8}$"))
					value = Program.GetDebugName(uint.Parse(value, System.Globalization.NumberStyles.HexNumber));
				QbKey q = QbKey.Create(value);
				try
				{
					Program.DebugNames.Add(q.Crc, q.Text);
				}
				catch { }
				head.key = q.Crc;
			}
		}
		private void setHead()
		{
			head.magic = _magic;
			head.unk0 = 1;
			head.unk1 = 1;
			head.mipmaps = 1;
			head.bpp = 8;
			head.compression = 5;
			head.off_start = 0x28;
		}
		public byte[] Save()
		{
			byte[] exported = new byte[0x28 + rawimg.Length];
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);
			bw.Write(Eswap(_magic));
			bw.Write(0);
			bw.Write(Eswap(head.w_scale));
			bw.Write(Eswap(head.h_scale));
			bw.Write(Eswap(head.unk0));
			bw.Write(Eswap(head.w_clip));
			bw.Write(Eswap(head.h_clip));
			bw.Write(Eswap(head.unk1));
			bw.Write(Eswap(head.mipmaps));
			bw.Write(Eswap(head.bpp));
			bw.Write(Eswap(head.compression));
			bw.Write(Eswap(head.unk2));
			bw.Write(Eswap(head.unk3));
			bw.Write(Eswap(head.off_start));
			bw.Write(Eswap(head.size));
			bw.Write(Eswap(head.unk4));
			//bw.Write(rawimg);
			bw.Close();
			Array.Copy(ms.ToArray(), exported, 0x28);
			ms.Close();
			Array.Copy(rawimg, 0, exported, 0x28, rawimg.Length);
			return exported;
		}
		public RawImg(Image img)
		{
			setHead();
			head.w_scale = (ushort)img.Width;
			head.h_scale = (ushort)img.Height;
			head.w_clip = (ushort)img.Width;
			head.h_clip = (ushort)img.Height;
			//ImageFormat fmt = img.RawFormat;
			MemoryStream ms = new MemoryStream();
			img.Save(ms, img.RawFormat);
			rawimg = ms.ToArray();
			head.size = (uint)rawimg.Length;
		}
		public RawImg(DDSImage dds, byte[] data)
		{
			setHead();
			Image img = dds.Images[0];
			head.w_scale = (ushort)img.Width;
			head.h_scale = (ushort)img.Height;
			head.w_clip = (ushort)img.Width;
			head.h_clip = (ushort)img.Height;
			rawimg = data;
			head.size = (uint)data.Length;
		}
		public RawImg(byte[] img) // lazy copy again lol
		{
			if (Eswap(Bit.ToUInt32(img,0)) != _magic &&
				Eswap(Bit.ToUInt32(img,0)) != 0x0A281102 && // appears on fonts
				Eswap(Bit.ToUInt32(img,0)) != 0x0A280200) // kill me
			{
				Console.WriteLine("fail "+Eswap(Bit.ToUInt32(img,0)).ToString("X8") + ", expected "+_magic.ToString("X8"));
				head.magic = 0xBAADF00D; // indicate that this isn't usable
				// JUST SKIP THE FILE IF IT DOESN'T HAVE THIS MAGIC
				// FROM THE ZONES CONSTRUCTOR
				return;
			}
			head.key = Eswap(Bit.ToUInt32(img, 4));
			head.w_scale = Eswap(Bit.ToUInt16(img, 0x8));
			head.h_scale = Eswap(Bit.ToUInt16(img, 0xA));
			head.unk0 = Eswap(Bit.ToUInt16(img, 0xC));
			head.w_clip = Eswap(Bit.ToUInt16(img, 0xE));
			head.h_clip = Eswap(Bit.ToUInt16(img, 0x10));
			head.unk1 = Eswap(Bit.ToUInt16(img, 0x12));
			head.mipmaps = img[0x14];
			head.bpp = img[0x15];
			head.compression = img[0x16];
			head.unk2 = img[0x17];
			head.unk3 = Eswap(Bit.ToUInt32(img, 0x18));
			head.off_start = Eswap(Bit.ToUInt32(img, 0x1C));
			head.size = Eswap(Bit.ToUInt32(img, 0x20));
			if (head.size + 0x1C != img.Length)
				head.size = (uint)img.Length - 0x28; // i must die
			head.unk4 = Eswap(Bit.ToUInt32(img, 0x24));
			// what system is gonna run this with little endian
			rawimg = new byte[head.size];
			Array.Copy(img, head.off_start, rawimg, 0, head.size);
		}
		public static RawImg MakeFromRaw(string fname)
		{
			byte[] raw = File.ReadAllBytes(fname);
			if (Bit.ToUInt32(raw, 0) == 0x20534444)
			{
				// stupid
				return new RawImg(DDSImage.Load(fname), raw);
			}
			else if (Bit.ToUInt32(raw, 0) == Eswap(_magic))
			{
				return new RawImg(raw);
			}
			else
				return new RawImg(Image.FromFile(fname));
		}
		public void Export(string fname)
		{
			string a = Path.GetExtension(fname).Substring(1);
			if (a == ext)
				File.WriteAllBytes(fname, rawimg);
			else
			{
				// reconvert if extension is not the same
				ImageFormat fmt = ImageFormat.Png; // stupid C#
				switch (a)
				{
					case "dds":
						if (!isDDS)
							throw new Exception("Conversion to DXT is not supported. Thanks Shendare.");
						File.WriteAllBytes(fname, rawimg);
						break;
					case "jpg":
					case "jpeg":
						fmt = ImageFormat.Jpeg;
						break;
					case "bmp":
						fmt = ImageFormat.Bmp;
						break;
					case "tif":
					case "tiff":
						fmt = ImageFormat.Tiff;
						break;
					case "png":
					default:
						fmt = ImageFormat.Png;
						break;
				}
				Image.Save(fname, fmt);
			}
		}
	}

	public class Font
	{
		public QbKey Name;
		public int baseline;
		public int shifter;
		public int spacing;
		public float height;
		//glyphsPointer
		public char[] glyphblock;
		public float space_width;
		public struct Glyph
		{
			public float x, y, x2, y2, pxW, pxH, vShift, hShift, unk_d;
		}
		public Glyph[] glyphs;
		public RawImg texture;

		private float Float(byte[] b, int a)
		{
			return Bit.ToSingle(Bit.GetBytes(Eswap(Bit.ToUInt32(b, a))), 0);
		}
		public Glyph this[char i]
		{
			get { return glyphs[glyphblock[i]]; }
			set { glyphs[glyphblock[i]] = value; }
		}
		public RectangleF glyphRect(char glyph)
		{
			Glyph g = this[glyph];
			//Console.WriteLine(glyph);
			//Console.WriteLine(g.y2);
			int w = texture.Image.Width, h = texture.Image.Height;
			return RectangleF.FromLTRB(
					(g.x * w), (g.y * h),
					(g.x2 * w), (g.y2 * h)
				);
		}
		public Font(byte[] a)
		{
			int cursor = 0;
			int glyphcount = 1;
			// if there's 0 glyphs in your font, wtf are you doing
			baseline = Eswap(Bit.ToInt32(a, cursor));
			cursor += 4;
			shifter = Eswap(Bit.ToInt32(a, cursor));
			cursor += 4;
			spacing = Eswap(Bit.ToInt32(a, cursor));
			cursor += 4;
			height = Float(a, cursor);
			cursor += 8;
			// Thanks Neversoft
			glyphblock = new char[0x10000];
			for (int i = 0; i < 0x10000; i++)
			{
				glyphblock[i] = (char)Eswap(Bit.ToUInt16(a, cursor));
				if (glyphblock[i] != 0)
					glyphcount++;
				cursor += 2;
			}
			cursor += 72;
			space_width = Float(a, cursor);
			cursor += 0x44;
			int imgptr = Eswap(Bit.ToInt32(a, cursor));
			cursor += 4; // wtf
			glyphs = new Glyph[glyphcount];
			for (int i = 0; i < glyphcount; i++)
			{
				//glyphs[i] = new Glyph();
				glyphs[i].x = Float(a, cursor);
				cursor += 4;
				glyphs[i].y = Float(a, cursor);
				cursor += 4;
				glyphs[i].x2 = Float(a, cursor);
				cursor += 4;
				glyphs[i].y2 = Float(a, cursor);
				cursor += 4;
				glyphs[i].pxW = Float(a, cursor);
				cursor += 4;
				glyphs[i].pxH = Float(a, cursor);
				cursor += 4;
				glyphs[i].vShift = Float(a, cursor);
				cursor += 4;
				glyphs[i].hShift = Float(a, cursor);
				cursor += 4;
				glyphs[i].unk_d = Float(a, cursor);
				cursor += 4;
			}
			byte[] entry = new byte[0x28];
			Array.Copy(a, imgptr, entry, 0, 0x28);
			int size = (int)Eswap(Bit.ToUInt32(entry, 0x20));
			int size_auto = a.Length - imgptr - 0x28;
			// mismatch
			// kill me for not changing length when i hacked these
			// also thanks aspyr for just letting that happen
			if (size != size_auto)
				size = size_auto;
			Array.Copy(Bit.GetBytes(0x28000000), 0, entry, 0x1C, 4);
			Array.Resize(ref entry, 0x28 + size);
			Array.Copy(a, imgptr + 0x28, entry, 0x28, size);
			texture = new RawImg(entry);
		}
	}

	public class GFX
	{
		private struct Head
		{
			public uint magic;
			public ushort unk1;
			public ushort count;
			public uint start;
			// soy C# requiring ints
			public uint unk2, _FFFFFFFF, unk3, unk4;
		}
		// INACCESSIBLE HOW
		private Head head;
		/*public int Count
		{
			get { return head.count; }
			set
			{
				if (value > maxCount)
					throw new OverflowException("This cannot exceed 128 textures as of now, otherwise the game will crash.");
				head.count = (ushort)value;
			}
		}*/
		private List<RawImg> Images;
		public int Count { get { return Images.Count; } }
		public List<RawImg>.Enumerator GetEnumerator() { return Images.GetEnumerator(); }
		public RawImg this[int i]
		{
			get { return Images[i]; }
			set {
				Images[i] = value;
			}
		}
		public RawImg this[uint c]
		{
			get { return IndexOf(c) > -1 ? this[IndexOf(c)] : null; }
		}
		public int IndexOf(uint i)
		{
			for (int j = 0; j < Count; j++)
			{
				if (this[j].Name.Crc == i)
					return j;
			}
			return -1;
		}
		public GFX(byte[] a)
		{
			head = new Head();
			if (Bit.ToUInt32(a, 0) != Eswap(0xFACECAA7))
			{
				head.magic = 0xBAADF00D;
				throw new FormatException("Invalid header.");
			}
			head.magic = Eswap(0xFACECAA7);
			/*for (int i = 1; i < 8; i++)
				if (Eswap(Bit.ToUInt32(a, i * 4)) != 0xFAAABACA)
				{
					head.size = 0xBAADF00D;
					throw new FormatException("Invalid header.");
					//return;
				}*/
			int cursor = 4;
			head.unk1 = Eswap(Bit.ToUInt16(a, cursor));
			cursor += 2;
			head.count = Eswap(Bit.ToUInt16(a, cursor));
			cursor += 2;
			// lol
			head.start = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head.unk2 = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head._FFFFFFFF = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head.unk3 = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head.unk4 = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			while (cursor < head.start)
			{
				if (Eswap(Bit.ToUInt32(a, cursor)) != 0xEFEFEFEF)
				{
					head.magic = 0xBAADF00D;
					throw new FormatException("Invalid header. Cursor @ 0x"+cursor.ToString("X8"));
					//return;
				}
				cursor += 4;
			}
			Images = new List<RawImg>(128);
			for (int i = 0; i < head.count; i++)
			{
				byte[] entry = new byte[0x28];
				Array.Copy(a,cursor,entry,0,0x28);
				int offset = (int)Eswap(Bit.ToUInt32(entry, 0x1C));
				int size = (int)Eswap(Bit.ToUInt32(entry, 0x20));
				Array.Copy(Bit.GetBytes(0x28000000), 0, entry, 0x1C, 4);
				Array.Resize(ref entry, 0x28 + size);
				Array.Copy(a,offset,entry,0x28,size);
				Images.Add(new RawImg(entry));
				cursor += 0x28;
			}
		}
	}

	public class Scene
	{
		public class Vec4
		{
			float[] _ = new float[4]; // Thanks Neversoft
			public float this[int i]
			{
				get { return _[i]; }
				set { _[i] = value; }
			}
			public Vec4(float x, float y, float z, float w)
			{
				_[0] = x;
				_[1] = y;
				_[2] = z;
				_[3] = w;
			}
			public override string ToString()
			{
				return
					'(' + _[0].ToString() + ','
						+ _[1].ToString() + ','
						+ _[2].ToString() + ','
						+ _[3].ToString() + ')';
			}
		}

		private struct Head
		{
			// 0x00-0x20: random magic
			public ushort unk0, count; // unk1 changed with highway (0x02) and gfx (0x80)
			public uint size;
			public uint unk2;
			public uint _FFFFFFFF;
		}
		Head head;
		public enum Blend : int // thx zed
		{
			Diffuse,
			Add,
			Sub,
			Blend,
			Mod,
			Brighten,
			Multiply,
			SrcPlusDst,
			Blend_AlphaDiffuse,
			SrcPlusDstMultInvAlpha,
			SrcMulDstPlusDst, // don't know if GH3 also has all of these
			DstSubSrcMulInvDst,
			DstMinusSrc
		}
			
		public abstract/* new to this, and i already hate it */ class MatBase
		{
			// thx zed
			public byte[] data; // doing stuff like this
			// and for RawImg to keep data intact
			// and since I don't know the use of
			// every single thing, so for those,
			// just do nothing with it and
			// resave zones with them unmodified
			//
			// writing this as i have not tested
			// or checked how mats load yet to
			// see if i winged writing this
			public const int toffset = 0xA0;
			public uint GetBase(int a)
			{
				// all little endian
				return Eswap(Bit.ToUInt32(data, a));
			}
			[Browsable(false)]
			public int ssize
			{
				get
				{ // WHY IS THERE ALL THIS PADDING
					return Int(toffset + 0x24);
				}
				set
				{
					CopyInt(value, toffset + 0x24);
					Array.Resize(ref data, value);
				}
			}
			public void CopyInt(uint v, int a)
			{
				Array.Copy(Bit.GetBytes(Eswap(v)), 0, data, a, 4);
			}
			public void CopyInt(int v, int a)
			{
				CopyInt((uint)v, a);
			}
			public void CopyFloat(float v, int a)
			{
				// too bad I can't do C casting
				CopyInt(Bit.ToUInt32(Bit.GetBytes(v), 0), a);
			}
			public int Int(int a)
			{
				return (int)GetBase(a);
			}
			public uint UInt(int a)
			{
				return GetBase(a);
			}
			public QbKey Key(int a)
			{
				return Program.keyWithDebug(GetBase(a));
			}
			public float Float(int a)
			{
				return Bit.ToSingle(Bit.GetBytes(GetBase(a)), 0);
			}
			// can i make these less repetitive
			[Browsable(false)]
			public int prop2Count
			{
				get { return Int(toffset + 0x10); }
				set { CopyInt(value, toffset + 0x10); }
			}
			[Browsable(false)]
			public int prop2Offset
			{
				get { return Int(toffset + 0x14); }
				set { CopyInt(value, toffset + 0x14); }
			}
			[Browsable(false)]
			public int texCount // ????????????
			{
				get { return Int(toffset + 0x18); }
				set { CopyInt(value, toffset + 0x18); }
			}
			[Browsable(false)]
			public int texOffset
			{
				get { return Int(toffset + 0x1C); }
				set { CopyInt(value, toffset + 0x1C); }
			}
			[Browsable(false)]
			public int propCount
			{
				get { return Int(toffset + 8); }
				set { CopyInt(value, toffset + 8); }
			}
			[Browsable(false)]
			public int propOffset
			{
				get { return Int(toffset + 12); }
				set { CopyInt(value, toffset + 12); }
			}
			public enum Shader : uint
			{
				// only ones found in global_gfx
				// and using brute force key search
				// by zedek
				AnimatedTexture_UI = 0x98d259f8,
				ImmediateMode_AlphaFade_UI = 0x274943ee,
				ImmediateMode_UI = 0x18564175,
				WhammyBar_UI = 0xbe66aac0,
				__DepthBuffer10_Glass_Variable__ = 0x842a5491,
				__3UberAtmosphere__ = 0xc59a224a,
				FontPatternSlow_Volume = 0x12e87928,
				DepthBuffer1PolyParticleGuitar__ = 0x0ee38343,
				AnimatedTransparent_1Pass_Image__ = 0x3c8bb7ef,
				Animated_Override_ThreeFragment__ = 0x6d3a9379,
				VolumeMap = 0x85cb9e9e,
			}
			public Vec4 props(int i)
			{
				if (i >= propCount)
					throw new ArgumentOutOfRangeException("Index went past the number of contained props: " + i + " > " + propCount + '.');
				return new Vec4(
					Float(propOffset + (i * 0x10) + 0),
					Float(propOffset + (i * 0x10) + 4),
					Float(propOffset + (i * 0x10) + 8),
					Float(propOffset + (i * 0x10) + 12));
			}
			public Color getColor(int c, int a)
			{
				if (c < 1)
					return Color.FromArgb(0);
				int col = 0;
				for (int i = 0; i < 4; i++)
				{
					col |= Convert.ToByte(Float(a + (i << 2)) * 255) << ((3 - i) * 8);
					// autism
				}
				col = (col << 24) | (col >> 8); // RGBA to ARGB
				return Color.FromArgb(col);
			}
			public void setColor(int c, int a, Color cc)
			{
				if (c < 1)
					throw new ArgumentNullException("Color value is not used by this shader, so it cannot be set.");
				CopyFloat((float)(cc.R) / 255, a);
				CopyFloat((float)(cc.G) / 255, a + 4);
				CopyFloat((float)(cc.B) / 255, a + 8);
				CopyFloat((float)(cc.A) / 255, a + 12); // not settable >:(
			}
			[Category("Material")]
			public Blend Blend
			{
				get { return (Blend)Int(toffset + 0x38); }
				set { CopyInt((int)value, toffset + 0x38); }
			} // 3 / Blend
			[Category("Material"), DisplayName("Name")]
			public QbKey material // sys_Gem2D_Green_sys_Gem2D_Green
			{
				get { return Key(0); } // changed to lambda just for fanciness
				// DOESN'T WORK ON SHARPDEVELOP
				set { CopyInt(value.Crc, 0); }
			}
			[Browsable(false)]
			public QbKey shader // or template // ImmediateMode_(AlphaFade_)UI
			{
				get { return Key(toffset); }
				set { CopyInt(value.Crc, toffset); }
			}
			[Category("Material"), DisplayName("Template")]
			public Shader eshader
			{
				get { return (Shader)shader.Crc; }
				set { CopyInt((uint)value, toffset); }
			}
		}
		public class Mat : MatBase
		{
			public Mat(byte[] a) // create from bytes from SCN
			{
				data = a;
			}
			public Mat()
			{
				data = new byte[0x120];
				// create barebones one because C# sucks
				// and ruining what I'm trying to do
				// and because I'm editing texture
				// materials exclusively
				propCount = 0;
				propOffset = 0x100;
				prop2Count = 1;
				prop2Offset = 0x100;
				texCount = 1;
				texOffset = 0x110;
				CopyInt(data.Length, toffset + 0x24);
				CopyInt(4, toffset + 0x2C);
				Blend = Blend.Blend; // lol
				CopyInt(data.Length, toffset + 0x44);
				CopyInt(0x20000, toffset + 0x48);
				for (int i = 0; i < 4; i++) // white RGBA
					CopyFloat(1.0f, toffset + 0x60 + (i * 4));
				material = QbKey.Create("new_material");
				shader = QbKey.Create("ImmediateMode_UI");
			}
			// just for property grid fanciness
			public class ImmediateMode_UI : Mat
			{
				// cringe
				public ImmediateMode_UI(byte[] a)
				{
					data = a;
				}
				public ImmediateMode_UI() : base()
				{
					// create a new one using immediate mode template entry
					texture = QbKey.Create("new_texture");
					// on form, if texture doesn't exist,
					// set to that error image
				}
				[Category("Props"), DisplayName("Color ((A)RGB)")]
				public Color Color
				{
					// probably adjust for props(i) func
					get { return getColor(prop2Count, prop2Offset); }
					set { setColor(prop2Count, prop2Offset, value); }
				}
				[Category("Props"), DisplayName("Texture Path")]
				public QbKey texture
				{
					get { return texCount > 0 ? Key(texOffset) : null; }
					set { CopyInt(value.Crc, texOffset); }
				}
			}
			public class AnimatedTexture_UI : Mat
			{
				public AnimatedTexture_UI(byte[] a)
				{
					data = a;
				}
				public AnimatedTexture_UI() : base()
				{
					texture = QbKey.Create("new_texture");
				}
				[Category("Props"), DisplayName("Color ((A)RGB)")]
				public Color Color
				{
					get { return getColor(prop2Count, prop2Offset); }
					set { setColor(prop2Count, prop2Offset, value); }
				}
				[Category("Props"), DisplayName("Texture Path")]
				public QbKey texture
				{
					get { return texCount > 0 ? Key(texOffset) : null; }
					set { CopyInt(value.Crc, texOffset); }
				}
				[Category("Props"), DisplayName("U Cells")]
				public float UCells
				{
					get { return props(0)[0]; }
					set { CopyFloat(value, propOffset); }
				}
				[Category("Props"), DisplayName("V Cells")]
				public float VCells
				{
					get { return props(1)[0]; }
					set { CopyFloat(value, propOffset + 0x10); }
				}
				[Category("Props"), DisplayName("Frame Rate")]
				public float FPS
				{
					get { return props(2)[0]; }
					set { CopyFloat(value, propOffset + 0x20); }
				}
				// TODO: somehow make propertygrid
				// display objects using actual MatLib structs
				// or necessary parts of it
				[Category("Props")]
				// don't care about right now
				private float Offset
				{
					get { return props(3)[0]; }
					set { CopyFloat(value, propOffset + 0x30); }
				}
				// don't know what this will be for
				private float startFade
				{
					get { return props(4)[0]; }
					set { CopyFloat(value, propOffset + 0x40); }
				}
				private float endFade
				{
					get { return props(5)[0]; }
					set { CopyFloat(value, propOffset + 0x50); }
				}
			}
			public static object Fancy(Mat m)
			{
				// kill me
				// HOW CAN I DO THIS LIKE QB ITEMS
				// SOMEHOW WORKED FOR TEXT ELEMENTS
				// I DONT GET IT
				switch (m.eshader)
				{
					case Shader.ImmediateMode_UI:
					case Shader.ImmediateMode_AlphaFade_UI:
						return new ImmediateMode_UI(m.data);
					case Shader.AnimatedTexture_UI:
						return new AnimatedTexture_UI(m.data);
					default:
						return m;
				}
			}
		}
		List<Mat> mats;
		public int Count { get { return mats.Count; } }
		public List<Mat>.Enumerator GetEnumerator() { return mats.GetEnumerator(); }
		public Mat this[int i]
		{
			get { return mats[i]; }
		}
		public int IndexOf(uint i)
		{
			for (int j = 0; j < Count; j++)
			{
				if (this[j].material == i)
					return j;
			}
			return -1;
		}
		public int IndexOfTex(uint i)
		{
			for (int j = 0; j < Count; j++)
			{
				if (this[j].texCount > 0)
					if (this[j].UInt(this[j].texOffset) == i)
						return j;
			}
			return -1;
		}

		public Scene(byte[] a)
		{
			if (Bit.ToUInt32(a, 0) != 0)
			{
				head.size = 0xBAADF00D;
				throw new FormatException("Invalid header.");
			}
			for (int i = 1; i < 8; i++)
				if (Eswap(Bit.ToUInt32(a, i * 4)) != 0xFAAABACA)
				{
					head.size = 0xBAADF00D;
					throw new FormatException("Invalid header.");
					//return;
				}
			int cursor = 0x20;
			// make a class out of this or something
			// like MMF or stream where you can do
			// ReadUInt16 or ReadString and stuff
			// FUTURE WES: MEMORY STREAM!!!!!!!!!
			head.unk0 = Eswap(Bit.ToUInt16(a, cursor));
			cursor += 2;
			head.count = Eswap(Bit.ToUInt16(a, cursor));
			cursor += 2;
			head.size = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head.unk2 = Eswap(Bit.ToUInt32(a, cursor));
			cursor += 4;
			head._FFFFFFFF = Eswap(Bit.ToUInt32(a, cursor));
			cursor = 0;
			const int listbase = 0x30;
			int listsize = (int)head.size - 0x10;
			// babeface at the last 0x10 bytes
			// from where we're going
			mats = new List<Mat>();
			while (cursor < listsize)
			{
				int ssize =
					(int)Eswap(Bit.ToUInt32(a,
						listbase + cursor + 0xC4));
				byte[] entry = new byte[ssize];
				Array.Copy(a, listbase + cursor, entry, 0, ssize);
				mats.Add(new Mat(entry));
				cursor += ssize;
			}
		}
	}
		
	public void Save()
	{
		Console.WriteLine("Saving zones");
		for (int i = 0; i < images.Count; i++)
		{
			Program.loadtext("images: ("+i+"/"+images.Count+") "+images[i].Name.Crc.ToString("X8")+"\r");
			pe.ReplaceFile(images[i].Name.Crc.ToString("X8"), images[i].Save());
		}
	}
}
