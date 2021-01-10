module Posts

open System.IO

open FSharpPlus

open Falco.Markup.Elem
open Falco.Markup.Text

open Utils

let posts' = Directory.EnumerateFiles >> filter (String.endsWith ".md")

let posts () = posts' "posts"

let renderPost post = async {
    let! content = File.ReadAllTextAsync post |> Async.AwaitTask
    return! content |> mdToHtml 
            |> spit (post |> filename)
    }

let renderPosts = posts >> map renderPost >> toArray

let postHeadline = File.ReadLines >> first >> String.trimStart ['#';' '] >> raw

let postLink post =
   section (post |> filename |> swapFocus)
              [ postHeadline post ]

let postList = posts
            >> sortByDescending (String.split ["_"] >> first)
            >> map postLink
            >> intersperse (br [])
            >> toList >> div []
