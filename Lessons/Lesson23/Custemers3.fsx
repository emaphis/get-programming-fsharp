// Lesson 23 - Business Rules as Code

// 23.2 Encoding business rules with marker types  - pg. 277

(*
Customers should be validated as genuine customers,
based on whether their primary contact detail is an
email address from a specific domain. Only when
customers have gone through this validation process
should they receive a welcome email. Note that you’ll
also need to perform further functionality in the
future, depending on whether a customer is genuine
*)

type ContactDetails =
| Address of string
| Telephone of string
| Email of string

type CustomerId = CustomerId of string

type Customer =
  { CustomerId : CustomerId
    ContactDetails : ContactDetails
    AlternateContactDetails : ContactDetails option }


// Listing 23.6 Creating custom types to represent business states
// pg. 277
// Single-case DU to wrap around Customer
type GenuineCustomer = GenuineCustomer of Customer

// Listing 23.7 Creating a function to rate a customer  - pg. 279
/// Validate Customer
let validateCustomer customer =
    match customer.ContactDetails with
    | Email e when e.EndsWith "SuperCorp" ->
        Some(GenuineCustomer customer)
    | Address _ | Telephone _ -> Some(GenuineCustomer customer)
    | Email _   -> None

let sendWelcomeEmail (GenuineCustomer customer) =
    printfn "Hello, %A, and welcome to our site!" customer.CustomerId

let createCustomer customerId contactDetails alternateContactDetails : Customer =
  { CustomerId = customerId
    ContactDetails = contactDetails
    AlternateContactDetails = alternateContactDetails }


let customer =
    createCustomer (CustomerId "Nicki") (Email "nicki@myemail.com") None


customer
|> validateCustomer
|> Option.map sendWelcomeEmail

let customer2 =
    createCustomer (CustomerId "Welsley") (Address "100 Pine Street") None

customer2
|> validateCustomer
|> Option.map sendWelcomeEmail


// 23.3 Results vs. exceptions  - pg. 218

// sting 23.8 Creating a result type to encode success or failure

let insertContactUnsafe contactDetails =
  if contactDetails = (Email "nicki@myemail.com") then
    { CustomerId = CustomerId "ABC"
      ContactDetails = contactDetails
      AlternateContactDetails = None }
  else failwith "Unable to insert  - customer already exists."



type Result<'a> =
| Success of 'a
| Failure of string

let insertContact contactDetails =
  if contactDetails = (Email "nicki@myemail.com") then
    Success { CustomerId = CustomerId "ABC"
              ContactDetails = contactDetails
              AlternateContactDetails = None }
  else Failure "Unable to insert  - customer already exists."


//let insertCustomer : contactDetails:ContactDetails -> Result<CustomerId> =
match insertContact (Email "nicki@myemail.com") with
| Success customerId -> printfn "Saved with %A" customerId
| Failure error -> printfn "Unable to save: %s" error