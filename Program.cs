using System.Diagnostics;
using System.Reflection;
using VC;

Thread mThread = Thread.CurrentThread;
string pid = (Random.Shared.NextDouble() * Random.Shared.Next()).ToString("G");
long average = 0;

Console.Title = $"[{Assembly.GetExecutingAssembly().GetName().Name} v{Assembly.GetExecutingAssembly().GetName().Version!.ToString().Replace(".",string.Empty).TrimEnd('0')}] Pid:{pid}";

for (int i = 0; i < Random.Shared.Next(5,10)*Random.Shared.Next(25,75); i++)
{
    ThreadRunner.StartNewThread(T1);
}

Tick();

void Tick()
{
    Thread thread = new Thread(x =>
    {
        while (true)
        {
            Console.Clear();
            Console.Write($"Average Time:{average}ms\nThreads:{ThreadRunner.Threads}");
            Thread.Sleep(1000);
        }
    });
    thread.Start();
}

void T1()
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    while (true)
    {
        Parallel.For(0,(int)Math.Pow(Random.Shared.Next(1,8),Random.Shared.Next(1,8)),D1);
        GC.Collect();
        average = (average + stopwatch.ElapsedMilliseconds) / 2;
        stopwatch.Restart();
    }
}

void D1(int input)
{
    BigFloat _3 = BigFloat.One;
    for (int i = 0; i < Random.Shared.Next(0,input); i++)
    {
        BigFloat _1 = new BigFloat(RandomFloat());
        BigFloat _2 = new BigFloat(RandomFloat());
        _3 *= _1 * _2;
    }
    D2(_3);
}

void D2(BigFloat input)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    for (BigFloat i = input; i < RandomFloat(); i /= 2)
    {
        
    }
    stopwatch.Stop();
    D3(stopwatch.Elapsed);
}

void D3(TimeSpan timeSpan)
{
    
}

BigFloat RandomFloat()
{
    return BigFloat.Parse(Random.Shared.Next().ToString()) * Random.Shared.NextDouble();
}

static class ThreadRunner
{
    public static long Threads = 0;
    public static Thread StartNewThread(ThreadStart threadStart)
    {
        Thread thread = new Thread(threadStart);
        thread.Start();
        Threads++;
        return thread;
    }
}


