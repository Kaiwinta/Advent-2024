// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

open System.IO

let lines = File.ReadAllLines("Input.txt")
let lineList = Seq.toList(lines);

let ToInt str : int = str |> int

let isSafe(line :string) :bool = 
    let values = line.Split(" ")
    let compare = 0
    let lastValue = -1
    values |> List.map ToInt |>
        if lastValue == -1 then (lastValue = intValue)
    )
    values.Length > 0

lineList |> List.iter (fun line ->
    printfn "%s" line
    printfn "%b" (isSafe line)
)


let test = 4