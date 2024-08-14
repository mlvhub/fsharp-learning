module SuaveHtmx.Books.BooksPageHandler

open SuaveHtmx.Books.BooksPage
open SuaveHtmx.Books.BookRepository
open SuaveHtmx.Chapters.ChapterRepository
open Falco.Markup
open Suave.Successful
open Suave

let private makeBookWithChapters (connectionString: string) (book: Book) : Async<BookWithChapters> =
    async {
        let! chapters = listChapters connectionString book.Id

        return
            { Id = book.Id
              Name = book.Name
              Chapters = chapters }
    }

let booksPageHandler (connectionString: string) =
    fun (ctx: HttpContext) ->
        async {
            let! books = listBooks connectionString

            let booksWithChapters =
                books
                |> List.map (makeBookWithChapters connectionString)
                |> Async.Parallel
                |> Async.RunSynchronously
                |> Array.toList

            let includeLayout =
                ctx.request.headers |> List.contains ("HX-Request", "true") |> not

            printf "headers: %A" ctx.request.headers

            let renderedPage = booksPage booksWithChapters includeLayout |> renderHtml

            return! OK renderedPage ctx
        }
