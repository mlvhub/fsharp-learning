namespace SuaveHtmx.Books

open System
open SuaveHtmx.Chapters

type Book = { Id: Guid; Name: string }

type BookWithChapters =
    { Id: Guid
      Name: string
      Chapters: Chapter list }
