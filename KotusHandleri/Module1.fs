// Learn more about F# at http://fsharp.net

module Module1
open System.IO
open System.Xml.Linq

let rec canBeFormed (x : string) (y : string) = 
            if(x.Length = 0) then true
            else
                let found = y.IndexOf(x.Chars(0))
                if (found = -1) then false
                else canBeFormed (x.Substring(1)) (y.Remove(found, 1))

let fileparsed = XElement.Load(@"c:\KotusSolver\KotusHandleri\kotus-sanalista_v1.xml") 

let content ( file : XElement) y = 
                file.Elements(XName.Get("st")) |> Seq.map (fun x -> x.Element(XName.Get("s"))) |> Seq.map (fun x -> x.Value)
                |> Seq.filter (fun x -> x.Length < 8 && x.Length > 2)
                |> Seq.filter (fun x -> canBeFormed x y)
                |> Seq.distinct
                |> Seq.sortBy (fun x -> x.Length)

let resolveFromKotus x = content fileparsed x
