﻿namespace Tgstation.Server.Host.Components.Chat
{
	/// <summary>
	/// Represents a <see cref="Providers.IProvider"/> channel
	/// </summary>
    public sealed class Channel
	{
		/// <summary>
		/// The <see cref="Providers.IProvider"/> channel Id.
		/// </summary>
		/// <remarks><see cref="Chat"/> remaps this to an internal id using <see cref="ChannelMapping"/></remarks>
		public ulong Id { get; set; }

		/// <summary>
		/// The user friendly name of the <see cref="Channel"/>
		/// </summary>
		public string FriendlyName { get; set; }

		/// <summary>
		/// The name of the connection the <see cref="Channel"/> belongs to
		/// </summary>
		public string ConnectionName { get; set; }

		/// <summary>
		/// If this is considered a channel for admin commands
		/// </summary>
		public bool IsAdmin { get; set; }

		/// <summary>
		/// If this is a 1-to-1 chat channel
		/// </summary>
		public bool IsPrivate { get; set; }
	}
}
