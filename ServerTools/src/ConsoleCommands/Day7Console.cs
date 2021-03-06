﻿using System;
using System.Collections.Generic;

namespace ServerTools
{
    class Day7Console : ConsoleCmdAbstract
    {
        public override string GetDescription()
        {
            return "[ServerTools]- Enable or disable day7.";
        }
        public override string GetHelp()
        {
            return "Usage:\n" +
                   "  1. Day7 off\n" +
                   "  2. Day7 on\n" +
                   "1. Turn off day 7 alert\n" +
                   "2. Turn on day 7 alert\n";
        }
        public override string[] GetCommands()
        {
            return new string[] { "st-Day7", "d7", "st-d7" };
        }
        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            try
            {
                if (_params.Count != 1)
                {
                    SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Wrong number of arguments, expected 1, found {0}", _params.Count));
                    return;
                }
                if (_params[0].ToLower().Equals("off"))
                {
                    if (Day7.IsEnabled)
                    {
                        Day7.IsEnabled = false;
                        LoadConfig.WriteXml();
                        SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Day7 has been set to off"));
                        return;
                    }
                    else
                    {
                        SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Day7 is already off"));
                        return;
                    }
                }
                else if (_params[0].ToLower().Equals("on"))
                {
                    if (!Day7.IsEnabled)
                    {
                        Day7.IsEnabled = true;
                        LoadConfig.WriteXml();
                        SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Day7 has been set to on"));
                        return;
                    }
                    else
                    {
                        SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Day7 is already on"));
                        return;
                    }
                }
                else
                {
                    SdtdConsole.Instance.Output(string.Format("[SERVERTOOLS] Invalid argument {0}", _params[0]));
                }
            }
            catch (Exception e)
            {
                Log.Out(string.Format("[SERVERTOOLS] Error in Day7Console.Execute: {0}", e.Message));
            }
        }
    }
}