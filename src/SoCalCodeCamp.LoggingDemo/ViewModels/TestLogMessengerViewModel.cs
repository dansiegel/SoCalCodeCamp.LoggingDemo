using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using SoCalCodeCamp.LoggingDemo.i18n;
using System;
using System.Collections.Generic;

namespace SoCalCodeCamp.LoggingDemo.ViewModels
{
    public class TestLogMessengerViewModel : BindableBase
    {
        private ILogger _logger { get; }
        private INavigationService _navigationService { get; }
        private IPageDialogService _pageDialogService { get; }

        public TestLogMessengerViewModel(ILogger logger, INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _logger = logger;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            SendLogCommand = new DelegateCommand(OnSendLogCommandExecuted);
            ReportSampleExceptionCommand = new DelegateCommand(OnReportSampleExceptionCommandExecuted);
        }

        private string _logMessage;
        public string LogMessage
        {
            get => _logMessage;
            set => SetProperty(ref _logMessage, value);
        }

        public DelegateCommand SendLogCommand { get; }

        public DelegateCommand ReportSampleExceptionCommand { get; }

        private void OnSendLogCommandExecuted()
        {
            _logger.Log(LogMessage, new Dictionary<string, string>());
            PromptSendOrQuit();
        }

        private void OnReportSampleExceptionCommandExecuted()
        {
            try
            {
                throw new Exception("Whoops something went wrong...");
            }
            catch (Exception ex)
            {
                _logger.Log(ex, new Dictionary<string, string>());
            }
            finally
            {
                PromptSendOrQuit();
            }
        }

        private void PromptSendOrQuit()
        {
            _pageDialogService.DisplayActionSheetAsync(AppResources.SendAnotherTest,
                ActionSheetButton.CreateButton(AppResources.Yep, () => { }),
                ActionSheetButton.CreateButton(AppResources.GetMeOuttaHere, async () => await _navigationService.GoBackAsync()));
        }
    }
}
