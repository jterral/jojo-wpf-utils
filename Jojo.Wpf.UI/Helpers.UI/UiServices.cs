using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Jojo.Wpf.UI.Helpers.UI
{
    /// <summary>
    /// Utilitaire d'affichage d'un curseur sablier pendant le travail de l'application.
    /// </summary>
    public static class UiServices
    {
        /// <summary>
        /// Une valeur indiquant si l'application est occupée.
        /// </summary>
        private static bool isBusy;

        /// <summary>
        /// Positionne l'état en mode occupé.
        /// </summary>
        public static void SetBusyState()
        {
            SetBusyState(true);
        }

        /// <summary>
        /// Positionne l'état en mode occupé ou non.
        /// </summary>
        /// <param name="busy">Si <c>true</c> l'application est en mode occupé.</param>
        private static void SetBusyState(bool busy)
        {
            if (busy != isBusy)
            {
                isBusy = busy;
                Mouse.OverrideCursor = busy ? Cursors.Wait : null;

                if (isBusy)
                {
                    new DispatcherTimer(TimeSpan.FromSeconds(0), DispatcherPriority.ApplicationIdle, DispatcherTimerTick, Application.Current.Dispatcher);
                }
            }
        }

        /// <summary>
        /// Vérification de l'activité de l'application.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private static void DispatcherTimerTick(object sender, EventArgs e)
        {
            var dispatcherTimer = sender as DispatcherTimer;
            if (dispatcherTimer != null)
            {
                SetBusyState(false);
                dispatcherTimer.Stop();
            }
        }
    }

}
