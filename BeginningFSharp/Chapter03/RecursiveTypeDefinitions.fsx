/// Chapter 3 -  Functional Programming
/// Recursive Type Definitions
/// pg. 55

// mutually recursive types

// represents an XML attribute
type XmlAttribute =
    { AttributeName: string
      AttributeValue: string }

// represents ans XML element
type XmlElement =
    { ElementName: string
      Attributes: list<XmlAttribute>
      Inner: XmlTree }

// represents an XML tree
and XmlTree =
    | Element of XmlElement
    | ElementList of list<XmlTree>
    | Text of string
    | Comment of string
    | Empty 
