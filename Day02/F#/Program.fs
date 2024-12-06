open System.IO

let ToInt str : int = str |> int

let ToListInt(line :string) : list<int> = 
    let values = line.Split(' ')
    values |> List.ofArray |> List.map ToInt

let Abs(value :int) :int=
    let mutable possitiveValue = value
    if value < 0 then
        possitiveValue <- value * -1
    possitiveValue

let removeAt(index :int, list) =
    // Récupération des i premier element puis skip des i + 1 premier
    List.take index list @ List.skip (index + 1) list

let IsSafe (vals: list<int>) : bool =
    let mutable safe = true
    for i in 1 .. vals.Length - 2 do
        if (vals.[i] > vals.[i + 1] && (vals.[i - 1] > vals.[i]) <> true) then
            safe <- false
        elif (vals.[i] < vals.[i + 1] && (vals.[i - 1] < vals.[i]) <> true) then
            safe <- false
    if (safe) then
        for i in 0 .. vals.Length - 2 do
            if (Abs(vals.[i] - vals.[i + 1]) < 1 || Abs(vals.[i] - vals.[i + 1]) > 3) then
                safe <-false
    safe


let rec IsSafeWithRemoval(intVals :list<int>, i :int) :bool =
    if i >= intVals.Length then
        false
    else
        let tempList = removeAt (i, intVals)
        if IsSafe tempList then
            true
        else
            IsSafeWithRemoval(intVals, i + 1)


let Part1 (lines :list<string>) :int =
    let mutable total = 0
    for line in lines do
        let intVals = ToListInt line
        if (IsSafe intVals) then
            total <- total + 1
    total

let Part2 (lines :list<string>) :int =
    let mutable total = 0
    for line in lines do
        let intVals = ToListInt line
        if (IsSafe intVals) then
            total <- total + 1
        elif (IsSafeWithRemoval(intVals, 0)) then
            total <- total + 1
    total

let lines = File.ReadAllLines("Input.txt")
let lineList : list<string> = Seq.toList(lines);

printfn "%d" (Part1 lineList)
printfn "%d" (Part2 lineList)