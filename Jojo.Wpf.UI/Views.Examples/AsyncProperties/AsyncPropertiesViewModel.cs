using Jojo.Wpf.UI.Helpers.MVVM;
using System;
using System.Threading.Tasks;

namespace Jojo.Wpf.UI.Views.Examples
{
    /// <summary>
    /// Represents the view model of an async property.
    /// </summary>
    /// <example>
    /// This sample is to put in XAML.
    /// <code>
    /// ...
    ///   <TextBlock Text="{Binding Path=AsyncPropertyA, UpdatedSourceTrigger=PropertyChanged, IsAsync=True, FallbackValue=Loading...}" />
    /// ...
    /// </code>
    /// </example>
    public class AsyncPropertiesViewModel : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Gets the window title.
        /// </summary>
        public string Title => "AsyncProperty";

        /// <summary>
        /// The lazy property to load.
        /// </summary>
        private Lazy<string> _asyncPropertyA;

        /// <summary>
        /// Gets the async property value.
        /// </summary>
        public string AsyncPropertyA
        {
            get
            {
                return _asyncPropertyA.Value;
            }
        }

        /// <summary>
        /// Gets the async property value.
        /// </summary>
        public string AsyncPropertyB
        {
            get
            {
                return InvalidateAsyncPropertyB();
            }
        }

        /// <summary>
        /// The async property value C.
        /// </summary>
        private string _asyncPropertyC;

        /// <summary>
        /// Gets or sets the async property value C.
        /// </summary>
        public string AsyncPropertyC
        {
            get
            {
                return _asyncPropertyC;
            }

            set
            {
                _asyncPropertyC = value;
                OnPropertyChanged(nameof(AsyncPropertyC));
            }
        }

        /// <summary>
        /// A value indicating whether the A value is calculating.
        /// </summary>
        private bool _isLoadingA;

        /// <summary>
        /// Gets a value indicating whether the A value is calculating.
        /// </summary>
        public bool IsLoadingA
        {
            get
            {
                return _isLoadingA;
            }

            private set
            {
                _isLoadingA = value;
                OnPropertyChanged(nameof(IsLoadingA));
            }
        }

        /// <summary>
        /// A value indicating whether the B value is calculating.
        /// </summary>
        private bool _isLoadingB;

        /// <summary>
        /// Gets a value indicating whether the B value is calculating.
        /// </summary>
        public bool IsLoadingB
        {
            get
            {
                return _isLoadingB;
            }

            private set
            {
                _isLoadingB = value;
                OnPropertyChanged(nameof(IsLoadingB));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPropertiesViewModel"/> class.
        /// </summary>
        public AsyncPropertiesViewModel()
        {
            _asyncPropertyA = new Lazy<string>(InitAsyncPropertyA);

            Task task = InvalidateAsyncPropertyC();
        }

        /// <summary>
        /// Initializes the lazy property.
        /// </summary>
        /// <returns>Returns the async property value.</returns>
        private string InitAsyncPropertyA()
        {
            this.IsLoadingA = true;

            Task<string> task = Task.Run(() => { return GetAsyncPropertyA(); }).ContinueWith(x => { this.IsLoadingA = false; return x.Result; });

            return task.Result;
        }

        /// <summary>
        /// Calls the long running process.
        /// </summary>
        /// <returns>Returns the value calculated from the long running process.</returns>
        private async Task<string> GetAsyncPropertyA()
        {
            string result = "Async Property A";

            // Running...
            await Task.Delay(TimeSpan.FromSeconds(3));

            return result;
        }

        /// <summary>
        /// Invalidates the value of B property's.
        /// </summary>
        /// <returns>Returns the value of B property's.</returns>
        private string InvalidateAsyncPropertyB()
        {
            this.IsLoadingB = true;

            // Simple solution: /* return Task.Run(() => GetAsyncPropertyB()).Result; */
            // Very simple solution: /* return GetAsyncPropertyB().Result; */
            // /!\  This functionality can lead to deadlocks if IsAsync is not added in XAML property
            return Task.Run(() => { return GetAsyncPropertyB(); }).ContinueWith(x => { this.IsLoadingB = false; return x.Result; }).Result;
        }

        /// <summary>
        /// Calls the long running process.
        /// </summary>
        /// <returns>Returns the value calculated from the long running process.</returns>
        private async Task<string> GetAsyncPropertyB()
        {
            string result = "Async Property B";

            // Running...
            await Task.Delay(TimeSpan.FromSeconds(5));

            return result;
        }

        /// <summary>
        /// Invalidates the value of C property's.
        /// </summary>
        /// <returns>Returns the value of C property's.</returns>
        private async Task InvalidateAsyncPropertyC()
        {
            this.AsyncPropertyC = await GetAsyncPropertyC().ConfigureAwait(false);
        }

        /// <summary>
        /// Calls the long running process.
        /// </summary>
        /// <returns>Returns the value calculated from the long running process.</returns>
        private async Task<string> GetAsyncPropertyC()
        {
            string result = "Async Property C";

            // Running...
            await Task.Delay(TimeSpan.FromSeconds(4));

            return result;
        }
    }
}
