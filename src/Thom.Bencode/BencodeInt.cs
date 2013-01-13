/**
 * crtorrent
 * 
 *  Bencode integer
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
namespace Thom.Bencode
{
	/// <summary>
	/// Bencode int.
	/// </summary>
    public class BencodeInt : IBencodeItem
    {
		/// <summary>
		/// Is the value set?
		/// </summary>
        private bool set = false;

		/// <summary>
		/// The value.
		/// </summary>
        private long value;

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
        public long Value
        {
            set
            {
                set = true;
                this.value = value;
            }
            get 
            { 
                return value; 
            }
        }

        /// <summary>Intitializes a new empty instance of the <see cref="Thom.Bencode.BencodeInt"/> 
		/// class.
		/// </summary>
		public BencodeInt()
        {
            
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeInt"/> class.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
        public BencodeInt(int value)
        {
            this.Value = value;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeInt"/> class.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
        public BencodeInt(long value)
        {
            this.Value = value;
        }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeInt"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeInt"/>.
		/// </returns>
        public override string ToString()
        {
            if (this.set)
            {
                return "i" + Value.ToString() + "e";
            }
            return "";
        }

		/// <summary>
		/// Tos the bytes.
		/// </summary>
		/// <returns>
		/// The bytes.
		/// </returns>
        public byte[] ToBytes()
        {
            return System.Text.Encoding.UTF8.GetBytes(ToString());
        }
    }
}