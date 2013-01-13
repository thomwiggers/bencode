//  This file is a part of Thom Wiggers' Bencode library
//
//  BencodeList.cs
//
//  Author:
//       Thom Wiggers <thom@thomwiggers.nl>
//
//  Copyright (c) 2013 Thom Wiggers
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.:w


using System.Collections.Generic;
using System.Text;

namespace Thom.Bencode
{

	/// <summary>
	/// Bencode list.
	/// </summary> 
    public class BencodeList : List<IBencodeItem>,IBencodeItem
    {
		/// <summary>
		/// Initializes a new empty instance of the <see cref="Thom.Bencode.BencodeList"/> class.
		/// </summary>
        public BencodeList()
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeList"/> class.
		/// with a list of integers
		/// </summary>
		/// <param name='list'>
		/// List of integers.
		/// </param>
        public BencodeList(params int[] list)
        {
            foreach (int item in list)
            {
                Add(item); 
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeList"/> class
		/// with a list of longs.
		/// </summary>
		/// <param name='list'>
		/// List of longs
		/// </param>
        public BencodeList (params long[] list)
		{
			foreach (long item in list) {
				Add (item);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeList"/> class.
		/// </summary>
		/// <param name='list'>
		/// List of strings.
		/// </param>
        public BencodeList(params string[] list)
        {
            foreach (string item in list)
            {
                Add(item);
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeList"/> class.
		/// </summary>
		/// <param name='list'>
		/// List of Bencode Items.
		/// </param>
        public BencodeList(IBencodeItem[] list)
        {
            foreach (IBencodeItem item in list)
            {
                Add(item);
            }
        }

		/// <Docs>
		/// The item to add to the current collection.
		/// </Docs>
		/// <para>
		/// Adds an item to the current collection.
		/// </para>
		/// <remarks>
		/// To be added.
		/// </remarks>
		/// <exception cref='System.NotSupportedException'>
		/// The current collection is read-only.
		/// </exception>
		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name='item'>
		/// String Item.
		/// </param>
        public void Add(string item)
        {
            Add(new BencodeString(item));
        }

		/// <Docs>
		/// The item to add to the current collection.
		/// </Docs>
		/// <para>
		/// Adds an item to the current collection.
		/// </para>
		/// <remarks>
		/// To be added.
		/// </remarks>
		/// <exception cref='System.NotSupportedException'>
		/// The current collection is read-only.
		/// </exception>
		/// <summary>
		/// Add the specified item.
		/// </summary>
		/// <param name='item'>
		/// Item.
		/// </param>
        public void Add(long item)
        {
            Add(new BencodeInt(item));
        }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeList"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeList"/>.
		/// </returns>
        public override string ToString()
        {
            string returnString = "";
            if (this.Count > 0)
            {
                returnString = "l";
                foreach (IBencodeItem item in this)
                {
                    returnString += item.ToString();
                }
                returnString += "e";
            }
            return returnString;
        }

		/// <summary>
		/// Tos the bytes.
		/// </summary>
		/// <returns>
		/// The bytes.
		/// </returns>
        public byte[] ToBytes()
        {
            if (this.Count > 0)
            {
                List<byte> blist = new List<byte>();
                blist.AddRange(UTF8Encoding.UTF8.GetBytes("l"));
                foreach (IBencodeItem item in this)
                {
                    byte[] value = item.ToBytes();
                    if(value != null)
                        blist.AddRange(value);
                }
                blist.AddRange(UTF8Encoding.UTF8.GetBytes("e"));
                return blist.ToArray();
            }
            else return null;
        }
    }
}
