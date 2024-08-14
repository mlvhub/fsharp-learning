module SuaveHtmx.Books.BookRepository

open Npgsql.FSharp
open System.Threading.Tasks
open SuaveHtmx.Books

let listBooks (connectionString: string) : Task<Book list> =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT id, name FROM grokkr.books"
    |> Sql.executeAsync (fun read ->
        { Id = read.uuid "id"
          Name = read.text "name" })
