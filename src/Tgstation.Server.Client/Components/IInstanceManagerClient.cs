﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tgstation.Server.Api.Models;
using Tgstation.Server.Api.Rights;

namespace Tgstation.Server.Client.Components
{
	/// <summary>
	/// For managing <see cref="Instance"/>s
	/// </summary>
	public interface IInstanceManagerClient : IRightsClient<InstanceUserRights>
	{
		/// <summary>
		/// Get all <see cref="IInstanceClient"/>s for <see cref="Instance"/>s the user can view
		/// </summary>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in a <see cref="IReadOnlyList{T}"/> of all <see cref="IInstanceClient"/>s for <see cref="Instance"/>s the user can view</returns>
		Task<IReadOnlyList<IInstanceClient>> Read(CancellationToken cancellationToken);

		/// <summary>
		/// Create an <paramref name="instance"/>
		/// </summary>
		/// <param name="instance">The <see cref="Instance"/> to create. <see cref="Instance.Id"/> will be ignored</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task{TResult}"/> resulting in <see cref="IInstanceClient"/> for the created <see cref="Instance"/></returns>
		Task<IInstanceClient> Create(Instance instance, CancellationToken cancellationToken);

		/// <summary>
		/// Relocates, renamed, and/or on/offlines an <paramref name="instance"/>
		/// </summary>
		/// <param name="instance">The <see cref="Instance"/> to update</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Update(Instance instance, CancellationToken cancellationToken);

		/// <summary>
		/// Deletes an <paramref name="instance"/>
		/// </summary>
		/// <param name="instance">The <see cref="Instance"/> to delete</param>
		/// <param name="cancellationToken">The <see cref="CancellationToken"/> for the operation</param>
		/// <returns>A <see cref="Task"/> representing the running operation</returns>
		Task Delete(Instance instance, CancellationToken cancellationToken);
	}
}