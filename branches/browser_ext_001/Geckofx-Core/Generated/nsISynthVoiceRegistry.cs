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
// Generated by IDLImporter from file nsISynthVoiceRegistry.idl
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
	[Guid("53dcc868-4193-4c3c-a1d9-fe5a0a6af2fb")]
	public interface nsISynthVoiceRegistry
	{
		
		/// <summary>
        /// Register a speech synthesis voice.
        ///
        /// @param aService      the service that provides this voice.
        /// @param aUri          a unique identifier for this voice.
        /// @param aName         human-readable name for this voice.
        /// @param aLang         a BCP 47 language tag.
        /// @param aLocalService true if service does not require network.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void AddVoice([MarshalAs(UnmanagedType.Interface)] nsISpeechService aService, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aName, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aLang, [MarshalAs(UnmanagedType.U1)] bool aLocalService);
		
		/// <summary>
        /// Remove a speech synthesis voice.
        ///
        /// @param aService the service that was used to add the voice.
        /// @param aUri     a unique identifier of an existing voice.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void RemoveVoice([MarshalAs(UnmanagedType.Interface)] nsISpeechService aService, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri);
		
		/// <summary>
        /// Set a voice as default.
        ///
        /// @param aUri       a unique identifier of an existing voice.
        /// @param aIsDefault true if this voice should be toggled as default.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void SetDefaultVoice([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri, [MarshalAs(UnmanagedType.U1)] bool aIsDefault);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		uint GetVoiceCountAttribute();
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetVoice(uint aIndex, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase retval);
		
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsDefaultVoice([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri);
		
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsLocalVoice([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetVoiceLang([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase retval);
		
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void GetVoiceName([MarshalAs(UnmanagedType.LPStruct)] nsAStringBase aUri, [MarshalAs(UnmanagedType.LPStruct)] nsAStringBase retval);
	}
}
