// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.AppVeyor
{
    /// <summary>
    ///
    /// See <a href="https://www.appveyor.com/docs/services-databases">Services and databases</a>
    /// </summary>
    [PublicAPI]
    public enum AppVeyorService
    {
        MSSQL2008R2SP2,
        MSSQL2008R2SP2RS,
        MSSQL2012SP1,
        MSSQL2012SP1RS,
        MSSQL2014,
        MSSQL2014RS,
        MSSQL2016,
        MSSQL2017,
        MYSQL,
        PostgreSQL101,
        PostgreSQL,
        PostgreSQL95,
        PostgreSQL94,
        PostgreSQL93,
        MongoDB,
        IIS,
        MSMQ
    }
}
