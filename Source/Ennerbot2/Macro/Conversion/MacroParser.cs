using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ennerbot.Conversion
{
    public class MacroParser
    {
        /// <summary>
        /// Parses a string into a list of macro actions
        /// </summary>
        /// <param name="macroString"></param>
        /// <returns></returns>
        public IList<IMacroAction> ParseString(string macroString)
        {
            var lines = (macroString ?? string.Empty).Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            return lines.Select(l => this.ParseLine(l.Trim())).ToList();
        }

        /// <summary>
        /// Parses a single macro line into a macro action
        /// </summary>
        /// <param name="macroLine"></param>
        /// <returns></returns>
        private IMacroAction ParseLine(string macroLine)
        {
            var chunks = new Regex("[^ \"]+|\".*\"")
                .Matches(macroLine)
                .Cast<Match>()
                .Select(m => m.Value.StartsWith("\"") ? m.Value.Substring(1, m.Value.Length - 2) : m.Value)
                .ToList();

            // Switch on the first argument
            switch (chunks[0])
            {
                case "CALL":
                    return chunks.Count > 3
                        ? new CallMethodAction(chunks[1], int.Parse(chunks[3]))
                        : new CallMethodAction(chunks[1]);
                case "TEXT":
                    return new SendTextAction(chunks[1]);
                case "KEY":
                    return new SimulateKeyAction((VirtualKeys) Enum.Parse(typeof(VirtualKeys), chunks[1]));
                case "WAIT":
                {
                    return chunks[1].Contains(":")
                        ? new WaitAction(TimeSpan.Parse(chunks[1]))
                        : new WaitAction(int.Parse(chunks[1]));
                }
                default:
                    throw new ArgumentException(string.Format("Command {0} is not a valid macro action", chunks[0]));
            }
        }
    }
}
