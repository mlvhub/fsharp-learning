#r "nuget: Suave"

open Suave

startWebServer defaultConfig (Successful.OK "Hello World!")
