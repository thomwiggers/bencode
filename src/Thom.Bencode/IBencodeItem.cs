/**
 * crtorrent
 * 
 *  Interface implementation of Bencode Items
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
    public interface IBencodeItem
    {
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.IBencodeItem"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents the current <see cref="Thom.Bencode.IBencodeItem"/>.
		/// </returns>
        string ToString();

		/// <summary>
		/// Tos the bytes.
		/// </summary>
		/// <returns>
		/// The bytes.
		/// </returns>
        byte[] ToBytes();
    }
}
