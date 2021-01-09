open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Templates
open Falco.Markup.Text

open Utils
open Posts

let body' =
  body []  [
    center [ h1' "Hi!"
             h3 [ create "word-wrap" "break-word" ]
                [ raw "Nothing here yet, check it out later ... &#9951;" ]
             span [] [ p (swapPost postListFile) [ raw "🗒 Posts" ] ]
             div [ id "posts-body" ]
                 [ postList ] ] ]

let index =
  html5 "en"
    [ title' "Ol&aacute!" ; pagestyle ; randomStyle ; htmlx ]
    [ body' ]

[|"index", index;
  postListFile, postList|]
|> Seq.map renderSpit
|> Seq.append (renderPosts ())
|> doRun
