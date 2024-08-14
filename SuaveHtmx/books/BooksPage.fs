module SuaveHtmx.Books.BooksPage

open Falco.Markup
open SuaveHtmx.Styles
open SuaveHtmx.Templates.Accordion
open SuaveHtmx.Templates.Layout
open SuaveHtmx.Htmx

let private content (booksWithChapters: BookWithChapters list) =
    Elem.div
        [ Attr.class' "flex flex-col" ]
        [ Elem.h1 [ Attr.class' title ] [ Text.raw "Available Books and Chapters" ]
          accordion (
              booksWithChapters
              |> List.sortBy (fun b -> b.Name)
              |> List.map (fun book ->
                  { Id = book.Id.ToString()
                    Title = Elem.p [ Attr.class' listItem ] [ Text.raw book.Name ]
                    Children =
                      book.Chapters
                      |> List.map (fun chapter ->
                          Elem.p
                              [ Attr.class' (sprintf "py-1 %s" accordionItem) ]
                              [ Elem.a
                                    [ Attr.class' "cursor-pointer"
                                      Attr.hxGet $"/chapters/{chapter.Id.ToString()}/quizzes"
                                      Attr.hxTarget "#body-content"
                                      Attr.hxPushUrl $"/chapters/{chapter.Id.ToString()}/quizzes" ]
                                    [ Text.raw chapter.Name ] ]) })
          ) ]

let booksPage (booksWithChapters: BookWithChapters list) (includeLayout: bool) =
    if includeLayout then
        layout "Books - Grokkr" (content booksWithChapters) List.empty
    else
        content booksWithChapters
