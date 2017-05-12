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
// Generated by IDLImporter from file nsIIncrementalDownload.idl
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
    /// An incremental download object attempts to fetch a file piecemeal over time
    /// in an effort to minimize network bandwidth usage.
    ///
    /// Canceling a background download does not cause the file on disk to be
    /// deleted.
    /// </summary>
	[ComImport()]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("6687823f-56c4-461d-93a1-7f6cb7dfbfba")]
	public interface nsIIncrementalDownload : nsIRequest
	{
		
		/// <summary>
        /// The name of the request.  Often this is the URI of the request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void GetNameAttribute([MarshalAs(UnmanagedType.LPStruct)] nsAUTF8StringBase aName);
		
		/// <summary>
        /// Indicates whether the request is pending. nsIRequest::isPending is
        /// true when there is an outstanding asynchronous event that will make
        /// the request no longer be pending.  Requests do not necessarily start
        /// out pending; in some cases, requests have to be explicitly initiated
        /// (e.g. nsIChannel implementations are only pending once asyncOpen
        /// returns successfully).
        ///
        /// Requests can become pending multiple times during their lifetime.
        ///
        /// @return TRUE if the request has yet to reach completion.
        /// @return FALSE if the request has reached completion (e.g., after
        /// OnStopRequest has fired).
        /// @note Suspended requests are still considered pending.
        /// </summary>
		[return: MarshalAs(UnmanagedType.U1)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new bool IsPending();
		
		/// <summary>
        /// The error status associated with the request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new int GetStatusAttribute();
		
		/// <summary>
        /// Cancels the current request.  This will close any open input or
        /// output streams and terminate any async requests.  Users should
        /// normally pass NS_BINDING_ABORTED, although other errors may also
        /// be passed.  The error passed in will become the value of the
        /// status attribute.
        ///
        /// Implementations must not send any notifications (e.g. via
        /// nsIRequestObserver) synchronously from this function. Similarly,
        /// removal from the load group (if any) must also happen asynchronously.
        ///
        /// Requests that use nsIStreamListener must not call onDataAvailable
        /// anymore after cancel has been called.
        ///
        /// @param aStatus the reason for canceling this request.
        ///
        /// NOTE: most nsIRequest implementations expect aStatus to be a
        /// failure code; however, some implementations may allow aStatus to
        /// be a success code such as NS_OK.  In general, aStatus should be
        /// a failure code.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Cancel(int aStatus);
		
		/// <summary>
        /// Suspends the current request.  This may have the effect of closing
        /// any underlying transport (in order to free up resources), although
        /// any open streams remain logically opened and will continue delivering
        /// data when the transport is resumed.
        ///
        /// Calling cancel() on a suspended request must not send any
        /// notifications (such as onstopRequest) until the request is resumed.
        ///
        /// NOTE: some implementations are unable to immediately suspend, and
        /// may continue to deliver events already posted to an event queue. In
        /// general, callers should be capable of handling events even after
        /// suspending a request.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Suspend();
		
		/// <summary>
        /// Resumes the current request.  This may have the effect of re-opening
        /// any underlying transport and will resume the delivery of data to
        /// any open streams.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void Resume();
		
		/// <summary>
        /// The load group of this request.  While pending, the request is a
        /// member of the load group.  It is the responsibility of the request
        /// to implement this policy.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new nsILoadGroup GetLoadGroupAttribute();
		
		/// <summary>
        /// The load group of this request.  While pending, the request is a
        /// member of the load group.  It is the responsibility of the request
        /// to implement this policy.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLoadGroupAttribute([MarshalAs(UnmanagedType.Interface)] nsILoadGroup aLoadGroup);
		
		/// <summary>
        /// The load flags of this request.  Bits 0-15 are reserved.
        ///
        /// When added to a load group, this request's load flags are merged with
        /// the load flags of the load group.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new uint GetLoadFlagsAttribute();
		
		/// <summary>
        /// The load flags of this request.  Bits 0-15 are reserved.
        ///
        /// When added to a load group, this request's load flags are merged with
        /// the load flags of the load group.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		new void SetLoadFlagsAttribute(uint aLoadFlags);
		
		/// <summary>
        /// Initialize the incremental download object.  If the destination file
        /// already exists, then only the remaining portion of the file will be
        /// fetched.
        ///
        /// NOTE: The downloader will create the destination file if it does not
        /// already exist.  It will create the file with the permissions 0600 if
        /// needed.  To affect the permissions of the file, consumers of this
        /// interface may create an empty file at the specified destination prior to
        /// starting the incremental download.
        ///
        /// NOTE: Since this class may create a temporary file at the specified
        /// destination, it is advisable for the consumer of this interface to specify
        /// a file name for the destination that would not tempt the user into
        /// double-clicking it.  For example, it might be wise to append a file
        /// extension like ".part" to the end of the destination to protect users from
        /// accidentally running "blah.exe" before it is a complete file.
        ///
        /// @param uri
        /// The URI to fetch.
        /// @param destination
        /// The location where the file is to be stored.
        /// @param chunkSize
        /// The size of the chunks to fetch.  A non-positive value results in
        /// the default chunk size being used.
        /// @param intervalInSeconds
        /// The amount of time to wait between fetching chunks.  Pass a
        /// negative to use the default interval, or 0 to fetch the remaining
        /// part of the file in one chunk.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Init([MarshalAs(UnmanagedType.Interface)] nsIURI uri, [MarshalAs(UnmanagedType.Interface)] nsIFile destination, int chunkSize, int intervalInSeconds);
		
		/// <summary>
        /// The URI being fetched.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetURIAttribute();
		
		/// <summary>
        /// The URI being fetched after any redirects have been followed.  This
        /// attribute is set just prior to calling OnStartRequest on the observer
        /// passed to the start method.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIURI GetFinalURIAttribute();
		
		/// <summary>
        /// The file where the download is being written.
        /// </summary>
		[return: MarshalAs(UnmanagedType.Interface)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		nsIFile GetDestinationAttribute();
		
		/// <summary>
        /// The total number of bytes for the requested file.  This attribute is set
        /// just prior to calling OnStartRequest on the observer passed to the start
        /// method.
        ///
        /// This attribute has a value of -1 if the total size is unknown.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		long GetTotalSizeAttribute();
		
		/// <summary>
        /// The current number of bytes downloaded so far.  This attribute is set just
        /// prior to calling OnStartRequest on the observer passed to the start
        /// method.
        ///
        /// This attribute has a value of -1 if the current size is unknown.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		long GetCurrentSizeAttribute();
		
		/// <summary>
        /// Start the incremental download.
        ///
        /// @param observer
        /// An observer to be notified of various events.  OnStartRequest is
        /// called when finalURI and totalSize have been determined or when an
        /// error occurs.  OnStopRequest is called when the file is completely
        /// downloaded or when an error occurs.  If this object implements
        /// nsIProgressEventSink, then its OnProgress method will be called as
        /// data is written to the destination file.  If this object implements
        /// nsIInterfaceRequestor, then it will be assigned as the underlying
        /// channel's notification callbacks, which allows it to provide a
        /// nsIAuthPrompt implementation if needed by the channel, for example.
        /// @param ctxt
        /// User defined object forwarded to the observer's methods.
        /// </summary>
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
		void Start([MarshalAs(UnmanagedType.Interface)] nsIRequestObserver observer, [MarshalAs(UnmanagedType.Interface)] nsISupports ctxt);
	}
}
