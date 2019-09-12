// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityConfigurationWriter
    {
        private readonly StreamWriter _streamWriter;
        private int _indention;

        public TeamCityConfigurationWriter(StreamWriter streamWriter)
        {
            _streamWriter = streamWriter;
        }

        public void WriteLine(string text = null)
        {
            _streamWriter.WriteLine(
                text == null
                    ? string.Empty
                    : $"{new string(c: ' ', _indention * 4)}{text}");
        }

        public IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () =>
                {
                    WriteLine(string.IsNullOrWhiteSpace(text)
                        ? "{"
                        : $"{text} {{");
                    _indention++;
                },
                () =>
                {
                    _indention--;
                    WriteLine("}");
                });
        }

        public IDisposable Indent()
        {
            return DelegateDisposable.CreateBracket(
                () => _indention++,
                () => _indention--);
        }
    }
}
