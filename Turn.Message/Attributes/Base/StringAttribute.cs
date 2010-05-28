﻿// 
//  Author:
//       Vitali Fomine <support@officesip.com>
// 
//  Copyright (c) 2010 OfficeSIP Communications
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
using System;


namespace Turn.Message
{
	public abstract class StringAttribute : UtfAttribute
	{
		public StringAttribute()
		{
		}

		public override UInt16 ValueLength
		{
			get
			{
				return (UInt16)Utf8Value.Length;
			}
			protected set
			{
				throw new InvalidOperationException();
			}
		}

		public string Value
		{
			get
			{
				return base.StringValue;
			}
			set
			{
				base.StringValue = value;
			}
		}

		public override void GetBytes(byte[] bytes, ref int startIndex)
		{
			base.GetBytes(bytes, ref startIndex);

			CopyBytes(bytes, ref startIndex, Utf8Value);
		}

		public override void Parse(byte[] bytes, ref int startIndex)
		{
			int length = ParseHeader(bytes, ref startIndex);

			ParseUtf8String(bytes, ref startIndex, length);
		}
	}
}
