#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System.Collections.Generic;

using SDL2;
#endregion

namespace Microsoft.Xna.Framework.Input
{
	internal static class SDL2_KeyboardUtil
	{
		#region Private SDL2->XNA Key Hashmap

		private static Dictionary<SDL.SDL_Scancode, Keys> INTERNAL_map;

		#endregion

		#region Hashmap Initializer Constructor

		static SDL2_KeyboardUtil()
		{
			// Create the dictionary...
			INTERNAL_map = new Dictionary<SDL.SDL_Scancode, Keys>();

			// Then fill it with known keys that match up to XNA Keys.
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_A,		Keys.A);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_B,		Keys.B);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_C,		Keys.C);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_D,		Keys.D);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_E,		Keys.E);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F,		Keys.F);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_G,		Keys.G);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_H,		Keys.H);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_I,		Keys.I);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_J,		Keys.J);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_K,		Keys.K);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_L,		Keys.L);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_M,		Keys.M);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_N,		Keys.N);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_O,		Keys.O);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_P,		Keys.P);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_Q,		Keys.Q);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_R,		Keys.R);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_S,		Keys.S);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_T,		Keys.T);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_U,		Keys.U);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_V,		Keys.V);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_W,		Keys.W);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_X,		Keys.X);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_Y,		Keys.Y);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_Z,		Keys.Z);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_0,		Keys.D0);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_1,		Keys.D1);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_2,		Keys.D2);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_3,		Keys.D3);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_4,		Keys.D4);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_5,		Keys.D5);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_6,		Keys.D6);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_7,		Keys.D7);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_8,		Keys.D8);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_9,		Keys.D9);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_0,		Keys.NumPad0);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_1,		Keys.NumPad1);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_2,		Keys.NumPad2);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_3,		Keys.NumPad3);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_4,		Keys.NumPad4);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_5,		Keys.NumPad5);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_6,		Keys.NumPad6);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_7,		Keys.NumPad7);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_8,		Keys.NumPad8);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_9,		Keys.NumPad9);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_CLEAR,	Keys.OemClear);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_DECIMAL,	Keys.Decimal);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_DIVIDE,	Keys.Divide);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_ENTER,	Keys.Enter);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_MINUS,	Keys.OemMinus);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY,	Keys.Multiply);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_PERIOD,	Keys.OemPeriod);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_KP_PLUS,		Keys.Add);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F1,		Keys.F1);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F2,		Keys.F2);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F3,		Keys.F3);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F4,		Keys.F4);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F5,		Keys.F5);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F6,		Keys.F6);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F7,		Keys.F7);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F8,		Keys.F8);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F9,		Keys.F9);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F10,		Keys.F10);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F11,		Keys.F11);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F12,		Keys.F12);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F13,		Keys.F13);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F14,		Keys.F14);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F15,		Keys.F15);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F16,		Keys.F16);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F17,		Keys.F17);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F18,		Keys.F18);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F19,		Keys.F19);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F20,		Keys.F20);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F21,		Keys.F21);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F22,		Keys.F22);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F23,		Keys.F23);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_F24,		Keys.F24);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_SPACE,		Keys.Space);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_UP,		Keys.Up);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_DOWN,		Keys.Down);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LEFT,		Keys.Left);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RIGHT,		Keys.Right);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LALT,		Keys.LeftAlt);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RALT,		Keys.RightAlt);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LCTRL,		Keys.LeftControl);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RCTRL,		Keys.RightControl);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LGUI,		Keys.LeftWindows);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RGUI,		Keys.RightWindows);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LSHIFT,		Keys.LeftShift);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RSHIFT,		Keys.RightShift);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_APPLICATION,	Keys.Apps);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_SLASH,		Keys.OemQuestion);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_BACKSLASH,	Keys.OemBackslash);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_LEFTBRACKET,	Keys.OemOpenBrackets);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET,	Keys.OemCloseBrackets);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_CAPSLOCK,	Keys.CapsLock);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_COMMA,		Keys.OemComma);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_DELETE,		Keys.Delete);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_END,		Keys.End);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_BACKSPACE,	Keys.Back);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_RETURN,		Keys.Enter);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE,		Keys.Escape);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_HOME,		Keys.Home);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_INSERT,		Keys.Insert);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_MINUS,		Keys.OemMinus);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR,	Keys.NumLock);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_PAGEUP,		Keys.PageUp);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_PAGEDOWN,	Keys.PageDown);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_PAUSE,		Keys.Pause);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_PERIOD,		Keys.OemPeriod);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_EQUALS,		Keys.OemPlus);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_PRINTSCREEN,	Keys.PrintScreen);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_APOSTROPHE,	Keys.OemQuotes);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_SCROLLLOCK,	Keys.Scroll);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_SEMICOLON,	Keys.OemSemicolon);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_SLEEP,		Keys.Sleep);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_TAB,		Keys.Tab);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_GRAVE,		Keys.OemTilde);
			INTERNAL_map.Add(SDL.SDL_Scancode.SDL_SCANCODE_UNKNOWN,		Keys.None);
		}

		#endregion

		#region Public SDL2->XNA Key Conversion Method

		public static Keys ToXNA(SDL.SDL_Scancode key)
		{
			Keys retVal;
			if (INTERNAL_map.TryGetValue(key, out retVal))
			{
				return retVal;
			}
			else
			{
				System.Console.WriteLine("KEY MISSING FROM SDL2->XNA DICTIONARY: " + key.ToString());
				return Keys.None;
			}
		}

		#endregion
	}
}
