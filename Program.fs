let code = """
try
    8 / 0 |> ignore
with e -> 
    printfn $"Runtime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}"
    printfn $"Error: {e}" 
"""

open System
open System.IO
open FSharp.Compiler.Interactive.Shell

let eval(codeStr) = 
    let inn = new StringReader("")
    let out = Console.Out
    let config = FsiEvaluationSession.GetDefaultConfiguration()
    let noArgs = [| "the first arg is needed, but ignored";  "--multiemit" |]
    let session = FsiEvaluationSession.Create(config, noArgs, inn, out, out)
    session.EvalInteraction(codeStr)

eval(code)
    
System.Console.ReadLine() |> ignore

