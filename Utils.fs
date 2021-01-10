module Utils

open System.IO

open FSharpPlus

open Falco.Markup
open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Text

open FSharp.Formatting.Markdown

[<AutoOpen>]
module FileNames =
  let postListF = "post-list"
  let aboutMeF = "about"

[<AutoOpen>]
module CustomElements =
  let script' source = script [ src source ; type' "text/javascript" ; create "async" "true"] []
  let pagestyle = link [ id "pagestyle" ; rel "stylesheet" ; type' "text/css"]
  let center = tag "center" []
  let h2' txt = h2 [] [ raw txt ]
  let title' txt = title [] [ raw txt ]

[<AutoOpen>]
module Javascripts =
  let htmlx = script' "https://unpkg.com/htmx.org@1.0.2/dist/htmx.min.js"
  let randomStyle = script' "random-stylesheet.js"

[<AutoOpen>]
module FileSystemsUtils =
  let filename (path: string) = path |> Path.GetFileNameWithoutExtension
  let spit file content = File.WriteAllTextAsync($"public/{file}.html", content) |> Async.AwaitTask
  let mdToHtml = Markdown.Parse >> Markdown.ToHtml >> String.filter ("\n\r".Contains >> not)
  let renderSpit (page, content) = renderHtml content |> spit (filename page)

[<AutoOpen>]
module StyesAndAttrs =
  let mkAttrs = map (fun (k,v) -> Attr.create k v)
  let swapFocus url = mkAttrs ["hx-swap","innerHTML"
                               "hx-target","#focus"
                               "hx-trigger","click"
                               "hx-get", $"{url}.html"]

  let mkStyles styles =
    "style", styles |> map (fun (k,v) -> $"{k}: {v}")
                    |> String.concat ";"

  let navAttrs pontTo =
    mkAttrs [ mkStyles ["display","inline-block";
                        "margin-right","50px";
                        "margin-left","50px"] ]
    @ swapFocus pontTo


let inline first c = nth 0 c
let inline runWork job = job |> Async.Parallel |> Async.Ignore |> Async.RunSynchronously
