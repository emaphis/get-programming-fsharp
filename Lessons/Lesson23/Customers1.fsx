// Lesson 23 - Business Rules as Code

// Now you try  - pg. 273
(*
Let’s see how to enhance your domain model so that you can’t accidentally mix and
match the values for the different fields:

 1 Start with an empty script, creating the Customer record and createCustomer function
   (with the incorrect assignments)

 2 Create four single-case discriminated unions, one for each type of string you
  want to store (CustomerId, Email, Telephone, and Address).

 3 Update the definition of the Customer type so that each field uses the correct wrapper type. Make sure you define the wrapper types before the Customer type!

 4 Update the callsite to createCustomer so that you wrap each input value into the correct DU; you’ll need to surround each “wrapping” in parentheses (see figure 23.1).

   If you’ve done this correctly, you’ll notice that your code immediately stops
   working.

   Interestingly, the compiler error will be generated on the callsite to createCustomer.
   This is a case of “following the breadcrumbs” with type inference; if you mouse
   over any of the arguments to the function itself, you’ll see that this is because
   you’ve mixed up the assignments to the wrong fields.

 5 Fix the assignments in the createCustomer function and you’ll see that as if by magic
   all the errors disappear.
*)

// Listing 23.4 Creating wrapper types for contact details
// 2.
type CustomerId = CustomerId of string
type Email = Email of string
type Telephone = Telephone of string
type Address = Address of string

// 3.
type Customer =
  { CustomerId : CustomerId
    Email : Email
    Telephone : Telephone
    Address : Address }

// 5.
let createCustomer customerId email telephone address =
  { CustomerId = customerId
    Email = email
    Telephone = telephone
    Address = address }

// 4.
let customer =  // oops
    createCustomer
      (CustomerId "C-123")
      (Email "nicki@myemail.com")
      (Telephone "029-293-23" )
      (Address "1 The Street")
