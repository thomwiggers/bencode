//
//  BencodeIntTest.cs
//
//  Author:
//       Thom Wiggers <thom@thomwiggers.nl>
//
//  Copyright (c) 2013 Thom Wiggers
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using NUnit.Framework;
using Thom.Bencode;

namespace Thom.BencodeTests
{
	[TestFixture()]
	public class BencodeIntTest
	{
		[Test()]
		public void TestCase ()
		{
			BencodeInt item = new BencodeInt();

			Assert.AreEqual(item.ToString(), "");

			item.Value = 3;

			Assert.AreEqual(item.ToString(), "i3e");

			item.Value += 3;

			Assert.AreEqual(item.Value, 6);
			Assert.AreEqual(item.ToString(), "i6e");

			item = new BencodeInt(33L);
			Assert.AreEqual(item.ToString(), "i33e");


		}
	}
}

