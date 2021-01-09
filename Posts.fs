module Posts

open System.IO

open Falco.Markup
open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Templates
open Falco.Markup.Text

open FSharp.Formatting.Markdown
open FSharp.Formatting.Common

open Utils

let posts' = Directory.EnumerateFiles
             >> Seq.filter (Path.GetExtension >> (=) ".md")

let posts () = posts' "posts"

let renderPost post = async {
    let! content = File.ReadAllTextAsync post |> Async.AwaitTask
    return! content |> mdToHtml 
            |> spit (post |> filename)
    }

let renderPosts = posts >> Seq.map renderPost

let postLink (post: string) =
    let face = File.ReadLines(post) |> Seq.head

    li (post |> filename |> swapPost)
       [face.TrimStart([|'#';' '|]) |> raw]

let postList' =
    posts >> Seq.sortByDescending (fun x -> x.Split('_').[0])
    >> Seq.map postLink >> List.ofSeq

let postList = ul [] (postList' ())