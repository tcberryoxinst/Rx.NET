﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information. 

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Linq
{
    public static partial class AsyncEnumerableEx
    {
        // REVIEW: Should we convert Task-based overloads to ValueTask?

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));

            return DoCore(source, onNext: onNext, onError: onError, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception> onError, Action onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext, onError, onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Task> onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));

            return DoCore(source, onNext: onNext, onError: onError, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task> onError, Func<Task> onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext, onError, onCompleted);
        }

#if !NO_DEEP_CANCELLATION
        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, Task> onNext)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, Task> onNext, Func<CancellationToken, Task> onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext: onNext, onError: null, onCompleted: onCompleted);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, Task> onNext, Func<Exception, CancellationToken, Task> onError)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));

            return DoCore(source, onNext: onNext, onError: onError, onCompleted: null);
        }

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, Task> onNext, Func<Exception, CancellationToken, Task> onError, Func<CancellationToken, Task> onCompleted)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (onNext == null)
                throw Error.ArgumentNull(nameof(onNext));
            if (onError == null)
                throw Error.ArgumentNull(nameof(onError));
            if (onCompleted == null)
                throw Error.ArgumentNull(nameof(onCompleted));

            return DoCore(source, onNext, onError, onCompleted);
        }
#endif

        public static IAsyncEnumerable<TSource> Do<TSource>(this IAsyncEnumerable<TSource> source, IObserver<TSource> observer)
        {
            if (source == null)
                throw Error.ArgumentNull(nameof(source));
            if (observer == null)
                throw Error.ArgumentNull(nameof(observer));

            return DoCore(source, new Action<TSource>(observer.OnNext), new Action<Exception>(observer.OnError), new Action(observer.OnCompleted));
        }

        private static IAsyncEnumerable<TSource> DoCore<TSource>(IAsyncEnumerable<TSource> source, Action<TSource> onNext, Action<Exception>? onError, Action? onCompleted)
        {
            return AsyncEnumerable.Create(Core);

            async IAsyncEnumerator<TSource> Core(CancellationToken cancellationToken)
            {
                await using var e = source.GetConfiguredAsyncEnumerator(cancellationToken, false);

                while (true)
                {
                    TSource item;

                    try
                    {
                        if (!await e.MoveNextAsync())
                        {
                            break;
                        }

                        item = e.Current;

                        onNext(item);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex) when (onError != null)
                    {
                        onError(ex);
                        throw;
                    }

                    yield return item;
                }

                onCompleted?.Invoke();
            }
        }

        private static IAsyncEnumerable<TSource> DoCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, Task> onNext, Func<Exception, Task>? onError, Func<Task>? onCompleted)
        {
            return AsyncEnumerable.Create(Core);

            async IAsyncEnumerator<TSource> Core(CancellationToken cancellationToken)
            {
                await using var e = source.GetConfiguredAsyncEnumerator(cancellationToken, false);

                while (true)
                {
                    TSource item;

                    try
                    {
                        if (!await e.MoveNextAsync())
                        {
                            break;
                        }

                        item = e.Current;

                        await onNext(item).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex) when (onError != null)
                    {
                        await onError(ex).ConfigureAwait(false);
                        throw;
                    }

                    yield return item;
                }

                if (onCompleted != null)
                {
                    await onCompleted().ConfigureAwait(false);
                }
            }
        }

#if !NO_DEEP_CANCELLATION
        private static IAsyncEnumerable<TSource> DoCore<TSource>(IAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, Task> onNext, Func<Exception, CancellationToken, Task>? onError, Func<CancellationToken, Task>? onCompleted)
        {
            return AsyncEnumerable.Create(Core);

            async IAsyncEnumerator<TSource> Core(CancellationToken cancellationToken)
            {
                await using var e = source.GetConfiguredAsyncEnumerator(cancellationToken, false);

                while (true)
                {
                    TSource item;

                    try
                    {
                        if (!await e.MoveNextAsync())
                        {
                            break;
                        }

                        item = e.Current;

                        await onNext(item, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception ex) when (onError != null)
                    {
                        await onError(ex, cancellationToken).ConfigureAwait(false);
                        throw;
                    }

                    yield return item;
                }

                if (onCompleted != null)
                {
                    await onCompleted(cancellationToken).ConfigureAwait(false);
                }
            }
        }
#endif
    }
}
