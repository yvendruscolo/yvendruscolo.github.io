open FSharpPlus

open Falco.Markup.Attr
open Falco.Markup.Elem
open Falco.Markup.Templates
open Falco.Markup.Text

open Utils
open Posts

let aboutMe = div [] []

let body' =
  body []  [
    center [ h2' "Welcome to my little corner on the internet!"
             div (mkAttrs ["display","block"])
                  [ h3 (navAttrs aboutMeF) [raw "About me"]
                    h3 (navAttrs postListF) [raw "🗒 Posts"] ]
             div [ id "focus" ]
                 [ ] ] ]

let index = html5 "en" [ title' "👋 Ol&aacute!"
                         pagestyle
                         randomStyle
                         htmlx ]
              [ body' ]

[| "index", index
   postListF, postList ()
   aboutMeF, aboutMe |]

|> map renderSpit
<|> renderPosts ()
|> runWork
