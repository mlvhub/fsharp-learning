module SuaveHtmx.Chapters.ChapterRepository

open System.Threading.Tasks
open Npgsql.FSharp
open SuaveHtmx.Chapters
open System

let listChapters (connectionString: string) (bookId: Guid) : Task<Chapter list> =
    connectionString
    |> Sql.connect
    |> Sql.query "SELECT id, name FROM grokkr.chapters WHERE book_id = @bookId"
    |> Sql.parameters [ "bookId", Sql.uuid bookId ]
    |> Sql.executeAsync (fun read ->
        { Id = read.uuid "id"
          Name = read.text "name" })
