// Lesson 28 - Architecting Hybred Language Applications  - pg. 231

module OrderManagement

open System.Collections.Generic


/////////////////////////////////////////
// 28.1.1 Accepting data from external systems  - pg. 332

// 28.1.1 Accepting data from external systems


// Listing 28.1 A simple domain model for use within C#

type OrderItemRequest = { ItemId : int; Count : int }

type OrderRequest =
  {  OrderId : int
     CustomerName : string      // mandatory
     Comment : string           // optional
     /// One of (email or telephone), or none
     EmailUpdates : string      // A set of related properties
     TelephoneUpdates : string  // ..
     Items : IEnumerable<OrderItemRequest> } 


// Listing 28.2 Modeling the same domain in F#  - pg. 33
module private OrderProcessing =
    type OrderId = OrderId of int
    type ItemId = ItemId of int
    type OrderItem = { ItemId : ItemId; Count : int }

    type UpdatePreference =
        | EmailUpdates of string
        | TelephoneUpdates of string

    type Order =
      { OrderId : OrderId
        CustomerName : string  // should never be null
        ContactPreference : UpdatePreference option
        Comment : string option
        Items : OrderItem list }


// Listing 28.3 Validating and transforming data  - pg. 334

    let validate (orderRequest : OrderRequest) =
      { OrderId = OrderId orderRequest.OrderId
        CustomerName =
             match orderRequest.CustomerName with
             | null -> failwith "Customer name must be populated"
             | name -> name
        Comment = orderRequest.Comment |> Option.ofObj
        ContactPreference =
             match Option.ofObj orderRequest.EmailUpdates, Option.ofObj orderRequest.TelephoneUpdates with
             | None, None -> None
             | Some email, None -> Some(EmailUpdates email)
             | None, Some phone -> Some(TelephoneUpdates phone)
             | Some _, Some _ -> failwith "Unable to proceed - only one of telephone and email should be supplied"
        Items =
            orderRequest.Items
            |> Seq.map(fun item -> { ItemId = ItemId item.ItemId; Count = item.Count })
            |> Seq.toList }

    let processOrder (order:Order) = "SUCCESS"

let placeOrder = OrderProcessing.validate >> OrderProcessing.processOrder
