using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public enum WarningType
    {
        SeveralBlocksWhenFlagPressed,
        UnknownBlock,
        SeveralSprites,
        ProceduresWithSameName,
    }

    public static class WarningsLogger
    {
        private static List<string> warnings = new List<string>();

        public static void PushWarning(WarningType type, params object[] parameters)
        {
            switch(type)
            {
                case WarningType.SeveralBlocksWhenFlagPressed:
                    warnings.Add($"⚠Обнаружено несколько блоков \"Когда флаг нажат\" - {parameters[0]}.");
                    break;
                case WarningType.UnknownBlock:
                    warnings.Add($"⚠Обнаружен необрабатываемый блок {parameters[0]}.");
                    break;
                case WarningType.SeveralSprites:
                    warnings.Add($"⚠Обнаружено несколько спрайтов - {parameters[0]}.");
                    break;
                case WarningType.ProceduresWithSameName:
                    warnings.Add($"⚠Обнаружено несколько процедур с именем \"{parameters[0]}\" - {parameters[1]}.");
                    break;
            }
        }

        public static List<string> PopAllWarnings()
        {
            var allWarnings = new List<string>(warnings);
            warnings.Clear();
            return allWarnings;
        }
    }
}
