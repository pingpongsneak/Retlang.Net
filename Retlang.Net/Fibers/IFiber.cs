using Retlang.Net.Core;

namespace Retlang.Net.Fibers;

/// <summary>
/// Enqueues pending actions for the context of execution (thread, pool of threads, message pump, etc.)
/// </summary>
public interface IFiber : ISubscriptionRegistry, IExecutionContext, IScheduler, IDisposable
{
    /// <summary>
    /// Start consuming actions.
    /// </summary>
    void Start();
}