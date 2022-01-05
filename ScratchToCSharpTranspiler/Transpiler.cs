using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Globalization;
using System.Threading;

namespace SToCSTranspiler
{
    public static class Transpiler
    {
        /// <summary>
        /// Изменяет строковое представление значений NaN, Infinity и -Infinity.
        /// </summary>
        public static void ChangeSpecValues()
        {
            CultureInfo myCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            myCulture.NumberFormat.NaNSymbol = "NaN";
            myCulture.NumberFormat.NegativeInfinitySymbol = "-Infinity";
            myCulture.NumberFormat.PositiveInfinitySymbol = "Infinity";
            myCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;
        }

        /// <summary>
        /// Извлекает строку Json из файла формата .sb3.
        /// </summary>
        /// <param name="path">Путь до файла формата .sb3.</param>
        /// <returns>Строка в формате Json.</returns>
        public static string ScratchToJson(string path)
        {
            var unzipDirrectory = Directory.GetCurrentDirectory() + "/unzipped";
            if (Directory.Exists(unzipDirrectory))
            {
                Directory.Delete(unzipDirrectory, true);
            }
            ZipFile.ExtractToDirectory(path, unzipDirrectory);
            var json = File.ReadAllText(unzipDirrectory + "/project.json");
            Directory.Delete(unzipDirrectory, true);
            return json;
        }

        /// <summary>
        /// Преобразует Json строку в набор объектов.
        /// </summary>
        /// <param name="json">Строка в формате Json.</param>
        /// <returns>Объект класса <see cref = "DScratch"/>, содержащий словари переменых, списков и блоков.</returns>
        public static DScratch JsonToDScratch(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var targets = root.GetProperty("targets").EnumerateArray().ToList();
            if (targets.Count < 2)
            {
                return null; // Спрайт был удален
            }
            var stageTarget = targets[0]; 
            var spriteTarget = targets[1];

            // Глобальные переменные и списки хранятся в сцене,
            // но есть возможность создавать их с привязкой к спрайту.
            var dStVariables = GetVariables(stageTarget);
            var dSpVariables = GetVariables(spriteTarget);
            var dVariables = new Dictionary<string, SVariable>(dStVariables.Concat(dSpVariables));

            var dStLists = GetLists(stageTarget);
            var dSpLists = GetLists(spriteTarget);
            var dLists = new Dictionary<string, SList>(dStLists.Concat(dSpLists));

            // Учитываются только блоки спрайта
            var dBlocks = GetBlocks(spriteTarget);

            return new DScratch(dVariables, dLists, dBlocks);
        }

