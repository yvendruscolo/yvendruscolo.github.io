module Utils

open System.IO

open Falco.Markup
open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Text

open FSharp.Formatting.Markdown

let script' source = script [ src source ; type' "text/javascript" ; create "async" "true"] []

let htmlx = script' "https://unpkg.com/htmx.org@1.0.2/dist/htmx.min.js"

let randomStyle = script' "random-stylesheet.js"

let pagestyle = link [ id "pagestyle" ; rel "stylesheet" ; type' "text/css"]

let center = tag "center" []

let h1' txt = h1 [] [ raw txt ]

let title' txt = title [] [ raw txt ]

let filename (path: string) = path |> Path.GetFileNameWithoutExtension

let spit file content = File.WriteAllTextAsync($"public/{file}.html", content) |> Async.AwaitTask

let mdToHtml = Markdown.Parse >> Markdown.ToHtml >> String.filter ("\n\r".Contains >> not)

let mkAttrs = List.map (fun (k,v) -> Attr.create k v)

let swapPost url = mkAttrs ["hx-swap","innerHTML";
                            "hx-target","#posts-body";
                            "hx-trigger","click";
                            "hx-get", $"{url}.html"]

let renderSpit (page, content) = renderHtml content |> spit (filename page)

let postListFile = "post-list"

let doRun work = work |> Async.Parallel |> Async.Ignore |> Async.RunSynchronously