﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LionVERP.UIServer.Uedit
{
    public class ConfigHandler : Handler
    {
        public ConfigHandler(HttpContext context) : base(context) { }

        public override void Process()
        {
            WriteJson(Config.Items);
        }
    }
}