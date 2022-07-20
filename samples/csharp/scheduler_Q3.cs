/***************************************************************************/

/*
# This helper allows you to perform some async operation and keep track of

# whether it's still ongoing, so in case someone wants to perform it again (and

# get a Promise for its completion) the same ongoing promise can be reused.
*/

#nullable enable
using System;
using System.Threading.Tasks;

class ScheduledTask<T> where T : struct {
    private readonly int expirationMs;
    private readonly Func<Task<T?>> producer;
    private TaskCompletionSource<T?>? promise = null;
    private Nullable<T> result = null;

    public ScheduledTask(Func<Task<T?>> producer, int expirationMs = int.MaxValue) {
        this.expirationMs = expirationMs;
        this.producer = producer;
    }

    public async Task<T?> Run() {
        if (this.promise == null) {
            this.promise = new TaskCompletionSource<T?>();
            this.promise.SetResult(await this.producer());
            this.StoreResult(this.promise.Task)
                .ContinueWith(t => {
                    if (this.expirationMs < int.MaxValue && this.promise != null) {
                        Task.Delay(this.expirationMs).ContinueWith(t2 => {
                          this.promise = null;
                          this.result = default(T?);
                    });
                  }
              });
        }
        return await this.promise.Task;
    }

    private async Task StoreResult(Task<T?> promise) {
        this.result = await promise;
        if (this.result == null) {
            this.promise = null; // allow retry
        }
    }
}


/*
# Question: How does the ScheduledTask class deal with errors in the call it

# wraps?

# Answer:
*/