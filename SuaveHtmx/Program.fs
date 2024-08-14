module SuaveHtmx.Program

open Suave
open Suave.Filters
open Suave.Operators
open SuaveHtmx.Books.BooksPageHandler

let app =
    let connectionString = System.Environment.GetEnvironmentVariable "DATABASE_URL"

    choose [ GET >=> choose [ path "/books" >=> booksPageHandler connectionString ] ]

startWebServer defaultConfig app
