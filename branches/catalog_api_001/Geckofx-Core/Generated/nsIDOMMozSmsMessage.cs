// --------------------------------------------------------------------------------------------
// Version: MPL 1.1/GPL 2.0/LGPL 2.1
// 
// The contents of this file are subject to the Mozilla Public License Version
// 1.1 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
// http://www.mozilla.org/MPL/
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
// for the specific language governing rights and limitations under the
// License.
// 
// <remarks>
// Generated by IDLImporter from file nsIDOMMozSmsMessage.idl
// 
// You should use these interfaces when you access the COM objects defined in the mentioned
// IDL/IDH file.
// </remarks>
// --------------------------------------------------------------------------------------------
namespace Gecko
{
	using System;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	using System.Runtime.CompilerServices;
	
	
	/// <summary>
    ///This Source Code Form is subject to the terms of the Mozilla Public
    /// License, v. 2.0. If a copy of the MPL was not distributed with this file,
    /// You can obtain one at http://mozilla.org/MPL/2.0/. </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("fc8153d2-0026-11e3-bf31-8b0c1d5e7638")]
	public interface nsIDOMMozSmsMessage
	{
		
		/// <summary>
        /// |type| is always "sms".
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetTypeAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aType);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int GetIdAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		ulong GetThreadIdAttribute();
		
		/// <summary>
        /// Integrated Circuit Card Identifier.
        ///
        /// Will be null if ICC is not available.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetIccIdAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aIccId);
		
		/// <summary>
        /// Should be "received", "sending", "sent" or "error".
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetDeliveryAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aDelivery);
		
		/// <summary>
        /// Possible delivery status values for above delivery states are:
        ///
        /// "received": "success"
        /// "sending" : "pending", or "not-applicable" if the message was sent without
        /// status report requisition.
        /// "sent"    : "pending", "success", "error", or "not-applicable"
        /// if the message was sent without status report requisition.
        /// "error"   : "error"
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetDeliveryStatusAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aDeliveryStatus);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetSenderAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aSender);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetReceiverAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aReceiver);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetBodyAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aBody);
		
		/// <summary>
        /// Should be "normal", "class-0", "class-1", "class-2" or "class-3".
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetMessageClassAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aMessageClass);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		long GetTimestampAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		long GetSentTimestampAttribute();
		
		/// <summary>
        /// "sending").
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		long GetDeliveryTimestampAttribute();
		
		/// <summary>
        /// "received" or not yet delivered).
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool GetReadAttribute();
	}
}
