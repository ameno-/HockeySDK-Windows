﻿namespace Microsoft.HockeyApp
{
    using System;
    using Windows.UI.Xaml;
    using Services;
    using Channel;
    using DataContracts;
    internal class UnhandledExceptionTelemetryModule : IUnhandledExceptionTelemetryModule
    {
        private bool initialized;

        internal static Func<UnhandledExceptionEventArgs, bool> CustomUnhandledExceptionFunc
        {
            get; set;
        }

        public ITelemetry CreateCrashTelemetry(Exception exception, ExceptionHandledAt handledAt)
        {
            return new ExceptionTelemetry(exception) { HandledAt = handledAt };
        }

        public void Initialize()
        {
            if (!initialized)
            {
                Application.Current.UnhandledException += async (sender, e) =>
                {
                    e.Handled = true;
                    await HockeyClient.Current.AsInternal().HandleExceptionAsync(e.Exception);
                    if (CustomUnhandledExceptionFunc == null || CustomUnhandledExceptionFunc(e))
                    {
                        Application.Current.Exit();
                    }
                };

                initialized = true;
            }
        }
    }
}
