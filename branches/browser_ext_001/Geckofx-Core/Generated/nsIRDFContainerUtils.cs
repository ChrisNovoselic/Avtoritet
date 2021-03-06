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
// Generated by IDLImporter from file nsIRDFContainerUtils.idl
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
    /// Container utilities
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("D4214E91-FB94-11D2-BDD8-00104BDE6048")]
	public interface nsIRDFContainerUtils
	{
		
		/// <summary>
        /// Returns 'true' if the property is an RDF ordinal property.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsOrdinalProperty([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aProperty);
		
		/// <summary>
        /// Convert the specified index to an ordinal property.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIRDFResource IndexToOrdinalResource(int aIndex);
		
		/// <summary>
        /// Convert the specified ordinal property into an index
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int OrdinalResourceToIndex([MarshalAs(UnmanagedType.Interface)] nsIRDFResource aOrdinal);
		
		/// <summary>
        /// Return 'true' if the specified resource is a container
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsContainer([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Return 'true' if the specified resource is a container and it is empty
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsEmpty([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Return 'true' if the specified resource is a bag
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsBag([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Return 'true' if the specified resource is a sequence
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsSeq([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Return 'true' if the specified resource is an alternation
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		bool IsAlt([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Decorates the specified resource appropriately to make it
        /// usable as an empty bag in the specified data source.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIRDFContainer MakeBag([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Decorates the specified resource appropriately to make it
        /// usable as an empty sequence in the specified data source.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIRDFContainer MakeSeq([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Decorates the specified resource appropriately to make it
        /// usable as an empty alternation in the specified data source.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIRDFContainer MakeAlt([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aResource);
		
		/// <summary>
        /// Retrieve the index of element in the container. Returns -1 if
        /// the element is not in the container.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		int IndexOf([MarshalAs(UnmanagedType.Interface)] nsIRDFDataSource aDataSource, [MarshalAs(UnmanagedType.Interface)] nsIRDFResource aContainer, [MarshalAs(UnmanagedType.Interface)] nsIRDFNode aElement);
	}
}
