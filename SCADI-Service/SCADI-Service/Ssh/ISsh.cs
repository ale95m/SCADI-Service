﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Ssh
{
    interface ISsh
    {
        bool Connect();
        bool Disconnect();
        bool ExecuteCommand(string command);
        string ExecuteResponseCommand(string command);
    }
}
