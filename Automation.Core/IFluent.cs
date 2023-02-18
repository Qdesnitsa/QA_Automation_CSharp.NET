﻿using Automation.Core.Logging;

namespace Automation.Core
{
    public interface IFluent
    {
        T ChangeContext<T>();
        T ChangeContext<T>(ILogger logger);
        T ChangeContext<T>(string application);
        T ChangeContext<T>(string application, ILogger logger);
    }
}
