open Suave
open Suave.Filters
open Suave.DotLiquid
open Suave.Operators
open Npgsql.FSharp
open System
open System.Threading.Tasks

setTemplatesDir "./templates"
setCSharpNamingConvention ()

type Book = { Id: Guid; Name: string }

let listBooks (connectionString: string) : Task<list<Book>> =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT id, name FROM grokkr.books"
    |> Sql.executeAsync (fun read ->
        { Id = read.uuid "id"
          Name = read.text "name" })

type Model = { Title: string; Books: list<Book> }

let bookListHandler (connectionString: string) =
    fun ctx ->
        async {
            let! books = listBooks connectionString
            printfn "books: %A" books
            let model = { Title = "Books"; Books = books }
            return! page "list_books.liquid" model ctx
        }

let app =
    let connectionString = System.Environment.GetEnvironmentVariable "DATABASE_URL"

    choose [ GET >=> choose [ path "/books" >=> bookListHandler connectionString ] ]

startWebServer defaultConfig app
