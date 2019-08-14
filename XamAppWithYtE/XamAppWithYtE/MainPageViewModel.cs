using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YoutubeExplode;


namespace XamAppWithYtE
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool isRunning;
        private CancellationTokenSource _tcs;

        public int TotalNumber { get; set; } = Testdata.GetVideoIds().Count();

        private int _actualNumber;
        public int ActualNumber
        {
            get => _actualNumber;
            set => SetProperty(ref _actualNumber, value);
        }

        private int _netTime;
        private ObservableCollection<ResultModel> _results;

        public int NetTime
        {
            get => _netTime;
            set => SetProperty(ref _netTime, value);
        }

        public ICommand GetVideosCommand { get; private set; }
        public ICommand GetStreamsCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }


        public ObservableCollection<ResultModel> Results
        {
            get => _results;
            set => SetProperty(ref _results, value);
        }
        private readonly YoutubeClient _youtubeClient;

        public MainPageViewModel(YoutubeClient youtubeClient)
        {
            _youtubeClient = youtubeClient;
            Results = new ObservableCollection<ResultModel>();

            GetVideosCommand = new Command(async () =>
            {
                if (isRunning)
                    return;

                isRunning = true;

                _tcs = new CancellationTokenSource();
                await OnGetVideos(_tcs.Token);

                isRunning = false;

            });

            GetStreamsCommand = new Command(async () =>
            {
                if (isRunning)
                    return;

                isRunning = true;

                _tcs = new CancellationTokenSource();
                await OnGetVideoMediaStreams(_tcs.Token);

                isRunning = false;
            });

            ResetCommand = new Command(() =>
            {
                _tcs.Cancel();
                Results.Clear();
                ActualNumber = 0;
                NetTime = 0;
                isRunning = false;
            });

        }

        private async Task OnGetVideos(CancellationToken cancellationToken)
        {
            ActualNumber = 0;
            NetTime = 0;
            Results.Clear();

            Stopwatch sw = new Stopwatch();
            foreach (var id in Testdata.GetVideoIds())
            {
                ResultModel current = null;

                if (cancellationToken.IsCancellationRequested)
                    return;
                try
                {
                    sw.Restart();
                    var result = await _youtubeClient.GetVideoAsync(id);
                    sw.Stop();

                    if (cancellationToken.IsCancellationRequested)
                        return;

                    current = new ResultModel
                    {
                        Function = $"GetVideoAsync({id}): success ",
                        Delay = (int)sw.ElapsedMilliseconds,
                        Message = result.Title
                    };
                }
                catch (Exception ex)
                {

                    sw.Stop();
                    current = new ResultModel
                    {
                        Function = $"GetVideoAsync({id}): Exception ",
                        Delay = (int)sw.ElapsedMilliseconds,
                        Message = ex.Message
                    };
                }

                Results.Add(current);
                ActualNumber++;
                NetTime += (int)sw.ElapsedMilliseconds;
            }
        }

        private async Task OnGetVideoMediaStreams(CancellationToken cancellationToken)
        {
            ActualNumber = 0;
            NetTime = 0;
            Results.Clear();

            Stopwatch sw = new Stopwatch();
            foreach (var id in Testdata.GetVideoIds())
            {

                ResultModel current = null;

                if (cancellationToken.IsCancellationRequested)
                    return; ;
                try
                {
                    sw.Restart();
                    var result = await _youtubeClient.GetVideoMediaStreamInfosAsync(id);
                    sw.Stop();

                    if (cancellationToken.IsCancellationRequested)
                        return;

                    current = new ResultModel
                    {
                        Function = $"GetVideoMediaStreamInfosAsync({id}): success ",
                        Delay = (int)sw.ElapsedMilliseconds,
                        Message = $"#Muxed streams {result?.Muxed?.Count() ?? 0}"
                    };
                }
                catch (Exception ex)
                {

                    sw.Stop();
                    current = new ResultModel
                    {
                        Function = $"GetVideoMediaStreamInfosAsync({id}): Exception ",
                        Delay = (int)sw.ElapsedMilliseconds,
                        Message = ex.Message
                    };
                }

                Results.Add(current);
                ActualNumber++;
                NetTime += (int)sw.ElapsedMilliseconds;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class ResultModel
    {
        public string Function { get; set; }
        public string Message { get; set; }
        public int Delay { get; set; }
    }

}
