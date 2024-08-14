module SuaveHtmx.Templates.Layout

open Falco.Markup
open SuaveHtmx.Htmx

let layout titleText content headContent =
    Elem.html
        []
        [ Elem.head
              []
              ([ Elem.title [] [ Text.raw titleText ]
                 Elem.meta [ Attr.name "viewport"; Attr.content "width=device-width, initial-scale=1.0" ]
                 Elem.script
                     [ Attr.src "https://cdn.tailwindcss.com?plugins=forms,typography,aspect-ratio,line-clamp" ]
                     []
                 Elem.script [ Attr.src "https://unpkg.com/htmx.org@1.9.12" ] []
                 Elem.script [ Attr.src "https://unpkg.com/hyperscript.org@0.9.12" ] [] ]
               @ headContent)
          Elem.body
              [ Attr.class' "bg-indigo-100" ]
              [ Elem.nav
                    [ Attr.class' "flex justify-between items-center bg-indigo-700 py-3 px-5 lg:py-4 lg:px-8" ]
                    [ Elem.div
                          []
                          [ Elem.a
                                [ Attr.href "/"
                                  Attr.class'
                                      "cursor-pointer text-white font-bold hover:text-indigo-500 text-3xl lg:text-3xl" ]
                                [ Text.raw "Grokkr" ] ]
                      Elem.div
                          []
                          [ Elem.a
                                [ Attr.hxGet "/books"
                                  Attr.hxTarget "#body-content"
                                  Attr.hxPushUrl "/books"
                                  Attr.class'
                                      "cursor-pointer text-white hover:text-indigo-500 pr-4 text-xl lg:pr-8 lg:text-lg" ]
                                [ Text.raw "Books" ] ] ]
                Elem.div
                    [ Attr.id "body-content"
                      Attr.class' "container mx-auto py-6 px-4 lg:py-6 lg:px-6" ]
                    [ content ] ] ]
