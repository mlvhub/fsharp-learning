namespace SuaveHtmx.Htmx

open Falco.Markup

module Attr =
    let hxTrigger = Attr.create "hx-trigger"
    let hxTarget = Attr.create "hx-target"
    let hxGet = Attr.create "hx-get"
    let hxPost = Attr.create "hx-post"
    let hxPushUrl = Attr.create "hx-push-url"
