/**
 * crtorrent
 * 
 *  Bencode String Container
 * 
    crtorrent creates torrent metainfo files from directories and files.
    Copyright (C) 2011-2013  Thom Wiggers

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace Thom.Bencode
{
    public class BencodeString : IBencodeItem
    {
		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
        public string Value
        {
            set;
            get;
        }

		/// <summary>
		/// Gets or sets the byte value.
		/// </summary>
		/// <value>
		/// The byte value.
		/// </value>
        public byte[] ByteValue
        {
            set;
            get;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeString"/> class.
		/// </summary>
        public BencodeString()
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeString"/> class.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
        public BencodeString(string value)
        {
            this.Value = value;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeString"/> class.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
        public BencodeString(byte[] value)
        {
            this.ByteValue = value;
        }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeString"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeString"/>.
		/// </returns>
        public override string ToString()
        {
            if (Value != null)
            {
                return String.Format("{0}:{1}", Encoding.UTF8.GetByteCount(Value), Value);
            }
            return "";
        }

		/// <summary>
		///  Returns a <see cref="System.Byte" />[] that represents the current <see cref="Thom.Bencode.BencodeString" />.
		/// </summary>
		/// <returns>
		///  A <see cref="System.Byte"/>[] that represents the current <see cref="Thom.Bencode.BencodeString"/>.
		/// </returns>
        public byte[] ToBytes()
        {
            if (ByteValue == null)
            {
                string returnString = String.Format("{0}:{1}", Encoding.UTF8.GetByteCount(Value), Value);
                return UTF8Encoding.UTF8.GetBytes(returnString);
            }
            else
            {
                List<byte> blist = new List<byte>();
                blist.AddRange(Encoding.UTF8.GetBytes(String.Format("{0}:", ByteValue.Length)));
                blist.AddRange(ByteValue);
                return blist.ToArray();
            }
        }

    }
}
