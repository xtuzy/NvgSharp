using System;

#if MONOGAME || FNA
using Microsoft.Xna.Framework;
#elif STRIDE
using Stride.Core.Mathematics;
#else
using System.Drawing;
#endif

namespace NvgSharp
{
	public static unsafe class NvgUtility
	{
		public static float sqrtf(float a)
		{
			return (float)(Math.Sqrt((float)(a)));
		}

		public static float sinf(float a)
		{
			return (float)(Math.Sin((float)(a)));
		}

		public static float tanf(float a)
		{
			return (float)(Math.Tan((float)(a)));
		}

		public static float atan2f(float a, float b)
		{
			return (float)(Math.Atan2(a, b));
		}

		public static float cosf(float a)
		{
			return (float)(Math.Cos((float)(a)));
		}

		public static float acosf(float a)
		{
			return (float)(Math.Acos((float)(a)));
		}

		public static float ceilf(float a)
		{
			return (float)(Math.Ceiling((float)(a)));
		}

		public static float __modf(float a, float b)
		{
			return (float)(a % b);
		}

		public static int __mini(int a, int b)
		{
			return (int)((a) < (b) ? a : b);
		}

		public static int __maxi(int a, int b)
		{
			return (int)((a) > (b) ? a : b);
		}

		public static int __clampi(int a, int mn, int mx)
		{
			return (int)((a) < (mn) ? mn : ((a) > (mx) ? mx : a));
		}

		public static float __minf(float a, float b)
		{
			return (float)((a) < (b) ? a : b);
		}

		public static float __maxf(float a, float b)
		{
			return (float)((a) > (b) ? a : b);
		}

		public static float __absf(float a)
		{
			return (float)((a) >= (0.0f) ? a : -a);
		}

		public static float __signf(float a)
		{
			return (float)((a) >= (0.0f) ? 1.0f : -1.0f);
		}

		public static float __clampf(float a, float mn, float mx)
		{
			return (float)((a) < (mn) ? mn : ((a) > (mx) ? mx : a));
		}

		public static float __cross(float dx0, float dy0, float dx1, float dy1)
		{
			return (float)(dx1 * dy0 - dx0 * dy1);
		}

		public static float __normalize(ref float x, ref float y)
		{
			float d = (float)sqrtf((float)((x * x) + (y * y)));
			if ((d) > (1e-6f))
			{
				float id = (float)(1.0f / d);
				x *= (float)(id);
				y *= (float)(id);
			}

			return (float)(d);
		}

		public static float Hue(float h, float m1, float m2)
		{
			if ((h) < (0))
				h += (float)(1);
			if ((h) > (1))
				h -= (float)(1);
			if ((h) < (1.0f / 6.0f))
				return (float)(m1 + (m2 - m1) * h * 6.0f);
			else if ((h) < (3.0f / 6.0f))
				return (float)(m2);
			else if ((h) < (4.0f / 6.0f))
				return (float)(m1 + (m2 - m1) * (2.0f / 3.0f - h) * 6.0f);
			return (float)(m1);
		}

		public static Color HSLA(float h, float s, float l, byte a)
		{
			h = (float)(__modf((float)(h), (float)(1.0f)));
			if ((h) < (0.0f))
				h += (float)(1.0f);
			s = (float)(__clampf((float)(s), (float)(0.0f), (float)(1.0f)));
			l = (float)(__clampf((float)(l), (float)(0.0f), (float)(1.0f)));
			var m2 = (float)(l <= 0.5f ? (l * (1 + s)) : (l + s - l * s));
			var m1 = (float)(2 * l - m2);

			float fr = (float)(__clampf((float)(Hue((float)(h + 1.0f / 3.0f), (float)(m1), (float)(m2))), (float)(0.0f), (float)(1.0f)));
			float fg = (float)(__clampf((float)(Hue((float)(h), (float)(m1), (float)(m2))), (float)(0.0f), (float)(1.0f)));
			float fb = (float)(__clampf((float)(Hue((float)(h - 1.0f / 3.0f), (float)(m1), (float)(m2))), (float)(0.0f), (float)(1.0f)));
			float fa = (float)(a / 255.0f);

			return FromRGBA((byte)(int)(fr * 255), (byte)(int)(fg * 255), (byte)(int)(fb * 255), (byte)(int)(fa * 255));
		}

		public static float DegToRad(float deg)
		{
			return (float)(deg / 180.0f * 3.14159274);
		}

		public static float RadToDeg(float rad)
		{
			return (float)(rad / 3.14159274 * 180.0f);
		}

		public static Color FromRGBA(byte r, byte g, byte b, byte a)
		{
#if MONOGAME || FNA || STRIDE
			return new Color(r, g, b, a);
#else
			return Color.FromArgb(r, g, b, a);
#endif
		}

	}
}