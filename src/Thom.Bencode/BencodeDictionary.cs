/**
 * crtorrent
 * 
 * Bencode dictionary
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

using System.Collections.Generic;
namespace Thom.Bencode
{ 
	/// <summary>
	/// Bencode dictionary.
	/// </summary>
    public class BencodeDictionary : Dictionary<string,IBencodeItem>,IBencodeItem
    {

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeDictionary"/> class.
		/// </summary>
        public BencodeDictionary()
            : base()
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeDictionary"/> class.
		/// </summary>
		/// <param name='dictionary'>
		/// Dictionary.
		/// </param>
        public BencodeDictionary(IDictionary<string,IBencodeItem> dictionary)
            : base(dictionary)
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeDictionary"/> class.
		/// </summary>
		/// <param name='dictionary'>
		/// Dictionary.
		/// </param>
        public BencodeDictionary(IDictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Add(item.Key, new BencodeString(item.Value));
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeDictionary"/> class.
		/// </summary>
		/// <param name='dictionary'>
		/// Dictionary.
		/// </param>
        public BencodeDictionary(IDictionary<string, int> dictionary)
        {
            foreach (KeyValuePair<string, int> item in dictionary)
            {
                Add(item.Key, new BencodeInt(item.Value));
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Thom.Bencode.BencodeDictionary"/> class.
		/// </summary>
		/// <param name='dictionary'>
		/// Dictionary.
		/// </param>
        public BencodeDictionary(IDictionary<string, long> dictionary)
        {
            foreach (KeyValuePair<string, long> item in dictionary)
            {
                Add(item.Key, new BencodeInt(item.Value));
            }
        }

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeDictionary"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.BencodeDictionary"/>.
		/// </returns>
        public override string ToString()
        {
            string returnString = "";
            if (this.Count > 0)
            {
                returnString = "d";
                foreach (KeyValuePair<string, IBencodeItem> item in this)
                {
                    returnString += (new BencodeString(item.Key)).ToString() + item.Value.ToString();
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
            List<byte> blist = new List<byte>();
            if (this.Count > 0)
            {
                blist.AddRange(System.Text.Encoding.UTF8.GetBytes("d"));
                foreach (KeyValuePair<string, IBencodeItem> item in this)
                {
                    byte[] value = item.Value.ToBytes();
                    if (value == null)
                        continue;

                    blist.AddRange(new BencodeString(item.Key).ToBytes());
                    blist.AddRange(value);
                }
                blist.AddRange(System.Text.Encoding.UTF8.GetBytes("e"));
                return blist.ToArray();
            }
            return null;
        }
 

		/// <summary>
		/// Add the specified key and value.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='value'>
		/// Value.
		/// </param>
        public void Add(string key, string value)
        {
            Add(key,new BencodeString(value));
        }

		/// <summary>
		/// Add the specified key and value.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='value'>
		/// Value.
		/// </param>
        public void Add(string key, byte[] value)
        {
            Add(key, new BencodeString(value));
        }

		/// <summary>
		/// Add the specified key and value.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='value'>
		/// Value.
		/// </param>
        public void Add(string key, int value)
        {
            Add(key, new BencodeInt(value));
        }

		/// <summary>
		/// Add the specified key and value.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='value'>
		/// Value.
		/// </param>
        public void Add(string key, long value)
        {
            Add(key, new BencodeInt(value));
        }

		/// <summary>
		/// Adds the list.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='list'>
		/// List.
		/// </param>
        public void AddList(string key, params string[] list)
        {
            Add(key, new BencodeList(list));
        }

		/// <summary>
		/// Adds the list.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='list'>
		/// List.
		/// </param>
        public void AddList(string key, params int[] list)
        {
            Add(key, new BencodeList(list));
        }

		/// <summary>
		/// Adds the list.
		/// </summary>
		/// <param name='key'>
		/// Key.
		/// </param>
		/// <param name='list'>
		/// List.
		/// </param>
        public void AddList(string key, params IBencodeItem[] list)
        {
            Add(key, new BencodeList(list));
        }

    }
}
