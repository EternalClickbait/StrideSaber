﻿using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace StrideSaber.Core.ObjectPools
{
	/// <inheritdoc />
	/// <summary>
	/// Default implementation of <see cref="Microsoft.Extensions.ObjectPool.ObjectPool" />. but for a <see cref="System.Text.StringBuilder" />
	/// </summary>
	/// <remarks>This implementation keeps a cache of retained objects. This means that if objects are returned when the pool has already reached "maximumRetained" objects they will be available to be Garbage Collected.</remarks>
	public sealed class StringBuilderPool : DefaultObjectPool<StringBuilder>
	{
		/// <summary>
		/// The <see cref="IPooledObjectPolicy{T}"/> we use
		/// </summary>
		private static readonly StringBuilderPooledObjectPolicy Policy = new();

		/// <summary>
		/// The current singleton instance of a <see cref="StringBuilderPool"/>
		/// </summary>
		private static readonly StringBuilderPool Instance = new();

		/// <inheritdoc cref="DefaultObjectPool{T}.Get"/>
		public static StringBuilder GetPooled()
		{
			return Instance.Get();
		}

		/// <inheritdoc cref="DefaultObjectPool{T}.Return"/>
		public static void ReturnPooled(StringBuilder obj)
		{
			Instance.Return(obj);
		}

		/// <inheritdoc />
		private StringBuilderPool() : base(Policy) //Just pass in the policy, nothing more to do
		{
		}
	}
}