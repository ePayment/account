using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

using Account.Business;
using log4net;

namespace Account.Host
{
    public partial class EODService : ServiceBase
    {
        private Account.Business.EndOfDay _eod;
        private ILog _log;
        private System.Timers.Timer _myTimer = null;
        private String _runTime = String.Empty;

        public EODService()
        {
            InitializeComponent();
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        protected override void OnStart(string[] args)
        {
            _log.Info(string.Format("Starting service End of day"));
            // Create an AppSettingReader object.
            System.Configuration.AppSettingsReader appsreader = new System.Configuration.AppSettingsReader();

            // Lấy thời gian cho phép chạy cuối ngày
            _runTime = (String)appsreader.GetValue("RunEODTimer", _runTime.GetType());
            
            // Create timer object and set timer tick to one minute
            _myTimer = new System.Timers.Timer(60000);
            _myTimer.Elapsed += ServiceTimer_Tick;
            _myTimer.AutoReset = true;
            _myTimer.Enabled = true;
            // Khởi tạo đối tượng chạy khóa sổ
            _eod = new Account.Business.EndOfDay();
            // ghi log
            _log.Info(string.Format("Started service End of day"));
            // ghi log giờ và phút chạy
            _log.Info(string.Format("End of day run at: {0}:{1}", Convert.ToDateTime(_runTime).Hour, Convert.ToDateTime(_runTime).Minute));
        }

        protected override void OnStop()
        {
            _eod = null;
            _myTimer.AutoReset = false;
            _myTimer.Enabled = false;
            _log.Info(string.Format("Stoped service End of day"));
        }
        private void ServiceTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {

            DateTime dTimeToRun = Convert.ToDateTime(DateTime.Parse(DateTime.Now.ToString("MMM dd yyyy ") + _runTime));
            DateTime dCurrent = DateTime.Now;
            // Compare time
            if (dCurrent.Hour == dTimeToRun.Hour && dCurrent.Minute == dTimeToRun.Minute)
            {
                // ghi log
                _log.Info(string.Format("Started job End of day"));
                if (_eod.Run())
                {
                    _log.Info(string.Format("Finished job End of day"));
                    _myTimer.Enabled = true;
                }
                else
                    _log.Error(_eod.Error_Message);
            }
        }
    }
}
