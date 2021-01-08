open System.IO

open Falco.Markup
open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Templates
open Falco.Markup.Text


let script' source = script [ src source ; type' "text/javascript" ; create "async" "true"] []

let htmlx = script' "https://unpkg.com/htmx.org@1.0.2"

let randomStyle = script' "random-stylesheet.js"

let pagestyle = link [ id "pagestyle" ; rel "stylesheet" ; type' "text/css"]

let center = tag "center" []

let h1' txt = h1 [] [ raw txt ]

let body' =
  body []  [
    center [ h1' "Hi!"
             h3 [ create "word-wrap" "break-word" ]
                [ raw "Nothing here yet, check it out later ... &#9951;" ] ] ]

let title' txt = title [] [ raw txt ]

let index =
  html5 "en"
    [ title' "Ol&aacute!" ; pagestyle ; randomStyle ; htmlx ]
    [ body' ]

let renderTo file content = File.WriteAllText($"{file}.html", renderHtml content)

renderTo "index" index


