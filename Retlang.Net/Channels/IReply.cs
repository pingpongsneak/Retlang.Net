namespace Retlang.Net.Channels;

/// <summary>
/// Used to receive one or more replies.
/// </summary>
/// <typeparam name="M"></typeparam>
public interface IReply<M> : IDisposable
{
    /// <summary>
    /// Receive a single response. Can be called repeatedly for multiple replies.
    /// </summary>
    /// <param name="timeoutInMs"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    bool Receive(int timeoutInMs, out M result);
}