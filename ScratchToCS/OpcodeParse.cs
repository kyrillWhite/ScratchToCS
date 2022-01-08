﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchToCS
{
    public enum Opcode
    {
        Null,
        ControlForever,
        ControlRepeat,
        ControlIf,
        ControlIfelse,
        ControlStop,
        ControlWait,
        ControlWaituntil,
        ControlRepeatuntil,
        DataSetvariableto,
        DataChangevariableby,
        DataAddtolist,
        DataDeleteoflist,
        DataDeletealloflist,
        DataInsertatlist,
        DataReplaceitemoflist,
        DataItemoflist,
        DataItemnumoflist,
        DataLengthoflist,
        DataListcontainsitem,
        EventWhenflagclicked,
        LooksSayforsecs,
        LooksSay,
        LooksThinkforsecs,
        LooksThink,
        OperatorAdd,
        OperatorSubtract,
        OperatorMultiply,
        OperatorDivide,
        OperatorRandom,
        OperatorLt,
        OperatorEquals,
        OperatorGt,
        OperatorAnd,
        OperatorOr,
        OperatorNot,
        OperatorJoin,
        OperatorLetterOf,
        OperatorLength,
        OperatorContains,
        OperatorMod,
        OperatorRound,
        OperatorMathop,
        ProceduresDefinition,
        ProceduresPrototype,
        ProceduresCall,
        ArgumentReporterBoolean,
        ArgumentReporterStringNumber,
        SensingAskandwait,
        SensingAnswer
    }

    public static class OpcodeParse
    {
        public static Dictionary<string, Opcode> FromString = new Dictionary<string, Opcode>
        {
            ["control_forever"] = Opcode.ControlForever,
            ["control_repeat"] = Opcode.ControlRepeat,
            ["control_if"] = Opcode.ControlIf,
            ["control_if_else"] = Opcode.ControlIfelse,
            ["control_stop"] = Opcode.ControlStop,
            ["control_wait"] = Opcode.ControlWait,
            ["control_wait_until"] = Opcode.ControlWaituntil,
            ["control_repeat_until"] = Opcode.ControlRepeatuntil,
            ["data_setvariableto"] = Opcode.DataSetvariableto,
            ["data_changevariableby"] = Opcode.DataChangevariableby,
            ["data_addtolist"] = Opcode.DataAddtolist,
            ["data_deleteoflist"] = Opcode.DataDeleteoflist,
            ["data_deletealloflist"] = Opcode.DataDeletealloflist,
            ["data_insertatlist"] = Opcode.DataInsertatlist,
            ["data_replaceitemoflist"] = Opcode.DataReplaceitemoflist,
            ["data_itemoflist"] = Opcode.DataItemoflist,
            ["data_itemnumoflist"] = Opcode.DataItemnumoflist,
            ["data_lengthoflist"] = Opcode.DataLengthoflist,
            ["data_listcontainsitem"] = Opcode.DataListcontainsitem,
            ["event_whenflagclicked"] = Opcode.EventWhenflagclicked,
            ["looks_sayforsecs"] = Opcode.LooksSayforsecs,
            ["looks_say"] = Opcode.LooksSay,
            ["looks_thinkforsecs"] = Opcode.LooksThinkforsecs,
            ["looks_think"] = Opcode.LooksThink,
            ["operator_add"] = Opcode.OperatorAdd,
            ["operator_subtract"] = Opcode.OperatorSubtract,
            ["operator_multiply"] = Opcode.OperatorMultiply,
            ["operator_divide"] = Opcode.OperatorDivide,
            ["operator_random"] = Opcode.OperatorRandom,
            ["operator_lt"] = Opcode.OperatorLt,
            ["operator_equals"] = Opcode.OperatorEquals,
            ["operator_gt"] = Opcode.OperatorGt,
            ["operator_and"] = Opcode.OperatorAnd,
            ["operator_or"] = Opcode.OperatorOr,
            ["operator_not"] = Opcode.OperatorNot,
            ["operator_join"] = Opcode.OperatorJoin,
            ["operator_letter_of"] = Opcode.OperatorLetterOf,
            ["operator_length"] = Opcode.OperatorLength,
            ["operator_contains"] = Opcode.OperatorContains,
            ["operator_mod"] = Opcode.OperatorMod,
            ["operator_round"] = Opcode.OperatorRound,
            ["operator_mathop"] = Opcode.OperatorMathop,
            ["procedures_definition"] = Opcode.ProceduresDefinition,
            ["procedures_prototype"] = Opcode.ProceduresPrototype,
            ["procedures_call"] = Opcode.ProceduresCall,
            ["argument_reporter_boolean"] = Opcode.ArgumentReporterBoolean,
            ["argument_reporter_string_number"] = Opcode.ArgumentReporterStringNumber,
            ["sensing_askandwait"] = Opcode.SensingAskandwait,
            ["sensing_answer"] = Opcode.SensingAnswer
        };

        public static Dictionary<string, string> MathFunc = new Dictionary<string, string>
        {
            ["abs"] = "Abs",
            ["floor"] = "Floor",
            ["ceiling"] = "Ceiling",
            ["sqrt"] = "Sqrt",
            ["sin"] = "Sin",
            ["cos"] = "Cos",
            ["tan"] = "Tan",
            ["asin"] = "Asin",
            ["acos"] = "Acos",
            ["atan"] = "Atan",
            ["ln"] = "Ln",
            ["log"] = "Log",
            ["e ^"] = "Exp",
            ["10 ^"] = "TenPow"
        };
    }
}