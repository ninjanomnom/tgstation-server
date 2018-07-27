﻿using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tgstation.Server.Api.Models;
using Tgstation.Server.Host.Security;

namespace Tgstation.Server.Host.Components
{
	/// <summary>
	/// For managing the Configuration directory
	/// </summary>
	public interface IConfiguration : IHostedService
	{
		/// <summary>
		/// Copies all files in the CodeModifications directory to <paramref name="destination"/>
		/// </summary>
		/// <param name="dmeFile">The .dme file being compiled</param>
		/// <param name="destination">Path to the destination folder</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="ServerSideModifications"/> if any</returns>
		Task<ServerSideModifications> CopyDMFilesTo(string dmeFile, string destination, CancellationToken cancellationToken);

		/// <summary>
		/// Symlinks all directories in the GameData directory to <paramref name="destination"/>
		/// </summary>
		/// <param name="destination">Path to the destination folder</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task SymlinkStaticFilesTo(string destination, CancellationToken cancellationToken);

		/// <summary>
		/// Get <see cref="ConfigurationFile"/> for all items in a given <paramref name="configurationRelativePath"/>
		/// </summary>
		/// <param name="configurationRelativePath">The relative path in the Configuration directory</param>
		/// <param name="systemIdentity">The <see cref="ISystemIdentity"/> for the operation. If <see langword="null"/>, the operation will be performed as the user of the <see cref="Core.Application"/></param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="ConfigurationFile"/>s for the items in the directory. <see cref="ConfigurationFile.Content"/> and <see cref="ConfigurationFile.LastReadHash"/> will both be <see langword="null"/></returns>
		Task<IReadOnlyList<ConfigurationFile>> ListDirectory(string configurationRelativePath, ISystemIdentity systemIdentity, CancellationToken cancellationToken);

		/// <summary>
		/// Reads a given <paramref name="configurationRelativePath"/>
		/// </summary>
		/// <param name="configurationRelativePath">The relative path in the Configuration directory</param>
		/// <param name="systemIdentity">The <see cref="ISystemIdentity"/> for the operation. If <see langword="null"/>, the operation will be performed as the user of the <see cref="Core.Application"/></param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the <see cref="Api.Models.ConfigurationFile"/> of the file</returns>
		Task<ConfigurationFile> Read(string configurationRelativePath, ISystemIdentity systemIdentity, CancellationToken cancellationToken);

		/// <summary>
		/// Writes to a given <paramref name="configurationRelativePath"/>
		/// </summary>
		/// <param name="configurationRelativePath">The relative path in the Configuration directory</param>
		/// <param name="systemIdentity">The <see cref="ISystemIdentity"/> for the operation. If <see langword="null"/>, the operation will be performed as the user of the <see cref="Core.Application"/></param>
		/// <param name="data">The data to write. If <see langword="null"/>, the file is deleted</param>
		/// <param name="previousHash">The hash any existing file must match in order for the write to succeed</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation. Usage may result in partial writes</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in the updated <see cref="ConfigurationFile"/></returns>
		Task<ConfigurationFile> Write(string configurationRelativePath, ISystemIdentity systemIdentity, byte[] data, string previousHash, CancellationToken cancellationToken);
	}
}