        /// <summary>
        /// Конвертирует значение Json узла в dynamic.
        /// </summary>
        /// <param name="je">Json узел, имеющий значение.</param>
        /// <returns>Значение из Json узла.</returns>
        private static dynamic GetUTValue(JsonElement je)
        {
            switch (je.ValueKind)
            {
                case JsonValueKind.Number:
                    return je.GetDouble();
                case JsonValueKind.String:
                    return je.GetString();
                case JsonValueKind.True:
                    return je.GetRawText();
                case JsonValueKind.False:
                    return je.GetRawText();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Находит все переменные у переданной цели и сохраняет их в словарь.
        /// </summary>
        /// <param name="target">Узел Json, содержащий scratch-скрипт.</param>
        /// <returns>Словарь переменных.</returns>
        private static Dictionary<string, SVariable> GetVariables(JsonElement target)
        {
            JsonElement jVariables;
            if (!target.TryGetProperty("variables", out jVariables))
            {
                return null;
            }
            var lVariables = jVariables.EnumerateObject().ToList();
            var dVariables = new Dictionary<string, SVariable>();
            foreach (var lVariable in lVariables)
            {
                var lvElements = lVariable.Value.EnumerateArray().ToList();
                var name = lvElements[0].GetString();
                dynamic value = GetUTValue(lvElements[1]);
                dVariables[lVariable.Name] = new SVariable(name, value);
            }
            return dVariables;
        }

        /// <summary>
        /// Находит все списки у переданной цели и сохраняет их в словарь.
        /// </summary>
        /// <param name="target">Узел Json, содержащий scratch-скрипт.</param>
        /// <returns>Словарь списков.</returns>
        private static Dictionary<string, SList> GetLists(JsonElement target)
        {
            JsonElement jLists;
            if (!target.TryGetProperty("lists", out jLists))
            {
                return null;
            }
            var lLists = jLists.EnumerateObject().ToList();
            var dLists = new Dictionary<string, SList>();
            foreach (var lList in lLists)
            {
                var llElements = lList.Value.EnumerateArray().ToList();
                var name = llElements[0].GetString();
                var list = new List<dynamic>();
                var jList = llElements[1].EnumerateArray().ToList();
                foreach(var jValue in jList)
                {
                    list.Add(GetUTValue(jValue));
                }
                dLists[lList.Name] = new SList(name, list);
            }
            return dLists;
        }

        /// <summary>
        /// Находит все блоки у переданной цели и сохраняет их в словарь.
        /// </summary>
        /// <param name="target">Узел Json, содержащий scratch-скрипт.</param>
        /// <returns>Словарь блоков.</returns>
        private static Dictionary<string, SBlock> GetBlocks(JsonElement target)
        {
            JsonElement jBlocks;
            if (!target.TryGetProperty("blocks", out jBlocks))
            {
                return null;
            }
            var lBlocks = jBlocks.EnumerateObject().ToList();
            var dBlocks = new Dictionary<string, SBlock>();
            foreach (var lBlock in lBlocks)
            {
                if (lBlock.Value.ValueKind == JsonValueKind.Array)
                {
                    continue;
                }

                var opcode = lBlock.Value.GetProperty("opcode").GetString();
                var parentId = lBlock.Value.GetProperty("parent").GetString();
                var nextId = lBlock.Value.GetProperty("next").GetString();
                var lInputs = lBlock.Value.GetProperty("inputs").EnumerateObject().ToList();
                var lFields = lBlock.Value.GetProperty("fields").EnumerateObject().ToList();

                var dlInputs = new Dictionary<string, SInput>();
                var llFields = new List<SField>();

                if (!OpcodeParse.FromString.ContainsKey(opcode))
                {
                    dBlocks.Add(lBlock.Name, new SBlock(Opcode.Null, nextId, parentId, dlInputs, llFields, null));
                    continue;
                }
                foreach (var input in lInputs)
                {
                    // Вводимые значения могут быть константами явно введенными в поле (1) (в некоторых случаях является блоком)
                    // или перенесенными в поле блоками (2) (блоками или перемеменными, или списками)
                    var lInput = input.Value.EnumerateArray().ToList();
                    var shadow = lInput[0].GetInt32() == 1;
                    dynamic value;
                    TypeOfInput type;

                    if (shadow)
                    {
                        if (lInput[1].ValueKind == JsonValueKind.Array) // Константа
                        {
                            var lConstValue = lInput[1].EnumerateArray().ToList();
                            var cValueType = lConstValue[0].GetInt32(); // 4 - число, 10 - строка
                            var cValue = lConstValue[1].GetString();
                            if (cValueType == 4)
                            {
                                //double dvalue = 0;
                                //double.TryParse(cValue, NumberStyles.Float, null, out dvalue);
                                //value = dvalue;
                                //type = TypeOfInput.Number;
                                value = cValue;
                                type = TypeOfInput.Number;
                            }
                            else
                            {
                                value = cValue;
                                type = TypeOfInput.String;
                            }
                        }
                        else // Блок
                        {
                            value = lInput[1].GetString();
                            type = TypeOfInput.Block;
                        }
                    }
                    else
                    {
                        if (lInput[1].ValueKind == JsonValueKind.Array) // Переменная или список
                        {
                            var lVarValue = lInput[1].EnumerateArray().ToList();
                            var vValueType = lVarValue[0].GetInt32(); // 12 - переменная, 13 - строка
                            var vValue = lVarValue[2].GetString(); // [1] - название, [2] - id
                            if (vValueType == 12)
                            {
                                value = vValue;
                                type = TypeOfInput.Variable;
                            }
                            else
                            {
                                value = vValue;
                                type = TypeOfInput.List;
                            }
                        }
                        else // Блок
                        {
                            value = lInput[1].GetString();
                            type = TypeOfInput.Block;
                        }
                    }
                    dlInputs.Add(input.Name, new SInput(shadow, value, type));
                }

                foreach (var field in lFields)
                {
                    var lField = field.Value.EnumerateArray().ToList();
                    var name = lField[0].GetString();
                    var id = lField[1].ValueKind == JsonValueKind.Null ? null : lField[1].GetString();
                    llFields.Add(new SField(name, id));
                }

                JsonElement jMutation;
                SMutation mutation = null;
                if (lBlock.Value.TryGetProperty("mutation", out jMutation))
                {
                    JsonElement jProccode;
                    if(jMutation.TryGetProperty("proccode", out jProccode))
                    {
                        var proccode = jProccode.ToString();
                        var arguments = jMutation.GetProperty("argumentids").GetString();
                        List<string> lArguments;
                        if (arguments != "[]")
                        {
                            arguments = arguments.Remove(arguments.Length - 2, 2);
                            arguments = arguments.Remove(0, 2);
                            lArguments = arguments.Split("\",\"").ToList();
                        }
                        else
                        {
                            lArguments = new List<string>();
                        }

                        JsonElement jArgumentNames;
                        List<string> lArgumentNames = new List<string>(); ;
                        if (jMutation.TryGetProperty("argumentnames", out jArgumentNames))
                        {
                            var argumentNames = jArgumentNames.GetString();
                            if (argumentNames != "[]")
                            {
                                argumentNames = argumentNames.Remove(argumentNames.Length - 2, 2);
                                argumentNames = argumentNames.Remove(0, 2);
                                lArgumentNames = argumentNames.Split("\",\"").ToList();
                            }
                        }

                        mutation = new SMutation(proccode, lArguments, lArgumentNames);
                    }
                }

                dBlocks.Add(lBlock.Name, new SBlock(OpcodeParse.FromString[opcode], nextId, parentId, dlInputs, llFields, mutation));
            }
            return dBlocks;
        }
    
        /// <summary>
        /// Генерирует дерево выражений из словарей блоков и переменных.
        /// </summary>
        /// <param name="dScratch">Набор словарей блоков, переменных и списков.</param>
        /// <returns>Лямда функция дерева выражений.</returns>
        public static Expression<Func<CancellationToken, List<object>, List<object>>> DScratchToExpression(DScratch dScratch)
        {
            var startProgBlock = dScratch.Blocks.FirstOrDefault(b => b.Value.Opcode == Opcode.EventWhenflagclicked).Value;
            if (startProgBlock == null)
            {
                return null; // Программа не имеет начала
            }

            var dMainVariables = new Dictionary<string, ParameterExpression>();
            var lMainExpressions = new List<Expression>();

            var returnTarget = Expression.Label(); // Метка окончания программы

            // Создание пременных
            foreach (var variable in dScratch.Variables)
            {
                dMainVariables.Add(variable.Key, Expression.Parameter(typeof(object), variable.Value.Name));
            }
            // Создание списков
            foreach (var list in dScratch.Lists)
            {
                dMainVariables.Add(list.Key, Expression.Parameter(typeof(List<object>), list.Value.Name));
            }
            // Создание переменной answer, в которую будут передаваться "введенные" данные
            var answerExpression = Expression.Parameter(typeof(object), "ANSWER");
            dMainVariables.Add("ANSWER", answerExpression);

            // Создание списка ввода. Операторы sensing будут запрашивать данные из этого списка.
            // Также является обязательным аргументом лямбда выражения.
            var lInputExpression = Expression.Parameter(typeof(List<object>), "INPUTS");

            // Создание токена отмены.
            var cancelTokenExpression = Expression.Parameter(typeof(CancellationToken), "CANCEL_TOKEN");

            // Создание списка вывода. Операторы вывода будут отправлять в него данные.
            var lOutputExpression = Expression.Parameter(typeof(List<object>), "OUTPUTS");
            dMainVariables.Add("OUTPUTS", lOutputExpression);

            // Список переменных не включает в себя вводимый аргумент.
            var lMainVariables = dMainVariables.Select(v => v.Value).ToList(); 

            // Инициализация переменных и списков
            foreach (var variable in dMainVariables)
            {
                Expression value = variable.Value.Type == typeof(List<object>) ?
                    Expression.New(typeof(List<object>)) :
                    Expression.Constant(0, typeof(object));
                lMainExpressions.Add(Expression.Assign(variable.Value, value));
            }
            lMainExpressions.Add(Expression.Assign(dMainVariables["ANSWER"], Expression.Constant("", typeof(object))));
            // INPUTS нельзя инициализировать, т.к. он является аргументом лямбда функции
            dMainVariables.Add("INPUTS", lInputExpression);
            dMainVariables.Add("CANCEL_TOKEN", cancelTokenExpression);

            // Создание словаря функций
            var dFuncExpressions = new Dictionary<string, EFunc>();
            var dFuncNames = dScratch.Blocks.Where(b => b.Value.Opcode == Opcode.ProceduresDefinition)
                .Select(b => (b.Key, dScratch.Blocks[b.Value.Inputs["custom_block"].Value as string].Mutation));
            foreach (var fName in dFuncNames)
            {
                var pFunc = Expression.Variable(typeof(Func<List<object>, bool>), fName.Mutation.Proccode);
                var pArgs = Expression.Parameter(typeof(List<object>), "args");
                var returnVar = Expression.Variable(typeof(bool), "returnVar");
                var curReturnTarget = Expression.Label("localReturnTarget");
                dFuncExpressions.Add(fName.Mutation.Proccode, new EFunc(pFunc, pArgs, returnVar, curReturnTarget, fName.Mutation));
            }

            // Инициализация параметров функций
            foreach (var funcExpr in dFuncExpressions) {

                lMainExpressions.Add(Expression.Assign(funcExpr.Value.Parameter, Expression.New(typeof(List<object>))));
                foreach (var an in funcExpr.Value.PrototypeMutation.ArgumentNames)
                {
                    lMainExpressions.Add(Expression.Call(funcExpr.Value.Parameter, "Add", null,
                        Expression.Constant(0, typeof(object))));
                }
            }

            // Инициализация функций
            foreach (var func in dFuncExpressions)
            {
                var expressions = GetExpressionsFromBlock(dScratch.Blocks[dFuncNames.First(n => n.Mutation.Proccode == func.Key).Key],
                                                                           dScratch, dMainVariables, dFuncExpressions,
                                                                           func.Value.CurrentReturnTarget, func.Value);
                expressions.Insert(0, Expression.Assign(func.Value.ReturnVariable, Expression.Constant(false, typeof(bool))));
                expressions.Add(Expression.Label(func.Value.CurrentReturnTarget));
                expressions.Add(func.Value.ReturnVariable);
                var localVariables = new List<ParameterExpression>();
                localVariables.Add(func.Value.ReturnVariable);

                var bExpressions = Expression.Block(localVariables, expressions);
                var eBlock = Expression.Block(
                    Expression.Assign(
                        func.Value.Function,
                        Expression.Lambda<Func<List<object>, bool>>(
                            bExpressions, // Содержимое функции
                            func.Value.Parameter
                            )
                        )
                    );
                lMainExpressions.Add(eBlock);
            }
            foreach (var func in dFuncExpressions)
            {
                lMainVariables.Add(func.Value.Parameter);
                lMainVariables.Add(func.Value.Function);
            }

            lMainExpressions.AddRange(GetExpressionsFromBlock(startProgBlock, dScratch, dMainVariables, dFuncExpressions, returnTarget));

            lMainExpressions.Add(Expression.Label(returnTarget));
            lMainExpressions.Add(lOutputExpression); // Возвращаемое значение

            var mainFuncBlock = Expression.Block(lMainVariables, lMainExpressions);
            return Expression.Lambda<Func<CancellationToken, List<object>, List<object>>>(mainFuncBlock, cancelTokenExpression, lInputExpression);
        }

        /// <summary>
        /// Находит все блоки от одного предка и конвертирует их в выражения.
        /// </summary>
        /// <param name="block">Блок-предок.</param>
        /// <param name="dScratch">Словари блоков, переменных, списков.</param>
        /// <param name="gVariables">Словарь глобальных переменных в виде выражений.</param>
        /// <param name="gFunc">Словарь функций и их аргументов в виде выражений.</param>
        /// <param name="returnTarget">Метка прекращения выполнения программы.</param>
        /// <param name="calledEFunc">Блок процедуры. Указывается, если запрашивается его поддерево.</param>
        /// <returns>Список выражений соответсвующий блокам.</returns>
        private static List<Expression> GetExpressionsFromBlock(SBlock block, DScratch dScratch,
                                                                Dictionary<string, ParameterExpression> gVariables,
                                                                Dictionary<string, EFunc> gFunc,
                                                                LabelTarget returnTarget, EFunc calledEFunc = null)
        {
            var expressions = new List<Expression>();
            var currentBlock = block;
            while (true)
            {
                var bExpression = GetExpressionFromBlock(currentBlock, dScratch, gVariables, gFunc, returnTarget, calledEFunc);
                if (bExpression != null)
                {
                    expressions.Add(bExpression);
                }

                if (currentBlock.NextId == null)
                {
                    break;
                }
                else
                {
                    currentBlock = dScratch.Blocks[currentBlock.NextId];
                }
            }
            return expressions;
        }
        /// <summary>
        /// Конвертирует блок в соответствующее выражение.
        /// </summary>
        /// <param name="block">Конвертируемый блок.</param>
        /// <param name="dScratch">Словари блоков, переменных, списков.</param>
        /// <param name="gVariables">Словарь глобальных переменных в виде выражений.</param>
        /// <param name="gFunc">Словарь функций и их аргументов в виде выражений.</param>
        /// <param name="returnTarget">Метка прекращения выполнения программы.</param>
        /// <param name="calledEFunc">Блок процедуры. Указывается, если запрашивается его поддерево.</param>
        /// <returns>Выражение соответствующее блоку.</returns>
        private static Expression GetExpressionFromBlock(SBlock block, DScratch dScratch,
                                                         Dictionary<string, ParameterExpression> gVariables,
                                                         Dictionary<string, EFunc> gFunc,
                                                         LabelTarget returnTarget, EFunc calledEFunc = null)
        {
            Expression expression = Expression.Constant("", typeof(object));
            switch (block.Opcode)
            {
                case Opcode.ControlForever:
                    {
                        var lExpressions = block.Inputs.ContainsKey("SUBSTACK") && block.Inputs["SUBSTACK"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>();

                        // Проверка времени выполнения
                        var isCancellationRequested = Expression.Property(gVariables["CANCEL_TOKEN"], "IsCancellationRequested");
                        var cancelCondition = Expression.IfThen(isCancellationRequested, Expression.Return(returnTarget));
                        lExpressions.Add(cancelCondition);

                        expression = Expression.Loop(Expression.Block(lExpressions));
                        break;
                    }
                case Opcode.ControlRepeat:
                    {
                        var count = GetInputExpression(block.Inputs["TIMES"], dScratch, gVariables, gFunc, returnTarget);
                        var lExpressions = block.Inputs.ContainsKey("SUBSTACK") && block.Inputs["SUBSTACK"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>();
                        var i = Expression.Variable(typeof(int), "i"); // Локальная переменная "i"
                        var endLoop = Expression.Label(); // Метка для выхода из цикла
                
                        var loopBody = new List<Expression>(); // Содержимое цикла
                        loopBody.Add(Expression.IfThen(Expression.GreaterThan(i, Expression.Call(typeof(Operations), "ToInt", null, count)),
                                        Expression.Break(endLoop)));
                        loopBody.AddRange(lExpressions);
                        loopBody.Add(Expression.PostIncrementAssign(i));

                        // Проверка времени выполнения
                        var isCancellationRequested = Expression.Property(gVariables["CANCEL_TOKEN"], "IsCancellationRequested");
                        var cancelCondition = Expression.IfThen(isCancellationRequested, Expression.Return(returnTarget));
                        loopBody.Add(cancelCondition);

                        expression = Expression.Block(
                            new[] { i },
                            Expression.Assign(i, Expression.Constant(1)),
                            Expression.Loop(
                                Expression.Block(loopBody),
                                endLoop
                                )
                            );
                        break;
                    }
                
                case Opcode.ControlIf:
                    {
                        var condition = block.Inputs.ContainsKey("CONDITION") && block.Inputs["CONDITION"].Value != null ?
                            GetInputExpression(block.Inputs["CONDITION"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        var lExpressions = block.Inputs.ContainsKey("SUBSTACK") && block.Inputs["SUBSTACK"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>();
                        var ifBody = Expression.Block(lExpressions);
                        expression = Expression.IfThen(Expression.Call(typeof(Operations), "ToBool", null, condition), ifBody);
                        break;
                    }
                case Opcode.ControlIfelse:
                    {
                        var condition = block.Inputs.ContainsKey("CONDITION") && block.Inputs["CONDITION"].Value != null ?
                            GetInputExpression(block.Inputs["CONDITION"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        var lExpressionsT = block.Inputs.ContainsKey("SUBSTACK") && block.Inputs["SUBSTACK"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>();
                        var lExpressionsF = block.Inputs.ContainsKey("SUBSTACK2") && block.Inputs["SUBSTACK2"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK2"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>();
                        var ifBody = Expression.Block(lExpressionsT);
                        var elseBody = Expression.Block(lExpressionsF);
                        expression = Expression.IfThenElse(Expression.Call(typeof(Operations), "ToBool", null, condition), ifBody, elseBody);
                        break;
                    }
                case Opcode.ControlStop:
                    {
                        if (calledEFunc is not null)
                        {
                            expression = Expression.Block(
                                Expression.Assign(calledEFunc.ReturnVariable, Expression.Constant(true, typeof(bool))),
                                Expression.Return(returnTarget));
                        }
                        else
                        {
                            expression = Expression.Return(returnTarget);
                        }
                        break;
                    }
                case Opcode.ControlRepeatuntil:
                    {
                        var condition = block.Inputs.ContainsKey("CONDITION") && block.Inputs["CONDITION"].Value != null ?
                            GetInputExpression(block.Inputs["CONDITION"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        var lExpressions = block.Inputs.ContainsKey("SUBSTACK") && block.Inputs["SUBSTACK"].Value != null ?
                            GetExpressionsFromBlock(dScratch.Blocks[block.Inputs["SUBSTACK"].Value], dScratch, gVariables, gFunc, returnTarget, calledEFunc) :
                            new List<Expression>(); 
                        var endLoop = Expression.Label(); // Метка для выхода из цикла
                        var loopBody = new List<Expression>(); // Содержимое цикла
                        loopBody.Add(Expression.IfThen(Expression.Call(typeof(Operations), "ToBool", null, condition),
                                        Expression.Break(endLoop)));
                        loopBody.AddRange(lExpressions);

                        // Проверка времени выполнения
                        var isCancellationRequested = Expression.Property(gVariables["CANCEL_TOKEN"], "IsCancellationRequested");
                        var cancelCondition = Expression.IfThen(isCancellationRequested, Expression.Return(returnTarget));
                        loopBody.Add(cancelCondition);

                        expression = Expression.Loop(Expression.Block(loopBody), endLoop);
                        break;
                    }
                case Opcode.DataSetvariableto:
                    {
                        var variable = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "SetVariableTo", null, variable, value);
                        break;
                    }
                case Opcode.DataChangevariableby:
                    {
                        var variable = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "ChangeVariableBy", null, variable, value);
                        break;
                    }
                case Opcode.DataAddtolist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "AddToList", null, list, value);
                        break;
                    }
                case Opcode.DataDeleteoflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var index = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "DeleteOfList", null, list, index);
                        break;
                    }
                case Opcode.DataDeletealloflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        expression = Expression.Call(typeof(Operations), "DeleteAllOfList", null, list);
                        break;
                    }
                case Opcode.DataInsertatlist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs["ITEM"], dScratch, gVariables, gFunc, returnTarget);
                        var index = GetInputExpression(block.Inputs["INDEX"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "InsertAtList", null, list, index, value);
                        break;
                    }
                case Opcode.DataReplaceitemoflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var index = GetInputExpression(block.Inputs["INDEX"], dScratch, gVariables, gFunc, returnTarget);
                        var value = GetInputExpression(block.Inputs["ITEM"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "ReplaceItemOfList", null, list, index, value);
                        break;
                    }
                case Opcode.DataItemoflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var index = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "ItemOfList", null, list, index);
                        break;
                    }
                case Opcode.DataItemnumoflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "ItemNumOfList", null, list, value);
                        break;
                    }
                case Opcode.DataLengthoflist:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        expression = Expression.Call(typeof(Operations), "LengthOfList", null, list);
                        break;
                    }
                case Opcode.DataListcontainsitem:
                    {
                        var list = GetFieldExpression(block.Fields[0], gVariables);
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "ListContainsItem", null, list, value);
                        break;
                    }
                case Opcode.OperatorAdd:
                    {
                        var firstValue = GetInputExpression(block.Inputs["NUM1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["NUM2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Add", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorSubtract:
                    {
                        var firstValue = GetInputExpression(block.Inputs["NUM1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["NUM2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Subtract", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorMultiply:
                    {
                        var firstValue = GetInputExpression(block.Inputs["NUM1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["NUM2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Multiply", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorDivide:
                    {
                        var firstValue = GetInputExpression(block.Inputs["NUM1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["NUM2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Divide", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorRandom:
                    {
                        var firstValue = GetInputExpression(block.Inputs["FROM"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["TO"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Random", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorLt:
                    {
                        var firstValue = GetInputExpression(block.Inputs["OPERAND1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["OPERAND2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Lt", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorGt:
                    {
                        var firstValue = GetInputExpression(block.Inputs["OPERAND1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["OPERAND2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Gt", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorEquals:
                    {
                        var firstValue = GetInputExpression(block.Inputs["OPERAND1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["OPERAND2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Equal", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorAnd:
                    {
                        var firstValue = block.Inputs.ContainsKey("OPERAND1") && block.Inputs["OPERAND1"].Value != null ?
                            GetInputExpression(block.Inputs["OPERAND1"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        var secondValue = block.Inputs.ContainsKey("OPERAND2") && block.Inputs["OPERAND2"].Value != null ?
                            GetInputExpression(block.Inputs["OPERAND2"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        expression = Expression.Call(typeof(Operations), "And", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorOr:
                    {
                        var firstValue = block.Inputs.ContainsKey("OPERAND1") && block.Inputs["OPERAND1"].Value != null ?
                            GetInputExpression(block.Inputs["OPERAND1"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        var secondValue = block.Inputs.ContainsKey("OPERAND2") && block.Inputs["OPERAND2"].Value != null ? 
                            GetInputExpression(block.Inputs["OPERAND2"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        expression = Expression.Call(typeof(Operations), "Or", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorNot:
                    {
                        var value = block.Inputs.ContainsKey("OPERAND") && block.Inputs["OPERAND"].Value != null ?
                            GetInputExpression(block.Inputs["OPERAND"], dScratch, gVariables, gFunc, returnTarget) :
                            Expression.Constant(false, typeof(object));
                        expression = Expression.Call(typeof(Operations), "Not", null, value);
                        break;
                    }
                case Opcode.OperatorJoin:
                    {
                        var firstValue = GetInputExpression(block.Inputs["STRING1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["STRING2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Join", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorLetterOf:
                    {
                        var index = GetInputExpression(block.Inputs["LETTER"], dScratch, gVariables, gFunc, returnTarget);
                        var value = GetInputExpression(block.Inputs["STRING"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "LetterOf", null, value, index);
                        break;
                    }
                case Opcode.OperatorLength:
                    {
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Length", null, value);
                        break;
                    }
                case Opcode.OperatorContains:
                    {
                        var firstValue = GetInputExpression(block.Inputs["STRING1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["STRING2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Contains", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorMod:
                    {
                        var firstValue = GetInputExpression(block.Inputs["NUM1"], dScratch, gVariables, gFunc, returnTarget);
                        var secondValue = GetInputExpression(block.Inputs["NUM2"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Mod", null, firstValue, secondValue);
                        break;
                    }
                case Opcode.OperatorRound:
                    {
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "Round", null, value);
                        break;
                    }
                case Opcode.OperatorMathop:
                    {
                        var value = GetInputExpression(block.Inputs.First().Value, dScratch, gVariables, gFunc, returnTarget);
                        var mathop = block.Fields[0].Name;
                        expression = Expression.Call(typeof(Operations), OpcodeParse.MathFunc[mathop], null, value);
                        break;
                    }
                case Opcode.SensingAskandwait:
                    {
                        expression = Expression.Block(
                            Expression.Assign(
                                gVariables["ANSWER"],
                                Expression.Call(typeof(Operations), "ItemOfList", null,
                                    gVariables["INPUTS"],
                                    Expression.Constant(1, typeof(object)))),
                            Expression.Call(typeof(Operations), "DeleteOfList", null,
                                gVariables["INPUTS"],
                                Expression.Constant(1, typeof(object)))
                        );
                        break;
                    }
                case Opcode.SensingAnswer:
                    {
                        expression = gVariables["ANSWER"];
                        break;
                    }
                case Opcode.LooksSay:
                    {
                        var value = GetInputExpression(block.Inputs["MESSAGE"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "AddToList", null, gVariables["OUTPUTS"], value);
                        break;
                    }
                case Opcode.LooksSayforsecs:
                    {
                        var value = GetInputExpression(block.Inputs["MESSAGE"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "AddToList", null, gVariables["OUTPUTS"], value);
                        break;
                    }
                case Opcode.LooksThink:
                    {
                        var value = GetInputExpression(block.Inputs["MESSAGE"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "AddToList", null, gVariables["OUTPUTS"], value);
                        break;
                    }
                case Opcode.LooksThinkforsecs:
                    {
                        var value = GetInputExpression(block.Inputs["MESSAGE"], dScratch, gVariables, gFunc, returnTarget);
                        expression = Expression.Call(typeof(Operations), "AddToList", null, gVariables["OUTPUTS"], value);
                        break;
                    }
                case Opcode.ProceduresCall:
                    {
                        var eFunc = gFunc[block.Mutation.Proccode];

                        var llArgs = block.Inputs.Where(i => i.Value.Value != null).Select(i => (i.Key, i.Value)).ToList();
                        var dArgs = new Dictionary<string, Expression>();
                        llArgs.ForEach(arg => dArgs.Add(arg.Key, GetInputExpression(arg.Value, dScratch, gVariables, gFunc, returnTarget)));
                        var lArgs = new List<Expression>();
                        block.Mutation.ArgumentIds.ForEach(aid => lArgs.Add(dArgs[aid]));

                        var lpArgs = new List<Expression>();
                        for (int i = 0; i < lArgs.Count; i++)
                        {
                            lpArgs.Add(Expression.Assign(
                                Expression.Property(eFunc.Parameter, "Item", Expression.Constant(i, typeof(int))),
                                lArgs[i]));
                        }
                        lpArgs.Add(Expression.IfThen(
                            Expression.Invoke(eFunc.Function, eFunc.Parameter),
                            Expression.Return(returnTarget)));

                        // Проверка времени выполнения
                        var isCancellationRequested = Expression.Property(gVariables["CANCEL_TOKEN"], "IsCancellationRequested");
                        var cancelCondition = Expression.IfThen(isCancellationRequested, Expression.Return(returnTarget));
                        lpArgs.Add(cancelCondition);

                        expression = Expression.Block(lpArgs);
                        break;
                    }
                case Opcode.ArgumentReporterStringNumber:
                    {
                        var argFunc = gFunc.First(f => f.Value.PrototypeMutation.ArgumentNames.Contains(block.Fields[0].Name)).Value;
                        var index = argFunc.PrototypeMutation.ArgumentNames.IndexOf(block.Fields[0].Name);
                        expression = Expression.Property(argFunc.Parameter, "Item", Expression.Constant(index, typeof(int)));
                        break;
                    }
                case Opcode.ArgumentReporterBoolean:
                    {
                        var argFunc = gFunc.First(f => f.Value.PrototypeMutation.ArgumentNames.Contains(block.Fields[0].Name)).Value;
                        var index = argFunc.PrototypeMutation.ArgumentNames.IndexOf(block.Fields[0].Name);
                        expression = Expression.Property(argFunc.Parameter, "Item", Expression.Constant(index, typeof(int)));
                        break;
                    }
            }
            
            return expression;
        }

        /// <summary>
        /// Конвертирует введенное в блок значение в выражение.
        /// </summary>
        /// <param name="input">Введенное в блок значение.</param>
        /// <param name="dScratch">Словари блоков, переменных, списков.</param>
        /// <param name="gVariables">Словарь глобальных переменных в виде выражений.</param>
        /// <param name="gFunc">Словарь функций и их аргументов в виде выражений.</param>
        /// <param name="returnTarget">Метка прекращения выполнения программы.</param>
        /// <returns>Выражение введенного в блок значения.</returns>
        private static Expression GetInputExpression(SInput input,
                                                     DScratch dScratch,
                                                     Dictionary<string, ParameterExpression> gVariables,
                                                     Dictionary<string, EFunc> gFunc,
                                                     LabelTarget returnTarget)
        {
            switch (input.Type)
            {
                case TypeOfInput.Variable:
                    return gVariables[input.Value];
                case TypeOfInput.List:
                    return Expression.Call(typeof(Operations), "GetInputRepresOfList", null, gVariables[input.Value]);
                case TypeOfInput.Block:
                    return GetExpressionFromBlock(dScratch.Blocks[input.Value], dScratch, gVariables, gFunc, returnTarget);
                default:
                    return Expression.Constant(input.Value, typeof(object));
            }
        }

        /// <summary>
        /// Находит выражение переменной или списка выбранных в выпадающем меню блока.
        /// </summary>
        /// <param name="field">Поле выбора блока.</param>
        /// <param name="gVariables">Словарь глобальных переменных в виде выражений.</param>
        /// <returns>Выражение переменной или списка.</returns>
        private static Expression GetFieldExpression(SField field, Dictionary<string, ParameterExpression> gVariables)
        {
            return gVariables[field.Id];
        }

        /// <summary>
        /// Компилирует дерево выражений <see cref = "Expression"/>.
        /// </summary>
        /// <param name="expression">Дерево выражений.</param>
        /// <returns>Скомпилированная из дерева выражений функция.</returns>
        public static Func<CancellationToken, List<object>, List<object>> Compile(Expression<Func<CancellationToken, List<object>, List<object>>> expression)
        {
            return expression is null ? null : expression.Compile();
        }

        /// <summary>
        /// Выполняет функцию с указанными параметрами. Ограничивает время выполнения.
        /// </summary>
        /// <param name="timeout">Максимальное время выполнения.</param>
        /// <param name="function">Выполняемая функция.</param>
        /// <param name="parameters">Параметры функции.</param>
        /// <returns>Возвращенное функцией значение и значение ошибки выполнения.</returns>
        public static (List<object>, int) Run(TimeSpan timeout, Func<CancellationToken, List<object>, List<object>> function, List<object> parameters)
        {
            if (function is null)
            {
                return (new List<object>(), 2);
            }

            var source = new CancellationTokenSource();
            source.CancelAfter(timeout);
            var task = Task.Run(() => function(source.Token, parameters));
            var res = task.Result;
            return source.IsCancellationRequested ? (new List<object>(), 1) : (res, 0);
        }
    }
}
