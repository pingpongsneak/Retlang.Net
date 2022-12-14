using Retlang.Net.Fibers;

namespace Retlang.Net.Channels;

/// <summary>
/// Channel for synchronous and asynchronous requests.
/// </summary>
/// <typeparam name="R"></typeparam>
/// <typeparam name="M"></typeparam>
public class RequestReplyChannel<R, M>: IRequestReplyChannel<R,M>
{
    private readonly Channel<IRequest<R, M>> _requestChannel = new Channel<IRequest<R, M>>();

    /// <summary>
    /// Subscribe to requests.
    /// </summary>
    /// <param name="fiber"></param>
    /// <param name="onRequest"></param>
    /// <returns></returns>
    public IDisposable Subscribe(IFiber fiber, Action<IRequest<R, M>> onRequest)
    {
        return _requestChannel.Subscribe(fiber, onRequest);
    }

    /// <summary>
    /// Send request to any and all subscribers.
    /// </summary>
    /// <param name="p"></param>
    /// <returns>null if no subscribers registered for request.</returns>
    public IReply<M> SendRequest(R p)
    {
        var request = new ChannelRequest<R, M>(p);
        return _requestChannel.Publish(request) ? request : null;
    }
}