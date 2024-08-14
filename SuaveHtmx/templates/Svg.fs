module SuaveHtmx.Templates.Svg

open Falco.Markup

module Elem =
    let path = Elem.create "path"

module Attr =
    let xmlns = Attr.create "xmlns"
    let fill = Attr.create "fill"
    let viewBox = Attr.create "viewBox"
    let strokeWidth = Attr.create "strokeWidth"
    let stroke = Attr.create "stroke"
    let strokeLinecap = Attr.create "strokeLinecap"
    let strokeLinejoin = Attr.create "strokeLinejoin"
    let d = Attr.create "d"
    let fillRule = Attr.create "fillRule"
    let clipRule = Attr.create "clipRule"

let correctIcon classStr =
    Elem.svg
        [ Attr.xmlns "http://www.w3.org/2000/svg"
          Attr.fill "none"
          Attr.viewBox "0 0 24 24"
          Attr.strokeWidth "1.5"
          Attr.stroke "currentColor"
          Attr.class' classStr ]
        [ Elem.path
              [ Attr.strokeLinecap "round"
                Attr.strokeLinejoin "round"
                Attr.d "m4.5 12.75 6 6 9-13.5" ]
              [] ]

let incorrectIcon classStr =
    Elem.svg
        [ Attr.xmlns "http://www.w3.org/2000/svg"
          Attr.fill "none"
          Attr.viewBox "0 0 24 24"
          Attr.strokeWidth "1.5"
          Attr.stroke "currentColor"
          Attr.class' classStr ]
        [ Elem.path
              [ Attr.strokeLinecap "round"
                Attr.strokeLinejoin "round"
                Attr.d "M6 18 18 6M6 6l12 12" ]
              [] ]

let warningIcon classStr =
    Elem.svg
        [ Attr.xmlns "http://www.w3.org/2000/svg"
          Attr.fill "none"
          Attr.viewBox "0 0 24 24"
          Attr.strokeWidth "1.5"
          Attr.stroke "currentColor"
          Attr.class' classStr ]
        [ Elem.path
              [ Attr.strokeLinecap "round"
                Attr.strokeLinejoin "round"
                Attr.d "M12 9v3.75m9-.75a9 9 0 1 1-18 0 9 9 0 0 1 18 0Zm-9 3.75h.008v.008H12v-.008Z" ]
              [] ]

let triangleIcon classStr =
    Elem.svg
        [ Attr.xmlns "http://www.w3.org/2000/svg"
          Attr.fill "currentColor"
          Attr.viewBox "0 0 24 24"
          Attr.strokeWidth "1.5"
          Attr.stroke "currentColor"
          Attr.class' classStr ]
        [ Elem.path
              [ Attr.fillRule "evenodd"
                Attr.clipRule "evenodd"
                Attr.d
                    "M4.5 5.653c0-1.427 1.529-2.33 2.779-1.643l11.54 6.347c1.295.712 1.295 2.573 0 3.286L7.28 19.99c-1.25.687-2.779-.217-2.779-1.643V5.653Z" ]
              [] ]
