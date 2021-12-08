// Lesson 23 - Business Rules as Code

// Now you try  - pg. 276
(*
Merge all three of the single-case DUs into a single three-case DU called ContactDetails
and change your Customer type to store that instead of one field for each type of contact
detail:

type ContactDetails =
| Address of string
| Telephone of string
| Email of string

6 Replace the three single-case DUs with the new ContactDetails type

7 Update the Customer type by replacing the three optional fields with a single field
  of type ContactDetails.

8 Update the createCustomer function. It now needs to take in only two arguments,
  the CustomerId and the ContactDetails.

9 Update the callsite as appropriate; for example:

let customer =
    createCustomer (CustomerId "Nicki") (Email "nicki@myemail.com")

Follow these steps:
10 Add a new field to your Customer that contains an optional ContactDetail, and
   rename your original ContactDetail field to PrimaryContactDetails.

11 Update the createCustomer function and callsite as appropriate.
*)

type ContactDetails =
| Address of string
| Telephone of string
| Email of string

type CustomerId = CustomerId of string

// 7.
type Customer =
  { CustomerId : CustomerId
    ContactDetails : ContactDetails
    AlternateContactDetails : ContactDetails option }

// 8. 10.
let createCustomer customerId contactDetails alternateContactDetails =
  { CustomerId = customerId
    ContactDetails = contactDetails
    AlternateContactDetails = alternateContactDetails }

// 9. 11.
let customer =
    createCustomer (CustomerId "Nicki") (Email "nicki@myemail.com") None
