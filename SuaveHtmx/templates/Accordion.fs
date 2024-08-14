module SuaveHtmx.Templates.Accordion

open Falco.Markup
open SuaveHtmx.Hyperscript
open SuaveHtmx.Styles

type AccordionItem =
    { Id: string
      Title: XmlNode
      Children: XmlNode list }

let accordion (items: AccordionItem list) =
    Elem.div
        [ Attr.class' "accordion" ]
        [ for item in items do
              Elem.div
                  [ Attr.class' "cursor-pointer accordion-item py-2"; Attr.id item.Id ]
                  [ Elem.div
                        [ Attr.hyperscript
                              """
                            on click toggle .rotate-90 on the first .accordion-icon in me
                            on click toggle .hidden on the next .accordion-children
                            """
                          Attr.class' $"accordion-title flex flex-row items-center w-fit {listItem}" ]
                        [ Elem.div
                              [ Attr.class' "accordion-icon mr-2 transition-all transform" ]
                              [ Svg.triangleIcon "size-5 lg:size-6" ]
                          item.Title ]
                    Elem.div [ Attr.class' "accordion-children w-fit hidden ml-4 lg:ml-6 py-2 flex-col" ] item.Children ] ]
