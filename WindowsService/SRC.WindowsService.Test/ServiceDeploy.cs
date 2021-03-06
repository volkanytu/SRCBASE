﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;

namespace SAHIBINDEN.WindowsService.CallDistributer
{
    [RunInstaller(true)]
    public class ServiceDeploy : Installer
    {
        public ServiceDeploy()
        {

            string serviceName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);

            string[] splitValues = serviceName.Split('.');

            string displayName = "SRC - " + splitValues[splitValues.Length - 1];

            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.User;

            serviceInstaller.DisplayName = displayName;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.DelayedAutoStart = true;
            serviceInstaller.Description = "Test Windows servisidir.";

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = serviceName;
            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}
